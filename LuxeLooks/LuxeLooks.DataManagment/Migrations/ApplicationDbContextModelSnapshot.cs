﻿// <auto-generated />
using System;
using System.Collections.Generic;
using LuxeLooks.DataManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LuxeLooks.DataManagment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("24ebd2df-c6c6-49ee-921e-4d59cb0ba177"),
                            Description = "Super baggy fit jeans with a five-pocket design, belt loops, and a zip fly and top button fastening. Made from 100% cotton",
                            ImageUrl = "https://static.pullandbear.net/2/photos//2023/I/0/2/p/7688/526/427/03/7688526427_2_6_8.jpg?t=1689251224432&imwidth=850",
                            Name = "SUPER BAGGY JEANS",
                            Price = 129m,
                            Type = 10
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
                            Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"),
                            NormalizedRoleName = "RESIDENT",
                            RoleName = "Resident"
                        });
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
                            Id = new Guid("05250889-ca59-4d4c-a302-0221be79c2af"),
                            Email = "alsemkovbn@gmail.com",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "$2a$12$b/iCnoXXsMX0GmuzP3zqruUbvuIF6.WwvW7RstIpguD/bSA/l9xzq",
                            PasswordSalt = "$2a$12$b/iCnoXXsMX0GmuzP3zqru",
                            RefreshTokenExpiryTime = new DateTime(2023, 9, 25, 17, 52, 25, 2, DateTimeKind.Utc).AddTicks(8081),
                            RoleId = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6abe"),
                            UserName = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
