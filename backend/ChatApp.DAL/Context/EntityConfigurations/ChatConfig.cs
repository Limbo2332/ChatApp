using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasMany(chat => chat.UserChats)
                .WithOne(userChat => userChat.Chat)
                .HasForeignKey(userChat => userChat.ChatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(chat => chat.Messages)
                .WithOne(message => message.Chat)
                .HasForeignKey(message => message.ChatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
