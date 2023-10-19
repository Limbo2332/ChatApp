using ChatApp.Common.Logic.Abstract;

namespace ChatApp.Common.Logic
{
    public class UserIdStorage : IUserIdGetter, IUserIdSetter
    {
        private int _id;

        public int CurrentUserId => _id;

        public void SetUserId(int userId)
        {
            _id = userId;
        }
    }
}
