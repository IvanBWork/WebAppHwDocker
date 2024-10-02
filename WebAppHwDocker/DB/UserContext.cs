using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHwDocker.Models;

namespace WebAppHwDocker.DB
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public UserContext()
        {

        }

        public UserContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UH8NEM4;Initial Catalog = UserDb;TrustServerCertificate=True;Trusted_Connection=True")
                .UseLazyLoadingProxies().LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(x => x.Id).HasName("user_pk");

                entity.Property(x => x.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.Property(x => x.Password).HasColumnName("password");
                entity.Property(x => x.Salt).HasColumnName("salt");

                entity.Property(x => x.RoleId).HasConversion<int>();

                entity.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(x => x.RoleId).HasConversion<int>();
                entity.HasData(Enum.GetValues(typeof(RoleId)).Cast<RoleId>().Select(x => new Role() { RoleId = x, Name = x.ToString() }));
            });
        }
    }
}
