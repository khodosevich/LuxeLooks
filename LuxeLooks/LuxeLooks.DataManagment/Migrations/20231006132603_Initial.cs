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
                    { new Guid("184b6f9c-42d1-450f-9526-b7748d6378e8"), "Short black dress with gathered detail in the centre, a boat neck and tie detail.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850", false, false, "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ", 89.99m, 13 },
                    { new Guid("1fead8fc-6f01-4c24-843c-349a1ee21f4f"), " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850", false, true, "RETRO SNEAKERS", 119m, 1 },
                    { new Guid("541cf1b2-1478-42fc-a486-ae2f348803d9"), "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850", false, false, "FASHIONABLE SHIRT", 89.99m, 8 },
                    { new Guid("58c26146-c77f-4424-b733-0fec26a43ce4"), "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850", false, false, null, 119m, 2 },
                    { new Guid("59ffc5a7-d86b-4946-a6bd-98d1ff6f6e96"), "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.", "https://boomkids.by/media/img/next/194361_1.jpg", true, true, "Trousers for boy", 54.99m, 11 },
                    { new Guid("5e32b108-1546-461a-ad31-cd07d244123c"), "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850", false, false, "DENIM SHORTS", 99m, 7 },
                    { new Guid("73d0c984-a31c-45a2-aaf7-40d3c5257cc7"), "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.", "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg", true, true, "Куртка для мальчика OUTERWEAR BOY JUNIOR", 104.9m, 0 },
                    { new Guid("792aa8cf-6c55-4b89-90de-e76738426c99"), "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850", false, true, "SUPER BAGGY JEANS", 129m, 11 },
                    { new Guid("79f9e39b-2b5b-4702-8418-fe9a1e8aa367"), "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375", false, false, "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ", 129m, 11 },
                    { new Guid("96a41272-c1bc-4673-b672-f5b3e2092a96"), "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер", "https://boomkids.by/media/img/mc/lfd236_1.jpg", true, false, "HAT FOR GIRL", 44.9m, 14 },
                    { new Guid("ba880b9e-fdc9-41d7-a1a1-e2a0d62ae99d"), "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850", false, true, "LOGO HOODIE", 119m, 5 },
                    { new Guid("ca69339f-bd92-4099-a3e4-b46ab016c74a"), "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.", "https://boomkids.by/media/img/next/321926_1.jpg", true, false, "Sundress for girls", 48.99m, 13 },
                    { new Guid("d99d07ef-440d-43ce-bc17-a2ea845a4b99"), "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375", false, false, "CHUNKY SOLE FLAT SHOES", 149m, 2 },
                    { new Guid("ed65b4cf-3fe9-4f85-8cb6-adb8b19f65cf"), "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850", false, true, "STWD RUBBER SANDALS", 69.99m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NormalizedRoleName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eab"), "ADMIN", "Admin" },
                    { new Guid("6ce6e84b-f0ac-40d3-a5a9-f48362c18b2f"), "RESIDENT", "Resident" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("d1ec0b7e-ee08-4a5f-86f9-be6bedf4a3e9"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$1iuxV06MFJXFe8UqoBksyeVn58LfCpXONGiXoOPYSPy82D33L2kzu", "$2a$12$1iuxV06MFJXFe8UqoBksye", null, new DateTime(2023, 10, 6, 13, 26, 3, 208, DateTimeKind.Utc).AddTicks(1187), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
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
