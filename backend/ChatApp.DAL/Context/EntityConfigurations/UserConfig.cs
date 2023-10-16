using ChatApp.DAL.Context.SeedSettings;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.UserName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationSettings.UserNameMaxLength);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(EntityConfigurationSettings.EmailMaxLength);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(EntityConfigurationSettings.PasswordMaxLength);

            builder.HasIndex(user => user.UserName)
                .IsUnique();

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.HasMany(user => user.UserMessages)
                .WithOne(userMessage => userMessage.User)
                .HasForeignKey(userMessage => userMessage.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.UserChats)
                .WithOne(userChat => userChat.User)
                .HasForeignKey(userChat => userChat.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
