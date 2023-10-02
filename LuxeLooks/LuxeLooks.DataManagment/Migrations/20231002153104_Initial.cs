using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuxeLooks.DataManagment.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ProductsIds = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsForMen = table.Column<bool>(type: "boolean", nullable: false),
                    IsForKids = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    NormalizedRoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsForKids", "IsForMen", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { new Guid("0a3e4e15-debc-4e52-9cba-2cd874fadb6b"), "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850", false, true, "LOGO HOODIE", 119m, 5 },
                    { new Guid("1ef25a84-69cc-44b3-a7fc-e5b27c902852"), "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850", false, true, "STWD RUBBER SANDALS", 69.99m, 10 },
                    { new Guid("1f5b4b74-a205-4151-ae92-af61f3e6b6f5"), "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850", false, true, "SUPER BAGGY JEANS", 129m, 11 },
                    { new Guid("22fd7889-8c22-4c19-ae57-1e30de57e73b"), "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.", "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg", true, true, "Куртка для мальчика OUTERWEAR BOY JUNIOR", 104.9m, 0 },
                    { new Guid("32fa97c1-d303-4c43-ab7d-48f0eb847e82"), "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375", false, false, "CHUNKY SOLE FLAT SHOES", 149m, 2 },
                    { new Guid("49acb3f1-f7aa-40f8-8a30-da7958ea14fa"), "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850", false, false, null, 119m, 2 },
                    { new Guid("5c5038c0-55b1-4fcb-aae4-5b3cd4120fcf"), "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.", "https://boomkids.by/media/img/next/194361_1.jpg", true, true, "Trousers for boy", 54.99m, 11 },
                    { new Guid("5c9da7ae-bfef-451d-b0e1-df5b80b76f88"), "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375", false, false, "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ", 129m, 11 },
                    { new Guid("86289e02-bf7b-4fb9-bd06-68582456713e"), "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850", false, false, "DENIM SHORTS", 99m, 7 },
                    { new Guid("8d57506e-8dbe-45d2-b7d5-883cd246344a"), "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер", "https://boomkids.by/media/img/mc/lfd236_1.jpg", true, false, "HAT FOR GIRL", 44.9m, 14 },
                    { new Guid("9b9656a7-edd1-4d80-b492-1c0d89ccc657"), "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.", "https://boomkids.by/media/img/next/321926_1.jpg", true, false, "Sundress for girls", 48.99m, 13 },
                    { new Guid("a04c0bd7-4562-4162-9b09-0b8a54bfd7d3"), "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850", false, false, "FASHIONABLE SHIRT", 89.99m, 8 },
                    { new Guid("d737c806-2db4-4839-8871-7d85668e8495"), "Short black dress with gathered detail in the centre, a boat neck and tie detail.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850", false, false, "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ", 89.99m, 13 },
                    { new Guid("e0250f13-9492-4df1-9de2-0767451985de"), " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850", false, true, "RETRO SNEAKERS", 119m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NormalizedRoleName", "RoleName" },
                values: new object[] { new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eab"), "ADMIN", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("3fd2e46e-d8ba-4039-b9e0-c21ae065b935"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$3XwHuKBI6FAt3zeT6gVY..QGBvKM5Wdo6E6HDPlb8l340KTLCYXI.", "$2a$12$3XwHuKBI6FAt3zeT6gVY..", null, new DateTime(2023, 10, 2, 15, 31, 3, 993, DateTimeKind.Utc).AddTicks(9252), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
