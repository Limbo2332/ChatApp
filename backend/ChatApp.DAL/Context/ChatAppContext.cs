using ChatApp.DAL.Context.Extensions;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL.Context
{
    public class ChatAppContext : DbContext
    {
        public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<UserChats> UserChats => Set<UserChats>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<BlobImage> BlobImages => Set<BlobImage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();

            modelBuilder.Seed();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var newEntries = ChangeTracker.Entries()
                .Where(entryEntity => entryEntity is { State: EntityState.Added, Entity: BaseEntity })
                .Select(entryEntity => entryEntity.Entity as BaseEntity);

            foreach (var newEntry in newEntries)
            {
                newEntry!.CreatedAt = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
