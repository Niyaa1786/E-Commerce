using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var adminRoleId = 1;
            var customerRoleId = 2;

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            var hasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = 1,
                UserName = "admin@assembly.com",
                NormalizedUserName = "ADMIN@ASSEMBLY.COM",
                Email = "admin@assembly.com",
                NormalizedEmail = "ADMIN@ASSEMBLY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin@123");

            var customerUser = new User
            {
                Id = 2,
                UserName = "customer@assembly.com",
                NormalizedUserName = "CUSTOMER@ASSEMBLY.COM",
                Email = "customer@assembly.com",
                NormalizedEmail = "CUSTOMER@ASSEMBLY.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            customerUser.PasswordHash = hasher.HashPassword(customerUser, "customer@123");

            modelBuilder.Entity<User>().HasData(adminUser, customerUser);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = adminRoleId, UserId = 1 },
                new IdentityUserRole<int> { RoleId = customerRoleId, UserId = 2 }
            );
        }
    }
}