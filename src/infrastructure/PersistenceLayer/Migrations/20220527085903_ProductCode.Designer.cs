﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenceLayer.Database;

#nullable disable

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(ADbContext))]
    [Migration("20220527085903_ProductCode")]
    partial class ProductCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderEntity", b =>
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

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderItemEntity", b =>
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

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderStatusEntity", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("27f83608-434a-4f4b-8315-ff711a97bff4"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "New"
                        },
                        new
                        {
                            Id = new Guid("93623d0a-914e-4252-9c1f-89563b4f9ee2"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Created"
                        },
                        new
                        {
                            Id = new Guid("c958ddec-c8c3-410d-8fb3-7bba41b9cdd8"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "WaitingForPayment"
                        },
                        new
                        {
                            Id = new Guid("91ba34e8-3bf7-4168-9e59-bb68642f602e"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "InExpedition"
                        },
                        new
                        {
                            Id = new Guid("953ff38d-ba59-41fe-9246-594d6af35b1f"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Delivered"
                        });
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductCategoryEntity", b =>
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
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ParentProductCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentProductCategoryId");

                    b.ToTable("ProductCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Eshop"
                        },
                        new
                        {
                            Id = new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Mobile Devices and accessories",
                            ParentProductCategoryId = new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b")
                        },
                        new
                        {
                            Id = new Guid("ce94ae71-1dd0-40f4-a89b-cf70ba3d9e3b"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Mobile Phones",
                            ParentProductCategoryId = new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62")
                        },
                        new
                        {
                            Id = new Guid("a6312a0b-30c2-40b5-a55a-39c2203f301a"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Cases",
                            ParentProductCategoryId = new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62")
                        },
                        new
                        {
                            Id = new Guid("8b1db412-7d98-4cd0-bad6-4a7c70b235b1"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Adapters",
                            ParentProductCategoryId = new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62")
                        },
                        new
                        {
                            Id = new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "PC and accessories",
                            ParentProductCategoryId = new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b")
                        },
                        new
                        {
                            Id = new Guid("3f91a56d-57e5-4079-9e23-e6064502e447"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Graphic cards",
                            ParentProductCategoryId = new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde")
                        },
                        new
                        {
                            Id = new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "Disks",
                            ParentProductCategoryId = new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde")
                        },
                        new
                        {
                            Id = new Guid("cc99e4b0-af43-4e5e-8bf6-ec3c0a6af943"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "SSD",
                            ParentProductCategoryId = new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254")
                        },
                        new
                        {
                            Id = new Guid("fea68386-0816-492f-9d1a-15aedc8c38ce"),
                            Created = new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local),
                            Description = "",
                            Name = "HDD",
                            ParentProductCategoryId = new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254")
                        });
                });

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

                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products", (string)null);
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
                            PasswordHash = new byte[] { 173, 194, 44, 174, 22, 136, 76, 85, 178, 222, 22, 59, 216, 121, 118, 222, 97, 134, 184, 52, 155, 63, 29, 64, 14, 172, 35, 94, 11, 46, 253, 167, 88, 50, 44, 109, 170, 171, 91, 11, 202, 93, 15, 211, 126, 244, 216, 188, 43, 77, 112, 50, 187, 61, 245, 189, 106, 180, 171, 38, 134, 155, 161, 183 },
                            PasswordSalt = new byte[] { 140, 97, 192, 66, 247, 16, 155, 189, 44, 216, 169, 24, 137, 177, 126, 197, 119, 70, 127, 25, 191, 13, 167, 141, 77, 153, 199, 9, 76, 175, 133, 185, 145, 97, 164, 230, 66, 217, 13, 197, 209, 216, 5, 81, 28, 214, 9, 19, 233, 254, 42, 38, 218, 43, 228, 176, 104, 178, 194, 149, 122, 121, 111, 2, 47, 54, 34, 30, 177, 40, 69, 224, 146, 227, 64, 174, 6, 238, 62, 91, 214, 156, 252, 72, 122, 55, 76, 152, 161, 152, 239, 250, 214, 130, 6, 213, 211, 3, 14, 191, 128, 135, 247, 220, 102, 139, 61, 48, 242, 32, 114, 136, 81, 21, 89, 197, 10, 157, 188, 143, 178, 243, 195, 225, 62, 6, 232, 89 },
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

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Orders.OrderStatusEntity", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderItemEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Orders.OrderEntity", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Entities.Product.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductCategoryEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Product.ProductCategoryEntity", "ParentProductCategory")
                        .WithMany("ChildrenCategories")
                        .HasForeignKey("ParentProductCategoryId");

                    b.Navigation("ParentProductCategory");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Product.ProductCategoryEntity", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
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

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderEntity", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DomainLayer.Entities.Orders.OrderStatusEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductCategoryEntity", b =>
                {
                    b.Navigation("ChildrenCategories");

                    b.Navigation("Products");
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
