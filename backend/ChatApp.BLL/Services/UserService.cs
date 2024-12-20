﻿using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Constants;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Helpers;
using ChatApp.Common.Logic.Abstract;
using ChatApp.Common.Security;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace ChatApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IEmailService _emailService;
        private readonly IImageRepository _imageRepository;
        private readonly IBlobImageRepository _blobImageRepository;

        public UserService(
            IMapper mapper,
            IUserIdGetter userIdGetter,
            IBlobStorageService blobStorageService,
            IEmailService emailService,
            IUserRepository userRepository,
            IImageRepository imageRepository, 
            IBlobImageRepository blobImageRepository)
            : base(mapper, userIdGetter)
        {
            _blobStorageService = blobStorageService;
            _emailService = emailService;
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _blobImageRepository = blobImageRepository;
        }

        public bool IsEmailUnique(string email)
        {
            return !_userRepository.GetAll().Any(u => u.Email == email);
        }

        public bool IsUserNameUnique(string userName)
        {
            return !_userRepository.GetAll().Any(u => u.UserName == userName);
        }

        public async Task<User> FindUserByUsernameAsync(string userName)
        {
            return await _userRepository
                .GetByExpressionAsync(user => user.UserName.ToLower() == userName.ToLower())
                ?? throw new BadRequestException($"User with username {userName} doesn't exist");
        }

        public async Task<UserAvatarDto> UpdateUserAvatarAsync(IFormFile newAvatar)
        {
            if (!ValidateImageFormat(newAvatar.ContentType))
            {
                throw new BadRequestException("Image type is wrong.");
            }

            var user = await GetCurrentUserAsync();

            var newImagePath = await _blobStorageService.UploadNewFileAsync(newAvatar);

            if (!user.ImageId.IsNullOrEmpty())
            {
                var image = await _imageRepository.DeleteAsync(user.ImageId!);

                await _blobStorageService.DeleteProfileAvatarAsync(image.ImagePath);
            }

            var newImage = await _imageRepository.AddAsync(newImagePath);
            user.ImageId = newImage.Id;

            await _userRepository.UpdateAsync(user);

            return new UserAvatarDto()
            {
                ImagePath = _blobStorageService.GetFullAvatarPath(newImagePath)
            };
        }

        public async Task<BlobImage> UpdateUserSqlAvatarAsync(IFormFile newAvatar)
        {
            if (!ValidateImageFormat(newAvatar.ContentType))
            {
                throw new BadRequestException("Image type is wrong.");
            }
            
            using var memoryStream = new MemoryStream();
            await newAvatar.CopyToAsync(memoryStream);

            var sqlImage = new BlobImage
            {
                Name = FileNameGeneratorHelper.GenerateUniqueFileName(newAvatar.FileName),
                ContentType = newAvatar.ContentType,
                Data = memoryStream.ToArray(),
            };
            
            await _blobImageRepository.AddAsync(sqlImage);
            
            var user = await GetCurrentUserAsync();
            user.BlobImageId = sqlImage.Id;
            await _userRepository.UpdateAsync(user);

            return sqlImage;
        }

        public async Task<UserDto> UpdateUserAsync(UserEditDto user)
        {
            var currentUser = await GetCurrentUserAsync();

            if (currentUser.Email != user.Email && !IsEmailUnique(user.Email))
            {
                throw new BadRequestException(ValidationMessages.EMAIL_IS_NOT_UNIQUE_MESSAGE);
            }

            currentUser.Email = user.Email;

            if (currentUser.UserName != user.UserName && !IsUserNameUnique(user.UserName))
            {
                throw new BadRequestException(ValidationMessages.UsernameIsNotUniqueMessage);
            }

            currentUser.UserName = user.UserName;

            var userImage = await _imageRepository.GetAsync(currentUser.ImageId);
            currentUser.ImageId = userImage?.Id;

            await _userRepository.UpdateAsync(currentUser);

            return _mapper.Map<UserDto>(currentUser);
        }

        public async Task<MailDto?> SendResetEmailAsync(string email)
        {
            var emailToken = GenerateEmailToken();

            var mail = new MailDto
            {
                Subject = "Reset password",
                Content = ResetEmailContentGenerator.EmailResetStringBody(email, emailToken),
                To = email
            };

            var result = await _emailService.SendEmailAsync(mail);

            return result.HasCompleted ? mail : null;
        }

        public async Task ResetPasswordAsync(ResetPasswordDto newInfo)
        {
            var user = await _userRepository
                .GetByExpressionAsync(user => user.Email == newInfo.Email)
                ?? throw new BadRequestException($"User with email {newInfo.Email} doesn't exist");

            user.Password = SecurityHelper.HashPassword(newInfo.NewPassword, Convert.FromBase64String(user.Salt));

            await _userRepository.UpdateAsync(user);
        }

        public string GenerateEmailToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(32);

            return Convert.ToBase64String(tokenBytes);
        }

        public async Task<User> GetCurrentUserAsync()
        {
            int currentUserId = _userIdGetter.CurrentUserId;

            return await _userRepository
                .GetByExpressionAsync(u => u.Id == currentUserId)
                 ?? throw new NotFoundException(nameof(User), currentUserId);
        }

        private bool ValidateImageFormat(string imageType)
        {
            var idxDot = imageType.LastIndexOf('/') + 1;
            var extFile = imageType.Substring(idxDot).ToLower();

            return extFile == "jpg" || extFile == "jpeg" || extFile == "png";
        }
    }
}
