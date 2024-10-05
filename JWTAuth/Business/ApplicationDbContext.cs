using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Business
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the User entity to the right table and schema
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Info");

                entity.HasKey(e => e.UserName);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsRequired();
            });
        }
    }
}
