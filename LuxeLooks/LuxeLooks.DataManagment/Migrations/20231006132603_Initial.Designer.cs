﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LuxeLooks.DataManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LuxeLooks.DataManagment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231006132603_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LuxeLooks.Domain.Entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<List<Guid>>("ProductsIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LuxeLooks.Domain.Entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsForKids")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForMen")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("792aa8cf-6c55-4b89-90de-e76738426c99"),
                            Description = "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850",
                            IsForKids = false,
                            IsForMen = true,
                            Name = "SUPER BAGGY JEANS",
                            Price = 129m,
                            Type = 11
                        },
                        new
                        {
                            Id = new Guid("d99d07ef-440d-43ce-bc17-a2ea845a4b99"),
                            Description = "Flat Mary Jane shoes. Available in several colours. Patent effect. Chunky sole. Buckled front strap.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1473/240/022/1473240022_2_1_8.jpg?t=1692269215615&imwidth=375",
                            IsForKids = false,
                            IsForMen = false,
                            Name = "CHUNKY SOLE FLAT SHOES",
                            Price = 149m,
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("79f9e39b-2b5b-4702-8418-fe9a1e8aa367"),
                            Description = "Oversized fit wide-leg low-rise baggy jeans with a five-pocket design, belt loops, a zip fly and top button fastening and faded details. Made from cotton.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7688/309/427/7688309427_2_1_8.jpg?t=1691508453560&imwidth=375",
                            IsForKids = false,
                            IsForMen = false,
                            Name = "ДЖИНСЫ ОВЕРСАЙЗ СВОБОДНОГО КРОЯ",
                            Price = 129m,
                            Type = 11
                        },
                        new
                        {
                            Id = new Guid("73d0c984-a31c-45a2-aaf7-40d3c5257cc7"),
                            Description = "Стильная куртка для мальчика из коллекции OUTERWEAR BOY JUNIOR станет идеальным выбором для повседневного отдыхам в холодное время года. Мембранная куртка оснащена флисовой подкладкой, светоотражающими элементами икарманами для любимых мелочей. Рукава отделаны эластичной манжетой, которая сохранит тепло в холодное время года.",
                            ImageUrl = "https://buslik.by/upload/resize_cache/iblock/a17/486_568_1/ld3wu2gwzmuhvkb6i1uam369xu4n5ow6.jpg",
                            IsForKids = true,
                            IsForMen = true,
                            Name = "Куртка для мальчика OUTERWEAR BOY JUNIOR",
                            Price = 104.9m,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("184b6f9c-42d1-450f-9526-b7748d6378e8"),
                            Description = "Short black dress with gathered detail in the centre, a boat neck and tie detail.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/1/p/7393/409/800/7393409800_2_1_8.jpg?t=1695910228791&imwidth=850",
                            IsForKids = false,
                            IsForMen = false,
                            Name = "КОРОТКОЕ ПЛАТЬЕ СО СБОРКОЙ",
                            Price = 89.99m,
                            Type = 13
                        },
                        new
                        {
                            Id = new Guid("58c26146-c77f-4424-b733-0fec26a43ce4"),
                            Description = "Platform sandals. Available in several colours. Wide paper straps on the instep. Jute sole.Platform height: 6 cm. Name ",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/1/1/p/1812/240/040/1812240040_2_1_8.jpg?t=1685434047342&imwidth=850",
                            IsForKids = false,
                            IsForMen = false,
                            Price = 119m,
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("5e32b108-1546-461a-ad31-cd07d244123c"),
                            Description = "Джинсовые шорты с высокой посадкой, шлевками и необработанной кромкой. Застегиваются на молнию и пуговицу.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4691/301/800/4691301800_2_1_8.jpg?t=1678879499635&imwidth=850",
                            IsForKids = false,
                            IsForMen = false,
                            Name = "DENIM SHORTS",
                            Price = 99m,
                            Type = 7
                        },
                        new
                        {
                            Id = new Guid("541cf1b2-1478-42fc-a486-ae2f348803d9"),
                            Description = "Укороченная рубашка из 100% хлопка. Короткие рукава, классический воротник. Застегивается на пуговицы.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/1/p/4471/327/250/4471327250_2_1_8.jpg?t=1683820029841&imwidth=850",
                            IsForKids = false,
                            IsForMen = false,
                            Name = "FASHIONABLE SHIRT",
                            Price = 89.99m,
                            Type = 8
                        },
                        new
                        {
                            Id = new Guid("ed65b4cf-3fe9-4f85-8cb6-adb8b19f65cf"),
                            Description = "Прорезиненные сандалии STWD с широким ремешком. Модель представлена в нескольких расцветках. Высота подошвы: 2,5 см.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2683/140/002/2683140002_2_1_8.jpg?t=1691480808944&imwidth=850",
                            IsForKids = false,
                            IsForMen = true,
                            Name = "STWD RUBBER SANDALS",
                            Price = 69.99m,
                            Type = 10
                        },
                        new
                        {
                            Id = new Guid("1fead8fc-6f01-4c24-843c-349a1ee21f4f"),
                            Description = " Retro-style plimsoll trainers available in various colours. Contrast details. Rubberised sole. Lace-up fastening.\nSTARFIT®. Flexible technical insole made of polyurethane composite foam, designed to offer greater comfort.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/1/2/p/2273/240/004/2273240004_2_1_8.jpg?t=1693303144091&imwidth=850",
                            IsForKids = false,
                            IsForMen = true,
                            Name = "RETRO SNEAKERS",
                            Price = 119m,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("96a41272-c1bc-4673-b672-f5b3e2092a96"),
                            Description = "верх 96% акрил 3% полиэстер 1% метал.нить / подкладка 100% полиэстер",
                            ImageUrl = "https://boomkids.by/media/img/mc/lfd236_1.jpg",
                            IsForKids = true,
                            IsForMen = false,
                            Name = "HAT FOR GIRL",
                            Price = 44.9m,
                            Type = 14
                        },
                        new
                        {
                            Id = new Guid("59ffc5a7-d86b-4946-a6bd-98d1ff6f6e96"),
                            Description = "машинная стирка, зауженная талия, прямой крой штанин, ткань устойчива к образованию пятен с водо-и грязеотталкивающим покрытием (Teflon),регулируемый пояс, не регулируется по длинне, застежка на крючок и планку.",
                            ImageUrl = "https://boomkids.by/media/img/next/194361_1.jpg",
                            IsForKids = true,
                            IsForMen = true,
                            Name = "Trousers for boy",
                            Price = 54.99m,
                            Type = 11
                        },
                        new
                        {
                            Id = new Guid("ca69339f-bd92-4099-a3e4-b46ab016c74a"),
                            Description = "С сердцем на бегунке и устойчивым к появлению пятен тефлоновым покрытием.",
                            ImageUrl = "https://boomkids.by/media/img/next/321926_1.jpg",
                            IsForKids = true,
                            IsForMen = false,
                            Name = "Sundress for girls",
                            Price = 48.99m,
                            Type = 13
                        },
                        new
                        {
                            Id = new Guid("ba880b9e-fdc9-41d7-a1a1-e2a0d62ae99d"),
                            Description = "Basic hoodie available in several colours, featuring an STWD logo. Made of cotton.",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7592/517/712/7592517712_2_1_8.jpg?t=1690994251463&imwidth=850",
                            IsForKids = false,
                            IsForMen = true,
                            Name = "LOGO HOODIE",
                            Price = 119m,
                            Type = 5
                        });
                });

            modelBuilder.Entity("LuxeLooks.Domain.Entity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NormalizedRoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eab"),
                            NormalizedRoleName = "ADMIN",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("6ce6e84b-f0ac-40d3-a5a9-f48362c18b2f"),
                            NormalizedRoleName = "RESIDENT",
                            RoleName = "Resident"
                        });
                });

            modelBuilder.Entity("LuxeLooks.Domain.Entity.Subscribe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("LuxeLooks.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1ec0b7e-ee08-4a5f-86f9-be6bedf4a3e9"),
                            Email = "alsemkovbn@gmail.com",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "$2a$12$1iuxV06MFJXFe8UqoBksyeVn58LfCpXONGiXoOPYSPy82D33L2kzu",
                            PasswordSalt = "$2a$12$1iuxV06MFJXFe8UqoBksye",
                            RefreshTokenExpiryTime = new DateTime(2023, 10, 6, 13, 26, 3, 208, DateTimeKind.Utc).AddTicks(1187),
                            RoleId = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"),
                            UserName = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
