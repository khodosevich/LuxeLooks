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
        public DbSet<Subscribe> Subscribes { get; set; }


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
                Type = ProductType.Trousers,
                IsForKids = false,
                IsForMen = true
            });
            
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "CHUNKY SOLE FLAT SHOES",
                Description =
                    "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.",
                Price = 149,
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375",
                Type = ProductType.Shoes,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Name = 
                    "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ",
                Description = "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.",
                Price = 129,
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375",
                Type = ProductType.Trousers,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.",
                Name = "Куртка для мальчика OUTERWEAR BOY JUNIOR",
                Price = new decimal(104.90),
                ImageUrl =
                    "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg",
                Type = ProductType.Jacket,
                IsForKids = true,
                IsForMen = true
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