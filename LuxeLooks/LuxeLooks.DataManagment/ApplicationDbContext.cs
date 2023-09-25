using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
using LuxeLooks.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var workFactor = 12;
            var salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("1025556478955466Admin445", salt);

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eab"),
                RoleName = "Admin",
                NormalizedRoleName = "ADMIN"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "alsemkovbn@gmail.com",
                PasswordSalt = salt,
                PasswordHash = hashedPassword,
                RefreshToken = null,
                RefreshTokenExpiryTime = DateTime.UtcNow, 
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton",
                Name = "SUPER BAGGY JEANS",
                Price = 129,
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850",
                Type = ProductType.Trousers
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"),
                RoleName = "Resident",
                NormalizedRoleName = "RESIDENT"
            });
            
        }
    }
}