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
        public DbSet<Category> Categories { get; set; }


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
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = Guid.NewGuid(),
                RoleName = "Resident",
                NormalizedRoleName = "RESIDENT"
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
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Short black dress with gathered detail in the centre, a boat neck and tie detail.",
                Name = "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ",
                Price = new decimal(89.99),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850",
                Type = ProductType.Dress,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ",
                Price = new decimal(119),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850",
                Type = ProductType.Shoes,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.",
                Name = "DENIM SHORTS",
                Price = new decimal(99),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850",
                Type = ProductType.Shorts,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.",
                Name = "FASHIONABLE SHIRT",
                Price = new decimal(89.99),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850",
                Type = ProductType.Shirt,
                IsForKids = false,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.",
                Name = "STWD RUBBER SANDALS",
                Price = new decimal(69.99),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850",
                Type = ProductType.Flipflops,
                IsForKids = false,
                IsForMen = true
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                   " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.",
                Name = "RETRO SNEAKERS",
                Price = new decimal(119),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850",
                Type = ProductType.Sneakers,
                IsForKids = false,
                IsForMen = true
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер",
                Name = "HAT FOR GIRL",
                Price = new decimal(44.9),
                ImageUrl =
                    "https://boomkids.by/media/img/mc/lfd236_1.jpg",
                Type = ProductType.Hat,
                IsForKids = true,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.",
                Name = "Trousers for boy",
                Price = new decimal(54.99),
                ImageUrl =
                    "https://boomkids.by/media/img/next/194361_1.jpg",
                Type = ProductType.Trousers,
                IsForKids = true,
                IsForMen = true
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.",
                Name = "Sundress for girls",
                Price = new decimal(48.99),
                ImageUrl =
                    "https://boomkids.by/media/img/next/321926_1.jpg",
                Type = ProductType.Dress,
                IsForKids = true,
                IsForMen = false
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = Guid.NewGuid(),
                Description =
                    "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.",
                Name = "LOGO HOODIE",
                Price = new decimal(119),
                ImageUrl =
                    "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850",
                Type = ProductType.Hoodie,
                IsForKids = false,
                IsForMen = true
            });
        }
    }
}