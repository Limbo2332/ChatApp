using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class Chat : BaseEntity
    {
        public IEnumerable<UserChats> UserChats { get; set; } = null!;
        public IEnumerable<Message> Messages { get; set; } = null!;
    }
}
