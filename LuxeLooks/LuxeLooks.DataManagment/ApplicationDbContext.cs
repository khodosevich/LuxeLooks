using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;
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

            // modelBuilder.Entity<User>().HasData(new User
            // {
            //     Id = Guid.NewGuid(),
            //     UserName = "Admin",
            //     NormalizedUserName = "ADMIN",
            //     Email = "alsemkovbn@gmail.com",
            //     PasswordSalt = salt,
            //     PasswordHash = hashedPassword,
            //     RefreshToken = null,
            //     RefreshTokenExpiryTime = DateTime.UtcNow, 
            // });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"),
                RoleName = "Resident",
                NormalizedRoleName = "RESIDENT"
            });

            // Определите структуру таблицы для User
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.NormalizedUserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordSalt)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.RefreshToken);
        }
    }
}