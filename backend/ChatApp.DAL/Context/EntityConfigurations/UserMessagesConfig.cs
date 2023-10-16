using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class UserMessagesConfig : IEntityTypeConfiguration<UserMessages>
    {
        public void Configure(EntityTypeBuilder<UserMessages> builder)
        {
            builder.Property(userMessage => userMessage.IsSender)
                .IsRequired();
        }
    }
}
