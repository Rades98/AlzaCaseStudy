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

                    b.HasIndex("OrderCode")
                        .IsUnique();

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

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductDetailEntity", b =>
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

                    b.Property<Guid?>("ProductDetailInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductCode")
                        .IsUnique();

                    b.ToTable("ProductDetails", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductDetailInfoEntity", b =>
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

                    b.Property<string>("DetailedDescription")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailId")
                        .IsUnique();

                    b.ToTable("ProductDetailInfos", (string)null);
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

                    b.Property<Guid>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailId");

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
                            PasswordHash = new byte[] { 72, 179, 69, 224, 178, 170, 47, 46, 203, 59, 175, 80, 224, 7, 241, 24, 101, 0, 180, 81, 255, 175, 44, 214, 44, 117, 77, 181, 138, 167, 75, 203, 175, 136, 130, 76, 25, 196, 11, 106, 1, 222, 109, 26, 130, 169, 204, 245, 178, 213, 60, 18, 167, 221, 138, 67, 1, 32, 81, 23, 4, 86, 79, 203 },
                            PasswordSalt = new byte[] { 37, 6, 150, 4, 193, 18, 6, 244, 228, 181, 129, 132, 241, 135, 74, 242, 197, 121, 33, 108, 191, 116, 108, 170, 15, 208, 148, 40, 178, 139, 83, 55, 21, 173, 111, 106, 53, 123, 241, 119, 207, 53, 75, 3, 192, 151, 200, 32, 255, 114, 74, 129, 84, 219, 138, 196, 83, 131, 102, 79, 237, 154, 245, 252, 252, 235, 50, 53, 148, 0, 55, 120, 157, 87, 175, 205, 39, 14, 234, 96, 228, 128, 9, 223, 97, 186, 58, 251, 181, 61, 182, 95, 89, 107, 139, 234, 67, 142, 116, 32, 247, 38, 55, 233, 88, 156, 2, 86, 51, 181, 109, 133, 1, 179, 180, 195, 78, 192, 134, 132, 154, 191, 32, 45, 175, 214, 15, 147 },
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

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductDetailEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Product.ProductCategoryEntity", "ProductCategory")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductDetailInfoEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Product.ProductDetailEntity", "ProductDetail")
                        .WithOne("ProductDetailInfo")
                        .HasForeignKey("DomainLayer.Entities.Product.ProductDetailInfoEntity", "ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductEntity", b =>
                {
                    b.HasOne("DomainLayer.Entities.Product.ProductDetailEntity", "ProductDetail")
                        .WithMany("Products")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");
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

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("DomainLayer.Entities.Product.ProductDetailEntity", b =>
                {
                    b.Navigation("ProductDetailInfo");

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
