using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class UserMessages : BaseEntity
    {
        public User? User { get; set; }
        public int UserId { get; set; }

        public Message? Message { get; set; }
        public int MessageId { get; set; }

        public bool IsSender { get; set; }
    }
}
