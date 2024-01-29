﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuxeLooks.DataManagment.Migrations
{
    /// <inheritdoc />
    public partial class Added_Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("138d569b-9765-4f17-bdec-3493fee8b8be"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1dd11197-b7a6-4088-b9d0-ea6132bfa3f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f4b1f52-39e8-4b2e-953a-dfb91dd7c0d6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3855d7dd-62c8-49bc-a469-b880c2faca4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45cebd9f-d6dc-4def-acc8-0a4e55faec55"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("490a00af-4417-41c1-b8f2-0f8bcc6b8dbc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49ca435e-6578-44aa-a2bb-9a1b833372ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ba107b6-7a2f-4193-83ee-6a946c21367f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b6306064-ef38-4183-9189-80b028f4ebe6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b87098f9-2522-426e-9bc9-3d3d174d55e7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bf2597c4-2b3c-415d-8540-5609a9a5cded"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6f10de3-7aef-4792-b41f-bc8fc16604d4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e1fda4df-1516-4be1-ad08-f3c7cd37b910"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9d4e1b7-ef69-4895-9869-8ba1e6a163b3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fc067e94-52f7-47e7-acdd-62ec1e1a76a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff489025-6bcd-406c-8e5a-519e07a27e2d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a5e6ae6-f534-4cfb-a60f-e23b6f8967e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1bfac646-a474-43d1-b1c0-466793c03e47"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("364a121b-194f-4daf-a1e2-17e2e9a163f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46c43469-397e-4cbe-9ef4-7412e9c78de1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d01e46f-29ad-416c-8e79-2db92e70ed3d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c58d5fd-1ba1-47ba-83c9-c7ffc9e2870b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c9a09e7-9489-4bb7-84ec-ac03e6f451f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74c77e86-3df2-4425-99d9-f7e3eace11ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("750d0c07-ccfd-487c-a2b8-2f570d2d2d64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b1aded0-d7a4-4280-b9d6-8561891b47ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aadf6762-cad2-4e99-92d3-cafbd29be46f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b3ee6ca1-af23-41a9-b567-4d765550c885"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b48fb129-ad41-4a05-9403-17849026cf4c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f46abe55-e6f7-4663-9fbd-a1a1f82e8011"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f272aa8d-d1f8-452e-9a7b-7c8153fa2885"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8bbdeb1-d7a0-4dad-b602-eafbfa212dd8"));

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "ProductType" },
                values: new object[,]
                {
                    { new Guid("0c961301-b9df-48b4-9cc4-33d392158be0"), "https://images.unsplash.com/photo-1628626126093-97c2c464ca5d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTF8fGZsaXAlMjBmbG9wc3xlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", 10 },
                    { new Guid("2c3530e4-6b92-418c-b51d-8a185b2f7d56"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3zQAlQ9cU3wJ2zQdNDy_Oj7msf0PZEtmoBg&usqp=CAU", 2 },
                    { new Guid("56772025-9f44-4f76-b020-16ff6982afdc"), "data:image/jpeg;base64,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", 12 },
                    { new Guid("588f0448-f8cc-4039-aa3c-6e20ecf4fa60"), "data:image/jpeg;base64,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", 7 },
                    { new Guid("64247d09-b079-415a-9bc6-f3a47a271b0a"), "https://images.unsplash.com/photo-1618354691792-d1d42acfd860?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGhhdHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", 14 },
                    { new Guid("7f9b57ab-15d4-4953-9e67-534457001299"), "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dHJvdXNlcnN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", 11 },
                    { new Guid("81894225-c1dc-4aee-a320-6be27bf7444e"), "data:image/jpeg;base64,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", 15 },
                    { new Guid("939e9322-658a-4310-9aab-76eee829efb8"), "data:image/jpeg;base64,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", 8 },
                    { new Guid("9b4d1b46-1b0e-4d0b-9cf9-e507305dd22f"), "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxASEhUSEhAPDxUVFRAQEA8PDQ8NDw8PFREWFhURFRUYHSggGBolGxUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKBQUFDgUFDisZExkrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIAOEA4QMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAAAAwECBAUGB//EADsQAAIBAgMFBgMGBQQDAAAAAAABAgMRBCExBRJBYXEiMlGBkbGhwdETQlKS4fAjcpOisgZjgvEUM0P/xAAUAQEAAAAAAAAAAAAAAAAAAAAA/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8A+4gAAAAAAAAAALqVorj5IzVMW+GXxYGuc0tWZ54vgl5syuTZDXH93A5Utq14YmUVLeg892S3lay0eqOzS2tF95OPTtI5W0KKUlV8Fuyfgr5Pp9RLkB6SGNpP78fN7vuMVeH44/mR5pIAPSvEQ/HD8yFyxtJffj5Pe9jz1gsB2au1oLupy/tXxMcMXUnK7draKOSV/cwXztqb6MLK3m+oG6njGl2lfmsmaKeKhLjbk8jlTd30LJAdkDmU6slo/J5o0wxi0llz4foBqAAAAAAAAAAAAAAAAAAAAMGMxf3Y+Dz5D8ZW3UcyjG7cn0AvSvxGbpaMSGwCwEbxFwCUeDzv6NGH/wABR7jy/C87dH8jcAHNnFrVWPOf6q2t9i6a3oR3lUbUq/2LsrZpWz18j2hnxGBo1LOpRpVGtHUpQqNX8LrIDyX+ldqfb7/bhK1soVvtreDbtlx9D0kKEnw9cka6GFp08oU6dNcVCEYJ+iGAJpUEub+CGvLJa+xZJ9PcmwFIxsXAjICyaFpeOpawboD8JibZPThyf0OgcaUTfgK+8t16r4rxA1AAAAAAAAAAAAABWpOyuWMOKrXduC9wMuJm2xsI2QuhG7uUxte2S1AtUrFYXYuhRerNcVYCqiTYsQBAAAEWIsSAEWC4BYCHIjMskTYCm6SoliN4CUiLkpNkyWdgBK4hzcJKa4ZPmuP75FlUs36jHG69wOnCaaTWaeaLHK2VW3W6b8eydUAAAAAAAAAABWKq7sW/TqciEteY7ada8t3gvcz0UBuw8bR6mGrHeqea9zorgjHb+IA2aIiwqSKqQDblGyt2xiiBAEgBBBIAQAAAXIJACLEpAADKaE4yru5+hopI5+1vu9QKRd2r8c/I3J2aMWDW8970NVaXuArFR3Zxksr5X56o7GHqb0U/XqcvGxvC61VmvIfgaunhK3rwA6IAAAAAAAAAefxcGpPndrzJwcrs1Y2F1zObg3aTA7NN3Zl/+howzM1Pv+oA4PNhe2Q+osmYHLMDbEsUpMuBBKQRRYBRKFb17DYgBBKKgSAAAABZIBsTnbW0XU6MWYdqd18mgF4Z7tO42XcTF4eSlTy8MwoSvBrwYGulnGwnCd1x/C/hqhtCRS1qnXL5r5gdShO6T8n1GGTDSs7ePuawAAAAIkSVno+jA52rOdj4bsk1ob5ysyMVS3k16dQL4J3QiHf9Q2XLJxeqyCPfA04juvoc+hnHzN2K0OdQ71gNdJ2dvHQeVqRzT5FoPJgTFky0KRL1e6+jAyYbT1NBnwmg9gQRLUGFTgwJBAtAACUyCYgNpow7VfZfl7m9HP2kvde4EbMp2SXjdlMJ35xHYJ3k+SsJwr/iy8/cDRRf0G11oxSVpND9UAy+jXVG6LurnPou6t4GrCzumvB2+Cf1AeAAAFamj6FilXRgcysMou5SepNF5gKtu1uUvciL7fqOxUc4y8JIzTdp3A0YvQww1N2Nuo/vQwYVdoDptZC6byY5aCFx6gWiXxHdfQrSQYx9kBGCWQ24vC90YkBDJqd0hllmgK03kBSkxtrgVLRKpkoByYjEUN+yWuduqTaXwGomPej1QGDZv3r8G7+QrA99vmb9pLcbsu9n58TJgo2z5gaK+UkxlN52KYlBvpR3n/2/AC1We5pq8orxG7NybT4pN9b5+5lSbe9LXguCNWEymuaa+fyA6AAAALr6MYKxDy8wOfxCJaOrK8QGYlXi/Upgae/JSei/y/fyHR0H4K24rZWun1TzAy7W+Rz8Is0b9qL6GKhqB0BEh70EsC9MpjnkXpC9oaALwvdQ5CML3V0HgVRemRFEUnmwFLJvqNixdVZl1oBM4kQZeIp5MDQikpdqP80fdF4ip96H88fcDfiqO/FrzXU5VOG6dsx4yh95eYGecbp8OZnj2ui7q+YyUt57vBa839CUswLRQ3DZzXJNi2x+BXab5W9X+gG0AAAE4ru+Y4XiF2WBh4lZlmxTdwG0nmOw8rStwf8AkIp6jKiy9uoFMe7tmHCLNsvWq729wd725FsH3QNi0EyGp5i6gFqQraOg6kI2jovMCmDXZRoM+D7iHrUCwmg831HGenlNoC2J1TLR0IxS7IU3kBamwrIgvJXQE0nkUt/Eh/MmFFl4rtx6/IDpGDaGI+5HzY/G19yN+LyX1ObTXEBkYpKyJiSgaAqjbgVk34v2RjsdDDRtFevrmA0AAAIaJADl1VZtC4mrGwzv4+5miAxDULgi8QObj1uy3lxyZfAyyNGPpb0X6o5mAqWlYDryeYVit8y9UApmfaT08zRTMm1Hn5AWwfcQ16ophl2UX4gMhqZX/wCw1U+JkrZTQGiqrxYqg8h3Az4figGl4Moi0QKrJjYvtRfNFKi0YvF1N1c3py5gJx2I358lkh1JZGGhHM30wLokqXiBXdu7eOXqdRIw4WneV+C+LNwAAAAAAAJxUbx6ZnPOq0cupC0mgGQZZC4jAJaujgVluz8/gegRyNp087/v96ga6Er5miZztn1Lq3gdCTAmmYdqPtLyN9M5+1O+vIDTh+6TxChoDAdTMWK7yZspmLaOVn09wNcDPHKTHUdBVTvegDGXiVLwAmVrXZzarbld8dF4I14ud1yTV+ZStDK6AXRga4IThoXzHOSvYCSaCcslx+C8RM25NQSu3ryR08PRUVbjxfiBeEUlZFgAAAAAAAAAy4ylpLyZqIkr5Ac9RLFpxs7FEwJRk2lC8TbETiFl5AcfBTtI60GcNvdl52Ovh5XQGuBztrd5eXudGBztrd5eXuBqpaBIKOiB6gMgY9qrs3N0EYdsSyUeaAfhn2U+RSvwfkWpd1BWWS5AXL0xMZXHRdlcDNLN7nC6f1H6q2n0K0o2z4sKtVIC8pKKM9JNyyV2/YjecnaObfh7nVwmGUF4t6v5LkBbD0FFeLer8WNAAAAAAAAAAAAAAABVeF1fw9jJJHQMdei1mnl4PgAt1LLmymKlaOdv0KbrTu3fwVskS435gcLFS7WltDq4NZGDa0bT6m3ZjbSA6MDmbV70f3xOokcraj7cV09wNlHQlhR0JjqA5ZI5GJlvTXX2OhjZ2VjDh43n0A2wWRM1kSQgE0tDQIpIegCeRw9oYnedl0OtXhdWvboculh06ltbXzA72xI2pR/5L+5m8y7Njamlzl7moAAAAAAAAAAAAAAAAAApVWTLgByMRUSa982RLFRSyTflZfE01qLu3ZvXg2ZMTB8Iz/pzfyAX9nvu7Rro0khGHfiqnnSmvkaftl4T/pz+gDDh46f8XVa8XyOz9pllGf5JHDr7Orzqb/bir5JQ/QDrUNC9LUzRo1UrWn+VlaNOrvNy30uHZaQD8cr2M1BpS4+hj2hWxEp7tNTstZKnvfGxVbNqPOSm34yjJgdeT6+haksv0OdDCSS7r/Ky6oVOG8ukZIDalm/1GWMKoVv9z0kNoUa613/gAzFytFswbPXauaMdCs1uxg5NtLNOPxWhTA4etG+/SmujjNeoHawXd837jxOEi1HNWzevUcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//9k=", 6 },
                    { new Guid("a50f6485-36c7-452b-9866-11c9df00340f"), "https://images.unsplash.com/photo-1608667508764-33cf0726b13a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHNuZWFrZXJzfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", 1 },
                    { new Guid("e2a39c34-a393-4652-b2d8-8f636a416278"), "https://images.unsplash.com/photo-1597843797221-e34b4a320b97?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDF8fHNvY2tzfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", 9 },
                    { new Guid("eb246cf6-a251-4ba8-b2d3-1af7806f8e91"), "https://images.unsplash.com/photo-1588850561407-ed78c282e89b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1936&q=80", 3 },
                    { new Guid("ef176922-8d03-4d1d-b9d8-9e1321bfff5e"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWzbxF7UfWhxC8tPkf21IP9zCUf2nSrabeag&usqp=CAU", 13 },
                    { new Guid("f15bd591-d5c5-44ec-8abb-909dc7aa0674"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyzhbt_2TLHtWvECeZCasO048-Po8Iy6bzamzuQUHuMQ&s", 4 },
                    { new Guid("f5c5b54a-b75a-4e05-a519-8833cd521e7e"), "https://www.stormtech.eu/cdn/shop/products/QX-1_FRONT_AzureBlue_e7c96d75-ab18-42d8-980f-7cda693e0516_2000x.jpg?v=1687562372", 0 },
                    { new Guid("fa17481c-4cb3-4886-af2f-5cfc6a9ae8b1"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbL75_XYFQJoAmH0EBtP05Db7xlo1bASetag&usqp=CAU", 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsForKids", "IsForMen", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { new Guid("11a10e5a-64e7-496a-93b1-03e91b74a256"), " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850", false, true, "RETRO SNEAKERS", 119m, 1 },
                    { new Guid("11ed55b5-b232-4d1e-ab4d-aa9b0c90d4fc"), "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850", false, false, null, 119m, 2 },
                    { new Guid("157bbb34-e979-4f63-96b2-20934372f3db"), "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850", false, true, "LOGO HOODIE", 119m, 5 },
                    { new Guid("22005f23-3f94-426c-8de0-79be3e9638b0"), "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850", false, true, "SUPER BAGGY JEANS", 129m, 11 },
                    { new Guid("2641917e-8cc7-4dae-8d96-7faf42f1aa43"), "Short black dress with gathered detail in the centre, a boat neck and tie detail.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850", false, false, "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ", 89.99m, 13 },
                    { new Guid("291255a8-3a6d-46af-9940-ac6c1e233acb"), "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер", "https://boomkids.by/media/img/mc/lfd236_1.jpg", true, false, "HAT FOR GIRL", 44.9m, 14 },
                    { new Guid("4243e970-2f11-4a19-8f0a-5fa0b05a6029"), "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850", false, true, "STWD RUBBER SANDALS", 69.99m, 10 },
                    { new Guid("42a1859c-39e3-44ca-bd10-b546687111af"), "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850", false, false, "DENIM SHORTS", 99m, 7 },
                    { new Guid("5a6b2a85-cfaa-4a2f-9464-89ebb15ed5bf"), "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375", false, false, "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ", 129m, 11 },
                    { new Guid("7a8bf101-727c-49b8-84b6-0e80d316107b"), "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.", "https://boomkids.by/media/img/next/194361_1.jpg", true, true, "Trousers for boy", 54.99m, 11 },
                    { new Guid("845401e0-c62c-46db-a7de-8d51544d40cd"), "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375", false, false, "CHUNKY SOLE FLAT SHOES", 149m, 2 },
                    { new Guid("c6a8861c-1839-42d3-ab70-ea66589bd698"), "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.", "https://boomkids.by/media/img/next/321926_1.jpg", true, false, "Sundress for girls", 48.99m, 13 },
                    { new Guid("f5e4d99d-487b-4909-8df4-0d92a101539f"), "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850", false, false, "FASHIONABLE SHIRT", 89.99m, 8 },
                    { new Guid("f7b33dd4-bab1-4360-97f2-e17ab5a86f05"), "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.", "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg", true, true, "Куртка для мальчика OUTERWEAR BOY JUNIOR", 104.9m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NormalizedRoleName", "RoleName" },
                values: new object[] { new Guid("81804b20-162a-496c-a41b-c49fd0ae9864"), "RESIDENT", "Resident" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("61622dc4-e0c4-4c8a-b1eb-9fed024b4025"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$ZJ1j2F8UK1/WsrkHZZFS0OAbZxCJDVCystUnvaacVn3EgBV.Xdu3q", "$2a$12$ZJ1j2F8UK1/WsrkHZZFS0O", null, new DateTime(2024, 1, 29, 13, 13, 38, 0, DateTimeKind.Utc).AddTicks(4253), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0c961301-b9df-48b4-9cc4-33d392158be0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2c3530e4-6b92-418c-b51d-8a185b2f7d56"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("56772025-9f44-4f76-b020-16ff6982afdc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("588f0448-f8cc-4039-aa3c-6e20ecf4fa60"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("64247d09-b079-415a-9bc6-f3a47a271b0a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7f9b57ab-15d4-4953-9e67-534457001299"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("81894225-c1dc-4aee-a320-6be27bf7444e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("939e9322-658a-4310-9aab-76eee829efb8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b4d1b46-1b0e-4d0b-9cf9-e507305dd22f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a50f6485-36c7-452b-9866-11c9df00340f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2a39c34-a393-4652-b2d8-8f636a416278"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb246cf6-a251-4ba8-b2d3-1af7806f8e91"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef176922-8d03-4d1d-b9d8-9e1321bfff5e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f15bd591-d5c5-44ec-8abb-909dc7aa0674"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5c5b54a-b75a-4e05-a519-8833cd521e7e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fa17481c-4cb3-4886-af2f-5cfc6a9ae8b1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11a10e5a-64e7-496a-93b1-03e91b74a256"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11ed55b5-b232-4d1e-ab4d-aa9b0c90d4fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("157bbb34-e979-4f63-96b2-20934372f3db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22005f23-3f94-426c-8de0-79be3e9638b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2641917e-8cc7-4dae-8d96-7faf42f1aa43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("291255a8-3a6d-46af-9940-ac6c1e233acb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4243e970-2f11-4a19-8f0a-5fa0b05a6029"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42a1859c-39e3-44ca-bd10-b546687111af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a6b2a85-cfaa-4a2f-9464-89ebb15ed5bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a8bf101-727c-49b8-84b6-0e80d316107b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("845401e0-c62c-46db-a7de-8d51544d40cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6a8861c-1839-42d3-ab70-ea66589bd698"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5e4d99d-487b-4909-8df4-0d92a101539f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7b33dd4-bab1-4360-97f2-e17ab5a86f05"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("81804b20-162a-496c-a41b-c49fd0ae9864"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61622dc4-e0c4-4c8a-b1eb-9fed024b4025"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "ProductType" },
                values: new object[,]
                {
                    { new Guid("138d569b-9765-4f17-bdec-3493fee8b8be"), "https://images.unsplash.com/photo-1624378439575-d8705ad7ae80?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dHJvdXNlcnN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60", 11 },
                    { new Guid("1dd11197-b7a6-4088-b9d0-ea6132bfa3f5"), "https://images.unsplash.com/photo-1597843797221-e34b4a320b97?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDF8fHNvY2tzfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", 9 },
                    { new Guid("1f4b1f52-39e8-4b2e-953a-dfb91dd7c0d6"), "https://images.unsplash.com/photo-1588850561407-ed78c282e89b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1936&q=80", 3 },
                    { new Guid("3855d7dd-62c8-49bc-a469-b880c2faca4b"), "https://images.unsplash.com/photo-1608667508764-33cf0726b13a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHNuZWFrZXJzfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60", 1 },
                    { new Guid("45cebd9f-d6dc-4def-acc8-0a4e55faec55"), "data:image/jpeg;base64,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", 7 },
                    { new Guid("490a00af-4417-41c1-b8f2-0f8bcc6b8dbc"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3zQAlQ9cU3wJ2zQdNDy_Oj7msf0PZEtmoBg&usqp=CAU", 2 },
                    { new Guid("49ca435e-6578-44aa-a2bb-9a1b833372ca"), "https://images.unsplash.com/photo-1618354691792-d1d42acfd860?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGhhdHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", 14 },
                    { new Guid("4ba107b6-7a2f-4193-83ee-6a946c21367f"), "data:image/jpeg;base64,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", 12 },
                    { new Guid("b6306064-ef38-4183-9189-80b028f4ebe6"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyzhbt_2TLHtWvECeZCasO048-Po8Iy6bzamzuQUHuMQ&s", 4 },
                    { new Guid("b87098f9-2522-426e-9bc9-3d3d174d55e7"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbL75_XYFQJoAmH0EBtP05Db7xlo1bASetag&usqp=CAU", 5 },
                    { new Guid("bf2597c4-2b3c-415d-8540-5609a9a5cded"), "data:image/jpeg;base64,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", 8 },
                    { new Guid("c6f10de3-7aef-4792-b41f-bc8fc16604d4"), "data:image/jpeg;base64,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", 15 },
                    { new Guid("e1fda4df-1516-4be1-ad08-f3c7cd37b910"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWzbxF7UfWhxC8tPkf21IP9zCUf2nSrabeag&usqp=CAU", 13 },
                    { new Guid("f9d4e1b7-ef69-4895-9869-8ba1e6a163b3"), "https://images.unsplash.com/photo-1628626126093-97c2c464ca5d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTF8fGZsaXAlMjBmbG9wc3xlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60", 10 },
                    { new Guid("fc067e94-52f7-47e7-acdd-62ec1e1a76a2"), "data:image/jpeg;base64,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", 6 },
                    { new Guid("ff489025-6bcd-406c-8e5a-519e07a27e2d"), "https://www.stormtech.eu/cdn/shop/products/QX-1_FRONT_AzureBlue_e7c96d75-ab18-42d8-980f-7cda693e0516_2000x.jpg?v=1687562372", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsForKids", "IsForMen", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { new Guid("0a5e6ae6-f534-4cfb-a60f-e23b6f8967e3"), "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер", "https://boomkids.by/media/img/mc/lfd236_1.jpg", true, false, "HAT FOR GIRL", 44.9m, 14 },
                    { new Guid("1bfac646-a474-43d1-b1c0-466793c03e47"), "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375", false, false, "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ", 129m, 11 },
                    { new Guid("364a121b-194f-4daf-a1e2-17e2e9a163f0"), "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850", false, true, "STWD RUBBER SANDALS", 69.99m, 10 },
                    { new Guid("46c43469-397e-4cbe-9ef4-7412e9c78de1"), "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.", "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg", true, true, "Куртка для мальчика OUTERWEAR BOY JUNIOR", 104.9m, 0 },
                    { new Guid("4d01e46f-29ad-416c-8e79-2db92e70ed3d"), "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850", false, true, "LOGO HOODIE", 119m, 5 },
                    { new Guid("6c58d5fd-1ba1-47ba-83c9-c7ffc9e2870b"), "Short black dress with gathered detail in the centre, a boat neck and tie detail.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850", false, false, "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ", 89.99m, 13 },
                    { new Guid("6c9a09e7-9489-4bb7-84ec-ac03e6f451f8"), "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850", false, false, null, 119m, 2 },
                    { new Guid("74c77e86-3df2-4425-99d9-f7e3eace11ba"), "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850", false, false, "FASHIONABLE SHIRT", 89.99m, 8 },
                    { new Guid("750d0c07-ccfd-487c-a2b8-2f570d2d2d64"), "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.", "https://boomkids.by/media/img/next/321926_1.jpg", true, false, "Sundress for girls", 48.99m, 13 },
                    { new Guid("7b1aded0-d7a4-4280-b9d6-8561891b47ab"), " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.", "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850", false, true, "RETRO SNEAKERS", 119m, 1 },
                    { new Guid("aadf6762-cad2-4e99-92d3-cafbd29be46f"), "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.", "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375", false, false, "CHUNKY SOLE FLAT SHOES", 149m, 2 },
                    { new Guid("b3ee6ca1-af23-41a9-b567-4d765550c885"), "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton", "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850", false, true, "SUPER BAGGY JEANS", 129m, 11 },
                    { new Guid("b48fb129-ad41-4a05-9403-17849026cf4c"), "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.", "https://boomkids.by/media/img/next/194361_1.jpg", true, true, "Trousers for boy", 54.99m, 11 },
                    { new Guid("f46abe55-e6f7-4663-9fbd-a1a1f82e8011"), "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.", "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850", false, false, "DENIM SHORTS", 99m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "NormalizedRoleName", "RoleName" },
                values: new object[] { new Guid("f272aa8d-d1f8-452e-9a7b-7c8153fa2885"), "RESIDENT", "Resident" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NormalizedUserName", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UserName" },
                values: new object[] { new Guid("f8bbdeb1-d7a0-4dad-b602-eafbfa212dd8"), "alsemkovbn@gmail.com", "ADMIN", "$2a$12$YElrO3v7oUhcsyczDWGfs./TrcQxQELkwenyhau6of9NvrbGqdoIm", "$2a$12$YElrO3v7oUhcsyczDWGfs.", null, new DateTime(2023, 10, 9, 11, 34, 45, 542, DateTimeKind.Utc).AddTicks(4920), new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"), "Admin" });
        }
    }
}
