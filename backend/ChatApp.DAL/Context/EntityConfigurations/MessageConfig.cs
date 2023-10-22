using ChatApp.DAL.Context.SeedSettings;
using ChatApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.DAL.Context.EntityConfigurations
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(message => message.Value)
                .IsRequired()
                .HasMaxLength(EntityConfigurationSettings.MessageMaxLength);

            builder.Property(message => message.MessageStatus)
                .IsRequired();
        }
    }
}
