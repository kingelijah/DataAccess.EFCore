using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EditHistory> EditHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}