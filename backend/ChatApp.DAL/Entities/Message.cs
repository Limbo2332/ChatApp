using ChatApp.Common.Enums;
using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class Message : BaseEntity
    {
        public string Value { get; set; } = string.Empty;
        public MessageStatus MessageStatus { get; set; }

        public Chat? Chat { get; set; }
        public int ChatId { get; set; }

        public IEnumerable<UserMessages>? UserMessages { get; set; }
    }
}
