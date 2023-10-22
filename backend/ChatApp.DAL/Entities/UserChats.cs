using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class UserChats : BaseEntity
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }

        public bool IsSender { get; set; }
    }
}
