﻿using ChatApp.DAL.Entities.Abstract;

namespace ChatApp.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string? ImagePath { get; set; }

        public IEnumerable<UserChats> UserChats { get; set; } = null!;
        public IEnumerable<Message> Messages { get; set; } = null!;
    }
}
