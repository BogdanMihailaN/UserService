using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserServiceDbContext : DbContext
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "hashed_password_example",
                    FullName = "Admin User",
                    CreatedAt = new DateTime(2025, 3, 7),
                    UpdatedAt = new DateTime(2025, 3, 7),
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Username = "user1",
                    Email = "user1@example.com",
                    PasswordHash = "hashed_password_example",
                    FullName = "User One",
                    CreatedAt = new DateTime(2025, 3, 7),
                    UpdatedAt = new DateTime(2025, 3, 7),
                    IsActive = true
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Administrator role" },
                new Role { Id = 2, RoleName = "User", Description = "Standard user role" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 2 }
            );

            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress
                {
                    Id = 1,
                    UserId = 1,
                    AddressLine1 = "123 Admin St.",
                    AddressLine2 = "Suite 1",
                    City = "Admin City",
                    State = "Admin State",
                    PostalCode = "12345",
                    Country = "Admin Country"
                },
                new UserAddress
                {
                    Id = 2,
                    UserId = 2,
                    AddressLine1 = "456 User St.",
                    AddressLine2 = "Apt 2",
                    City = "User City",
                    State = "User State",
                    PostalCode = "67890",
                    Country = "User Country"
                }
            );
        }
    }
}