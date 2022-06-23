using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class InitV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOrderEditable = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentProductCategoryId",
                        column: x => x.ParentProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTypeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusesLocalized",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusesLocalized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusesLocalized_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStatusesLocalized_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoriesLocalized",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoriesLocalized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoriesLocalized_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoriesLocalized_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ProductDetailInfoId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRelation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRelation", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoleRelation_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleRelation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailInfos_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailsLocalized",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailsLocalized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailsLocalized_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetailsLocalized_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetailInfosLocalized",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetailInfoId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetailInfosLocalized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetailInfosLocalized_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetailInfosLocalized_ProductDetailInfos_ProductDetailInfoId",
                        column: x => x.ProductDetailInfoId,
                        principalTable: "ProductDetailInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Changed", "Code", "Created", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "cs", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Čeština" },
                    { 2, null, "en", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "English" },
                    { 3, null, "sk", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Slovenčina" },
                    { 4, null, "pl", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Polski" },
                    { 5, null, "de", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Deutsch" },
                    { 6, null, "fe", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Français" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Info" },
                    { 2, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Error" },
                    { 3, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Hint" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "IsOrderEditable", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, true, "New" },
                    { 2, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, true, "Created" },
                    { 3, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, false, "WaitingForPayment" },
                    { 4, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, false, "InExpedition" },
                    { 5, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, false, "Delivered" },
                    { 6, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, false, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Eshop", null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Email", "Name", "PasswordHash", "PasswordSalt", "Surname", "UserName" },
                values: new object[] { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "some@email.com", "Admin", new byte[] { 167, 79, 24, 120, 211, 60, 241, 108, 239, 251, 200, 174, 19, 98, 97, 27, 18, 117, 161, 149, 5, 107, 148, 111, 222, 172, 216, 245, 160, 94, 254, 100, 47, 224, 225, 11, 10, 160, 11, 50, 247, 39, 255, 222, 203, 164, 67, 200, 19, 135, 18, 212, 206, 144, 234, 156, 124, 157, 15, 238, 84, 54, 189, 180 }, new byte[] { 16, 136, 234, 228, 134, 172, 23, 250, 136, 65, 106, 186, 132, 47, 225, 29, 48, 215, 176, 71, 45, 71, 248, 99, 195, 82, 68, 157, 160, 117, 200, 51, 221, 169, 231, 35, 123, 124, 90, 241, 141, 12, 153, 173, 160, 51, 242, 249, 31, 133, 98, 151, 82, 195, 93, 75, 160, 85, 202, 20, 205, 202, 130, 178, 232, 139, 190, 152, 96, 6, 53, 145, 85, 112, 11, 191, 47, 217, 49, 37, 9, 185, 1, 244, 144, 60, 207, 230, 72, 35, 128, 140, 154, 50, 34, 130, 234, 211, 174, 97, 246, 248, 149, 77, 235, 91, 187, 149, 250, 136, 134, 79, 197, 12, 194, 96, 26, 129, 80, 195, 98, 105, 15, 235, 143, 50, 51, 3 }, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { 2, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile Devices and accessories", 1 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { 3, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "PC and accessories", 1 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[,]
                {
                    { 1001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile Phones", 2 },
                    { 1002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Cases", 2 },
                    { 1003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Adapters", 2 },
                    { 2001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Graphic cards", 3 },
                    { 2002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Disks", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { 2003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "SSD", 2002 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { 2004, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "HDD", 2002 });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LanguageId",
                table: "Messages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusesLocalized_LanguageId",
                table: "OrderStatusesLocalized",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusesLocalized_OrderStatusId",
                table: "OrderStatusesLocalized",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentProductCategoryId",
                table: "ProductCategories",
                column: "ParentProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoriesLocalized_LanguageId",
                table: "ProductCategoriesLocalized",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoriesLocalized_ProductCategoryId",
                table: "ProductCategoriesLocalized",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailInfos_ProductDetailId",
                table: "ProductDetailInfos",
                column: "ProductDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailInfosLocalized_LanguageId",
                table: "ProductDetailInfosLocalized",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailInfosLocalized_ProductDetailInfoId",
                table: "ProductDetailInfosLocalized",
                column: "ProductDetailInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCategoryId",
                table: "ProductDetails",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCode",
                table: "ProductDetails",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailsLocalized_LanguageId",
                table: "ProductDetailsLocalized",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailsLocalized_ProductDetailId",
                table: "ProductDetailsLocalized",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelation_UserId",
                table: "UserRoleRelation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderStatusesLocalized");

            migrationBuilder.DropTable(
                name: "ProductCategoriesLocalized");

            migrationBuilder.DropTable(
                name: "ProductDetailInfosLocalized");

            migrationBuilder.DropTable(
                name: "ProductDetailsLocalized");

            migrationBuilder.DropTable(
                name: "UserRoleRelation");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductDetailInfos");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
