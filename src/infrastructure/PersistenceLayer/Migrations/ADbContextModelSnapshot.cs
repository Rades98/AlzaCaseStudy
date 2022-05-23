﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenceLayer.Database;

#nullable disable

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(ADbContext))]
    partial class ADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImgUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("076d49af-6bc0-4dda-84ab-473c9f72bf60"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Realy cool stuff",
                            ImgUri = "http://www.someuri.sf/smth-cool",
                            Name = "Something cool",
                            Price = 250m
                        },
                        new
                        {
                            Id = new Guid("36faa1fb-88bc-4664-bc94-0ffa86e048a4"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Realy cool and cheap stuff",
                            ImgUri = "http://www.someuri.sf/smth-cool",
                            Name = "Something way cooler",
                            Price = 250m
                        },
                        new
                        {
                            Id = new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 1",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 2",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 3",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 4",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 5",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 6",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 7",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 8",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 9",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 10",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 11",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 12",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 13",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 14",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 15",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 16",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 18",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 17",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 19",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 20",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("48be6036-a2a8-42cb-bbdf-b23277a3fedf"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 21",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("77e795e2-e959-4b79-9278-5dcdfb74eb6b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 22",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("44d8560a-996b-49ee-a149-0148075dad46"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 23",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("2351cfb2-0d6d-4578-a9e2-0ec2ae5016d1"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 24",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("a5ea6a5a-5316-4722-a009-8cc4ef1779c0"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 25",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("c68d7767-9c7b-4fd4-8833-17ecde007165"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 26",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("13fd5fb3-f452-4105-b431-0a36605d1b43"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 27",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("5f1be375-cec9-475e-96cd-d99d8dd40688"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 28",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("08c0db85-a7d1-46de-8ed0-4215a5c73f30"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 29",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("f1803ebd-4458-47a1-a1bc-861bc69cfd87"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 30",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("daba5ec9-99c7-4505-83c5-f4a5350769d3"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 31",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("6b3ae464-c9a9-4e22-9448-88733707af0a"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 32",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("ce3f1caa-b272-404b-b604-69aa5e475371"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 33",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("b13fad29-28f9-4f34-ab86-e4620af3837f"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 34",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("b88f7f89-e1ce-4103-a733-42674bbf7d50"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 35",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("bc3c489e-0604-4f33-bdaf-1ae6fd1a7e9b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 36",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("f19577a4-7211-4db7-a8f9-a9ce272fff9e"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 37",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("ba8ae4a3-9b30-4f11-a501-499a80fe810b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 38",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("956460ee-5b90-4865-88c4-fb8e24c1be35"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 39",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("ea2ed07b-7017-4e28-90ea-7fd941c8dfe3"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 40",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("6a33a7d9-c490-4068-a6ed-d1a7ec7ff74e"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 41",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("b1c48db4-3ca6-4c9c-a4d7-4a239f82ef3a"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 42",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("3cebfb4d-fc88-4432-9e54-f5b5d2861df1"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 43",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("093ce8c4-0910-42cf-b5c4-95b21107a371"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 44",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("fe8d06d2-c22a-47c3-ad9e-88cd9bba309b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 45",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("288147d8-3a74-4025-918d-deadabad1580"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 46",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("b4cbdffb-7ab0-4622-a97f-8d369c45d1ac"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 47",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("fd4abd72-677e-4f64-840c-26a8d29ecab9"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 48",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("522ba220-4511-4978-913a-fcc8692c8c94"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 49",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("53a01ec6-10fc-4977-8e4e-b8422e1f7481"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "Test pagination data",
                            ImgUri = "http://www.pagination.xx/pag",
                            Name = "Pagination test item 50",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varbinary(64)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Email = "some@email.com",
                            Name = "Admin",
                            PasswordHash = new byte[] { 58, 60, 39, 66, 35, 163, 16, 219, 190, 168, 24, 104, 12, 208, 49, 205, 168, 66, 66, 164, 225, 222, 99, 202, 15, 168, 150, 166, 31, 98, 133, 198, 252, 52, 215, 236, 38, 82, 196, 179, 221, 124, 221, 197, 215, 214, 58, 99, 2, 98, 187, 200, 124, 196, 174, 11, 118, 130, 204, 108, 130, 172, 62, 154 },
                            PasswordSalt = new byte[] { 170, 109, 30, 10, 224, 39, 40, 167, 36, 239, 220, 27, 246, 192, 18, 152, 103, 195, 14, 126, 139, 194, 240, 91, 40, 189, 212, 158, 31, 141, 92, 237, 61, 132, 181, 156, 110, 34, 223, 218, 53, 89, 252, 103, 224, 73, 54, 26, 176, 68, 87, 213, 62, 112, 198, 95, 11, 140, 152, 149, 4, 22, 247, 224, 170, 246, 213, 151, 95, 252, 114, 129, 243, 217, 190, 69, 109, 155, 18, 180, 101, 239, 203, 175, 229, 116, 85, 215, 88, 197, 76, 179, 76, 76, 13, 64, 195, 80, 27, 247, 101, 163, 57, 188, 15, 79, 36, 103, 171, 205, 152, 175, 212, 248, 87, 18, 186, 83, 148, 255, 106, 225, 91, 8, 212, 158, 52, 218 },
                            Surname = "Admin",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7cfd3e28-c6ed-48b9-8d08-424751e77eaf"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserRoleRelationEntity", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleRelation");
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserRoleRelationEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Users.UserRoleEntity", "Role")
                        .WithMany("UserRelations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Entities.Users.UserEntity", "User")
                        .WithMany("RoleRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserEntity", b =>
                {
                    b.Navigation("RoleRelations");
                });

            modelBuilder.Entity("DomainLayer.Entities.Users.UserRoleEntity", b =>
                {
                    b.Navigation("UserRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
