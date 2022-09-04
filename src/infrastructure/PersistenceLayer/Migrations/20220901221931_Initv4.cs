using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class Initv4 : Migration
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
                name: "UserRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkActiveTill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegistrations", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRegistrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "UserRegistrations",
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
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false),
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
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Eshop", null },
                    { 8001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "PC chairs", 8001 }
                });

            migrationBuilder.InsertData(
                table: "UserRegistrations",
                columns: new[] { "Id", "Changed", "Code", "Created", "Deleted", "LinkActiveTill" },
                values: new object[] { 1, null, "some hash haha ha ha ha haaaaaaaaaa", new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Admin" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile devices and accessories", 1 },
                    { 3, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "PC and accessories", 1 },
                    { 4, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Printers and accessories", 1 },
                    { 5, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "PC chairs and accessories", 1 },
                    { 8000, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Gaming chairs", 8001 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Email", "IsActive", "Name", "PasswordHash", "PasswordSalt", "RegistrationId", "Surname", "UserName" },
                values: new object[] { 1, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "some@email.com", true, "Admin", new byte[] { 0, 160, 26, 174, 216, 87, 36, 244, 67, 159, 76, 3, 164, 80, 202, 65, 54, 153, 92, 237, 64, 247, 73, 186, 199, 173, 98, 179, 207, 204, 202, 112, 228, 97, 226, 72, 81, 252, 70, 8, 38, 64, 181, 100, 61, 198, 205, 197, 43, 44, 102, 131, 159, 248, 74, 165, 212, 237, 38, 232, 4, 187, 241, 95 }, new byte[] { 160, 140, 37, 170, 187, 16, 94, 136, 36, 28, 76, 111, 97, 228, 227, 62, 119, 139, 35, 84, 132, 161, 111, 167, 170, 75, 154, 105, 153, 70, 184, 26, 176, 153, 206, 217, 158, 30, 136, 217, 20, 83, 80, 127, 239, 255, 57, 29, 43, 27, 41, 53, 246, 197, 125, 229, 164, 93, 128, 58, 72, 173, 97, 66, 58, 9, 129, 74, 43, 89, 243, 49, 156, 54, 232, 30, 181, 161, 65, 255, 138, 35, 19, 110, 141, 98, 139, 44, 65, 227, 185, 249, 140, 228, 38, 40, 186, 128, 36, 224, 29, 71, 176, 154, 177, 131, 166, 9, 216, 226, 73, 92, 35, 162, 225, 235, 90, 182, 56, 153, 166, 123, 120, 165, 155, 47, 62, 129 }, 1, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[,]
                {
                    { 1001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile Phones", 2 },
                    { 1002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile cases", 2 },
                    { 1003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile adapters", 2 },
                    { 2001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Graphic cards", 3 },
                    { 2002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Disks", 3 },
                    { 2005, null, new DateTime(2022, 9, 2, 0, 19, 31, 539, DateTimeKind.Local).AddTicks(9880), null, "", "Notebooks", 3 },
                    { 2006, null, new DateTime(2022, 9, 2, 0, 19, 31, 539, DateTimeKind.Local).AddTicks(9907), null, "", "PCs", 3 },
                    { 2007, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Headphones", 3 },
                    { 2009, null, new DateTime(2022, 9, 2, 0, 19, 31, 539, DateTimeKind.Local).AddTicks(9914), null, "", "Webcams", 3 },
                    { 2010, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mouses", 3 },
                    { 2011, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Keyboards", 3 },
                    { 2012, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Monitors", 3 },
                    { 2013, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Microphones", 3 },
                    { 7000, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Laser printers", 4 },
                    { 7001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Ink printers", 4 },
                    { 7002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "3D printers", 4 },
                    { 7003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Tank printers", 4 },
                    { 7004, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Printers accessories", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[,]
                {
                    { 2003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "SSD", 2002 },
                    { 2004, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "HDD", 2002 },
                    { 3000, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Headphones with microphone", 2007 },
                    { 3001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Headsets", 2007 },
                    { 3002, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Bluetooth headsets", 2007 },
                    { 3003, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Bluetooth headphones", 2007 },
                    { 4000, null, new DateTime(2022, 9, 2, 0, 19, 31, 539, DateTimeKind.Local).AddTicks(9910), null, "", "Notebook adapters", 2005 },
                    { 4001, null, new DateTime(2022, 9, 2, 0, 19, 31, 539, DateTimeKind.Local).AddTicks(9912), null, "", "Notebook bags", 2005 },
                    { 5000, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Bluetooth keyboards", 2011 },
                    { 5001, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Gaming keyboards", 2011 },
                    { 6000, null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Bent monitors", 2012 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegistrationId",
                table: "Users",
                column: "RegistrationId",
                unique: true);
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
                name: "UserRegistrations");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
