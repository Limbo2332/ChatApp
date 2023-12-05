using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class RefreshToken : BaseEntity
    {
        private const int DAYS_TO_EXPIRE = 5;

        public string Token { get; set; } = string.Empty;
        public DateTime Expires { get; set; } = DateTime.UtcNow.AddDays(DAYS_TO_EXPIRE);

        public bool IsActive => DateTime.UtcNow <= Expires;

        public User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
