using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class UserChatsConfig : IEntityTypeConfiguration<UserChats>
    {
        public void Configure(EntityTypeBuilder<UserChats> builder)
        {
            builder.Property(userChat => userChat.IsSender)
                .IsRequired();
        }
    }
}
