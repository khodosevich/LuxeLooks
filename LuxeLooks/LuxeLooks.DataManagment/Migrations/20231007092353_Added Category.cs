using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuxeLooks.DataManagment.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("184b6f9c-42d1-450f-9526-b7748d6378e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1fead8fc-6f01-4c24-843c-349a1ee21f4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("541cf1b2-1478-42fc-a486-ae2f348803d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58c26146-c77f-4424-b733-0fec26a43ce4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59ffc5a7-d86b-4946-a6bd-98d1ff6f6e96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e32b108-1546-461a-ad31-cd07d244123c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73d0c984-a31c-45a2-aaf7-40d3c5257cc7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("792aa8cf-6c55-4b89-90de-e76738426c99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79f9e39b-2b5b-4702-8418-fe9a1e8aa367"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96a41272-c1bc-4673-b672-f5b3e2092a96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba880b9e-fdc9-41d7-a1a1-e2a0d62ae99d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca69339f-bd92-4099-a3e4-b46ab016c74a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d99d07ef-440d-43ce-bc17-a2ea845a4b99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed65b4cf-3fe9-4f85-8cb6-adb8b19f65cf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6ce6e84b-f0ac-40d3-a5a9-f48362c18b2f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1ec0b7e-ee08-4a5f-86f9-be6bedf4a3e9"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsForKids", "IsForMen", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { new Guid("00b9d41f-2185-427c-9690-db5e05747bef"), "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850", false, false, "DENIM SHORTS", 99m, 7 },
                    { new Guid("12f17e7b-3816-4738-9d26-5a7402ed90a0"), " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850", false, true, "RETRO SNEAKERS", 119m, 1 },
                    { new Guid("2ea3fe40-d5ff-49dd-902b-7f066b82a005"), "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850", false, false, null, 119m, 2 },
                    { new Guid("30b26231-23f8-44ac-8d90-45b16fcd5bd7"), "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375", false, false, "CHUNKY SOLE FLAT SHOES", 149m, 2 },
                    { new Guid("3712d032-614a-4e0e-9b4c-a4897c53f972"), "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850", false, true, "LOGO HOODIE", 119m, 5 },
                    { new Guid("50b60ea3-b160-4549-88ed-2bed4aea8466"), "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.", "https://boomkids.by/media/img/next/321926_1.jpg", true, false, "Sundress for girls", 48.99m, 13 },
                    { new Guid("84b33be9-521f-4434-8423-23fecead741d"), "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375", false, false, "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ", 129m, 11 },
                    { new Guid("aa00185a-9fc0-4301-a207-d9df38bcc988"), "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.", "https://boomkids.by/media/img/next/194361_1.jpg", true, true, "Trousers for boy", 54.99m, 11 },
                    { new Guid("b2cf4fd6-77b6-4729-9eb9-c603fdb430e0"), "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.", "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg", true, true, "Куртка для мальчика OUTERWEAR BOY JUNIOR", 104.9m, 0 },
                    { new Guid("b8c54e4e-f3e4-49fa-8853-3cf8b2404013"), "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850", false, true, "STWD RUBBER SANDALS", 69.99m, 10 },
                    { new Guid("c0af9056-32bb-4fe1-b964-f3eaa70c3b81"), "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер", "https://boomkids.by/media/img/mc/lfd236_1.jpg", true, false, "HAT FOR GIRL", 44.9m, 14 },
                    { new Guid("d2d40746-b019-487c-92f9-c836bafe4155"), "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850", false, false, "FASHIONABLE SHIRT", 89.99m, 8 },
                    { new Guid("de0dbd65-1626-465c-b5e4-607f14556049"), "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850", false, true, "SUPER BAGGY JEANS", 129m, 11 },
                    { new Guid("e5400f02-c3cc-4738-a2a4-5cd6a90a4b9c"), "Short black dress with gathered detail in the centre, a boat neck and tie detail.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850", false, false, "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ", 89.99m, 13 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NormalizedRoleName", "RoleName" },
                values: new object[] { new Guid("6c163236-1979-41a3-b736-8e2496b596f3"), "RESIDENT", "Resident" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("069ad039-b49a-467e-aef6-0f3837afe7b9"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$ffaDwJYJZXoClwumMtDGu.vmFkDzUoBOsXAS7g6L5GkTZ19w5tZJO", "$2a$12$ffaDwJYJZXoClwumMtDGu.", null, new DateTime(2023, 10, 7, 9, 23, 53, 235, DateTimeKind.Utc).AddTicks(172), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00b9d41f-2185-427c-9690-db5e05747bef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12f17e7b-3816-4738-9d26-5a7402ed90a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2ea3fe40-d5ff-49dd-902b-7f066b82a005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30b26231-23f8-44ac-8d90-45b16fcd5bd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3712d032-614a-4e0e-9b4c-a4897c53f972"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50b60ea3-b160-4549-88ed-2bed4aea8466"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84b33be9-521f-4434-8423-23fecead741d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa00185a-9fc0-4301-a207-d9df38bcc988"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2cf4fd6-77b6-4729-9eb9-c603fdb430e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8c54e4e-f3e4-49fa-8853-3cf8b2404013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0af9056-32bb-4fe1-b964-f3eaa70c3b81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d2d40746-b019-487c-92f9-c836bafe4155"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de0dbd65-1626-465c-b5e4-607f14556049"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5400f02-c3cc-4738-a2a4-5cd6a90a4b9c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6c163236-1979-41a3-b736-8e2496b596f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("069ad039-b49a-467e-aef6-0f3837afe7b9"));

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
                values: new object[] { new Guid("6ce6e84b-f0ac-40d3-a5a9-f48362c18b2f"), "RESIDENT", "Resident" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("d1ec0b7e-ee08-4a5f-86f9-be6bedf4a3e9"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$1iuxV06MFJXFe8UqoBksyeVn58LfCpXONGiXoOPYSPy82D33L2kzu", "$2a$12$1iuxV06MFJXFe8UqoBksye", null, new DateTime(2023, 10, 6, 13, 26, 3, 208, DateTimeKind.Utc).AddTicks(1187), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
        }
    }
}
