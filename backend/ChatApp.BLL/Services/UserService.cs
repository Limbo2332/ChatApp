using AutoMapper;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;

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
    }
}
