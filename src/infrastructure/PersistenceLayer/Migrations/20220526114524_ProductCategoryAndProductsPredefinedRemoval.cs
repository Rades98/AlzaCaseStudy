﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class ProductCategoryAndProductsPredefinedRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("076d49af-6bc0-4dda-84ab-473c9f72bf60"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08c0db85-a7d1-46de-8ed0-4215a5c73f30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("093ce8c4-0910-42cf-b5c4-95b21107a371"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13fd5fb3-f452-4105-b431-0a36605d1b43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2351cfb2-0d6d-4578-a9e2-0ec2ae5016d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("288147d8-3a74-4025-918d-deadabad1580"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36faa1fb-88bc-4664-bc94-0ffa86e048a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3cebfb4d-fc88-4432-9e54-f5b5d2861df1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44d8560a-996b-49ee-a149-0148075dad46"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48be6036-a2a8-42cb-bbdf-b23277a3fedf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("522ba220-4511-4978-913a-fcc8692c8c94"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53a01ec6-10fc-4977-8e4e-b8422e1f7481"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5f1be375-cec9-475e-96cd-d99d8dd40688"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a33a7d9-c490-4068-a6ed-d1a7ec7ff74e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b3ae464-c9a9-4e22-9448-88733707af0a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77e795e2-e959-4b79-9278-5dcdfb74eb6b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("956460ee-5b90-4865-88c4-fb8e24c1be35"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5ea6a5a-5316-4722-a009-8cc4ef1779c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b13fad29-28f9-4f34-ab86-e4620af3837f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1c48db4-3ca6-4c9c-a4d7-4a239f82ef3a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4cbdffb-7ab0-4622-a97f-8d369c45d1ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b88f7f89-e1ce-4103-a733-42674bbf7d50"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba8ae4a3-9b30-4f11-a501-499a80fe810b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc3c489e-0604-4f33-bdaf-1ae6fd1a7e9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c68d7767-9c7b-4fd4-8833-17ecde007165"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ce3f1caa-b272-404b-b604-69aa5e475371"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("daba5ec9-99c7-4505-83c5-f4a5350769d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea2ed07b-7017-4e28-90ea-7fd941c8dfe3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1803ebd-4458-47a1-a1bc-861bc69cfd87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f19577a4-7211-4db7-a8f9-a9ce272fff9e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd4abd72-677e-4f64-840c-26a8d29ecab9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe8d06d2-c22a-47c3-ad9e-88cd9bba309b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Eshop", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 167, 1, 57, 72, 244, 223, 151, 83, 113, 161, 87, 21, 77, 92, 238, 13, 99, 251, 160, 26, 14, 159, 231, 46, 232, 213, 245, 169, 186, 146, 68, 131, 127, 244, 88, 150, 136, 237, 9, 53, 125, 172, 218, 28, 119, 53, 203, 105, 153, 178, 104, 235, 194, 182, 195, 33, 232, 94, 3, 193, 129, 33, 101, 61 }, new byte[] { 82, 207, 235, 114, 110, 208, 18, 198, 47, 219, 136, 72, 168, 42, 220, 145, 172, 114, 209, 8, 208, 102, 73, 76, 72, 127, 154, 145, 141, 3, 87, 95, 134, 9, 7, 7, 12, 120, 122, 27, 90, 161, 192, 14, 184, 128, 3, 49, 116, 156, 0, 110, 35, 126, 133, 210, 203, 166, 181, 172, 13, 88, 254, 14, 224, 50, 184, 102, 11, 219, 9, 46, 116, 117, 204, 161, 20, 56, 15, 177, 114, 47, 214, 107, 175, 44, 172, 98, 109, 71, 164, 168, 114, 132, 104, 182, 117, 57, 19, 184, 89, 241, 13, 163, 178, 196, 96, 36, 49, 5, 235, 33, 133, 197, 177, 65, 247, 225, 119, 137, 161, 31, 114, 61, 16, 127, 82, 76 } });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile Devices and accessories", new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "PC and accessories", new Guid("689beec2-0592-46fe-8fbe-12ebce0a458b") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[,]
                {
                    { new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Disks", new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde") },
                    { new Guid("3f91a56d-57e5-4079-9e23-e6064502e447"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Graphic cards", new Guid("2f3a0726-b1d8-49fc-bd31-79ad33f3bfde") },
                    { new Guid("8b1db412-7d98-4cd0-bad6-4a7c70b235b1"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Adapters", new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62") },
                    { new Guid("a6312a0b-30c2-40b5-a55a-39c2203f301a"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Cases", new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62") },
                    { new Guid("ce94ae71-1dd0-40f4-a89b-cf70ba3d9e3b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "Mobile Phones", new Guid("064a231d-26ab-4b3e-881b-f8898fccdf62") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { new Guid("cc99e4b0-af43-4e5e-8bf6-ec3c0a6af943"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "SSD", new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "Name", "ParentProductCategoryId" },
                values: new object[] { new Guid("fea68386-0816-492f-9d1a-15aedc8c38ce"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "", "HDD", new Guid("3f2ef91a-0c2f-4436-8b45-9fa9e3aa1254") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentProductCategoryId",
                table: "ProductCategories",
                column: "ParentProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("076d49af-6bc0-4dda-84ab-473c9f72bf60"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Realy cool stuff", "http://www.someuri.sf/smth-cool", "Something cool", 250m },
                    { new Guid("08c0db85-a7d1-46de-8ed0-4215a5c73f30"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 29", 0m },
                    { new Guid("093ce8c4-0910-42cf-b5c4-95b21107a371"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 44", 0m },
                    { new Guid("13fd5fb3-f452-4105-b431-0a36605d1b43"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 27", 0m },
                    { new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 16", 0m },
                    { new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 14", 0m },
                    { new Guid("2351cfb2-0d6d-4578-a9e2-0ec2ae5016d1"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 24", 0m },
                    { new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 10", 0m },
                    { new Guid("288147d8-3a74-4025-918d-deadabad1580"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 46", 0m },
                    { new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 3", 0m },
                    { new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 9", 0m },
                    { new Guid("36faa1fb-88bc-4664-bc94-0ffa86e048a4"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Realy cool and cheap stuff", "http://www.someuri.sf/smth-cool", "Something way cooler", 250m },
                    { new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 6", 0m },
                    { new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 1", 0m },
                    { new Guid("3cebfb4d-fc88-4432-9e54-f5b5d2861df1"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 43", 0m },
                    { new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 7", 0m },
                    { new Guid("44d8560a-996b-49ee-a149-0148075dad46"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 23", 0m },
                    { new Guid("48be6036-a2a8-42cb-bbdf-b23277a3fedf"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 21", 0m },
                    { new Guid("522ba220-4511-4978-913a-fcc8692c8c94"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 49", 0m },
                    { new Guid("53a01ec6-10fc-4977-8e4e-b8422e1f7481"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 50", 0m },
                    { new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 12", 0m },
                    { new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 8", 0m },
                    { new Guid("5f1be375-cec9-475e-96cd-d99d8dd40688"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 28", 0m },
                    { new Guid("6a33a7d9-c490-4068-a6ed-d1a7ec7ff74e"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 41", 0m },
                    { new Guid("6b3ae464-c9a9-4e22-9448-88733707af0a"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 32", 0m },
                    { new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 19", 0m },
                    { new Guid("77e795e2-e959-4b79-9278-5dcdfb74eb6b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 22", 0m },
                    { new Guid("956460ee-5b90-4865-88c4-fb8e24c1be35"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 39", 0m },
                    { new Guid("a5ea6a5a-5316-4722-a009-8cc4ef1779c0"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 25", 0m },
                    { new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 11", 0m },
                    { new Guid("b13fad29-28f9-4f34-ab86-e4620af3837f"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 34", 0m },
                    { new Guid("b1c48db4-3ca6-4c9c-a4d7-4a239f82ef3a"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 42", 0m },
                    { new Guid("b4cbdffb-7ab0-4622-a97f-8d369c45d1ac"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 47", 0m },
                    { new Guid("b88f7f89-e1ce-4103-a733-42674bbf7d50"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 35", 0m },
                    { new Guid("ba8ae4a3-9b30-4f11-a501-499a80fe810b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 38", 0m },
                    { new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 20", 0m },
                    { new Guid("bc3c489e-0604-4f33-bdaf-1ae6fd1a7e9b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 36", 0m },
                    { new Guid("c68d7767-9c7b-4fd4-8833-17ecde007165"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 26", 0m },
                    { new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 18", 0m },
                    { new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 13", 0m },
                    { new Guid("ce3f1caa-b272-404b-b604-69aa5e475371"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 33", 0m },
                    { new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 15", 0m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("daba5ec9-99c7-4505-83c5-f4a5350769d3"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 31", 0m },
                    { new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 5", 0m },
                    { new Guid("ea2ed07b-7017-4e28-90ea-7fd941c8dfe3"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 40", 0m },
                    { new Guid("f1803ebd-4458-47a1-a1bc-861bc69cfd87"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 30", 0m },
                    { new Guid("f19577a4-7211-4db7-a8f9-a9ce272fff9e"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 37", 0m },
                    { new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 2", 0m },
                    { new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 4", 0m },
                    { new Guid("fd4abd72-677e-4f64-840c-26a8d29ecab9"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 48", 0m },
                    { new Guid("fe8d06d2-c22a-47c3-ad9e-88cd9bba309b"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 45", 0m },
                    { new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Test pagination data", "http://www.pagination.xx/pag", "Pagination test item 17", 0m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 58, 60, 39, 66, 35, 163, 16, 219, 190, 168, 24, 104, 12, 208, 49, 205, 168, 66, 66, 164, 225, 222, 99, 202, 15, 168, 150, 166, 31, 98, 133, 198, 252, 52, 215, 236, 38, 82, 196, 179, 221, 124, 221, 197, 215, 214, 58, 99, 2, 98, 187, 200, 124, 196, 174, 11, 118, 130, 204, 108, 130, 172, 62, 154 }, new byte[] { 170, 109, 30, 10, 224, 39, 40, 167, 36, 239, 220, 27, 246, 192, 18, 152, 103, 195, 14, 126, 139, 194, 240, 91, 40, 189, 212, 158, 31, 141, 92, 237, 61, 132, 181, 156, 110, 34, 223, 218, 53, 89, 252, 103, 224, 73, 54, 26, 176, 68, 87, 213, 62, 112, 198, 95, 11, 140, 152, 149, 4, 22, 247, 224, 170, 246, 213, 151, 95, 252, 114, 129, 243, 217, 190, 69, 109, 155, 18, 180, 101, 239, 203, 175, 229, 116, 85, 215, 88, 197, 76, 179, 76, 76, 13, 64, 195, 80, 27, 247, 101, 163, 57, 188, 15, 79, 36, 103, 171, 205, 152, 175, 212, 248, 87, 18, 186, 83, 148, 255, 106, 225, 91, 8, 212, 158, 52, 218 } });
        }
    }
}