using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class UserChatsConfig : IEntityTypeConfiguration<UserChats>
    {
        public void Configure(EntityTypeBuilder<UserChats> builder)
        {
            builder.HasKey(userChat => new { userChat.UserId, userChat.ChatId });
        }
    }
}
