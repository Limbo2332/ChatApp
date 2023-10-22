using ChatApp.Common.Enums;
using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class Message : BaseEntity
    {
        public string Value { get; set; } = string.Empty;
        public MessageStatus MessageStatus { get; set; }

        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
