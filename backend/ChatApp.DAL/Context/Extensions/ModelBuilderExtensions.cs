using ChatApp.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DAL.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
        }
    }
}
