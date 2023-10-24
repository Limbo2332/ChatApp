using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class Chat : BaseEntity
    {
        public IEnumerable<Message> Messages { get; set; } = null!;
        public IEnumerable<UserChats> UserChats { get; set; } = null!;
    }
}
