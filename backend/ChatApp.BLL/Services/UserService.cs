using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Exceptions;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter)
            : base(context, mapper, userIdGetter)
        {
        }

        public bool IsEmailUnique(string email)
        {
            return !_context.Users.Any(u => u.Email == email);
        }

        public bool IsUserNameUnique(string userName)
        {
            return !_context.Users.Any(u => u.UserName == userName);
        }

        public async Task<User> FindUserByUsernameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.UserName.ToLower() == userName.ToLower())
                ?? throw new BadRequestException($"User with username {userName} doesn't exist");
        }
    }
}
