﻿using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("send-reset-email")]
        public async Task<ActionResult<MailDto>> SendEmailAsync(ResetEmailDto resetEmail)
        {
            return Ok(await _userService.SendResetEmailAsync(resetEmail.Email));
        }

        [AllowAnonymous]
        [HttpPost("reset")]
        public async Task<ActionResult> ResetPasswordAsync(ResetPasswordDto newInfo)
        {
            await _userService.ResetPasswordAsync(newInfo);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUserAsync(UserEditDto user)
        {
            return Ok(await _userService.UpdateUserAsync(user));
        }

        [HttpPost("avatar")]
        public async Task<ActionResult<UserAvatarDto>> UpdateAvatarAsync([FromForm] IFormFile newAvatar)
        {
            return Ok(await _userService.UpdateUserAvatarAsync(newAvatar));
        }

        [HttpPost("sql-avatar")]
        public async Task<ActionResult<BlobImageDto>> UpdateSqlAvatarAsync([FromForm] IFormFile newAvatar)
        {
            var blobImage = await _userService.UpdateUserSqlAvatarAsync(newAvatar);
            
            return Ok(blobImage);
        }
    }
}
