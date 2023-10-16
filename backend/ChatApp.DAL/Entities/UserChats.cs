using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class UserChats : BaseEntity
    {
        public User? User { get; set; }
        public int UserId { get; set; }

        public Chat? Chat { get; set; }
        public int ChatId { get; set; }

        public bool IsSender { get; set; }
    }
}
