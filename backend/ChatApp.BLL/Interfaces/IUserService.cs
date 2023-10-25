using ChatApp.DAL.Entities;

namespace ChatApp.BLL.Interfaces
{
    public interface IUserService
    {
        bool IsEmailUnique(string email);

        bool IsUserNameUnique(string userName);

        Task<User> FindUserByUsernameAsync(string userName);
    }
}
