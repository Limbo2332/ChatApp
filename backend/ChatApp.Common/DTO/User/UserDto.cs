namespace ChatApp.Common.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
    }
}
