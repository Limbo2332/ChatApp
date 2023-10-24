namespace ChatApp.DAL.Entities
{
    public class UserChats
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }
    }
}
