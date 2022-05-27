using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class ProductDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImgUri",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "ProductDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_ProductDetailId");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 133, 6, 137, 18, 141, 96, 83, 12, 146, 77, 101, 15, 206, 241, 70, 7, 250, 36, 146, 158, 213, 211, 211, 79, 201, 144, 14, 57, 241, 63, 199, 199, 165, 72, 233, 166, 77, 26, 175, 147, 253, 227, 142, 121, 90, 184, 206, 5, 17, 187, 5, 47, 79, 248, 21, 121, 229, 201, 224, 67, 75, 187, 107 }, new byte[] { 107, 102, 39, 73, 221, 61, 210, 77, 158, 109, 41, 202, 216, 47, 163, 2, 238, 206, 130, 144, 238, 114, 188, 107, 217, 177, 60, 31, 34, 230, 155, 74, 195, 77, 20, 178, 23, 17, 29, 194, 75, 68, 251, 95, 110, 31, 34, 184, 28, 215, 241, 69, 144, 141, 9, 124, 38, 228, 235, 14, 222, 255, 231, 180, 37, 38, 220, 215, 211, 123, 214, 248, 2, 114, 101, 49, 109, 188, 87, 24, 86, 122, 177, 253, 112, 115, 46, 1, 167, 79, 99, 32, 16, 24, 244, 158, 71, 15, 245, 4, 113, 65, 190, 164, 155, 107, 183, 89, 39, 1, 43, 110, 204, 94, 129, 252, 212, 24, 197, 232, 190, 141, 186, 116, 155, 65, 124, 187 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCategoryId",
                table: "ProductDetails",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCode",
                table: "ProductDetails",
                column: "ProductCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "ProductDetailId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUri",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 194, 44, 174, 22, 136, 76, 85, 178, 222, 22, 59, 216, 121, 118, 222, 97, 134, 184, 52, 155, 63, 29, 64, 14, 172, 35, 94, 11, 46, 253, 167, 88, 50, 44, 109, 170, 171, 91, 11, 202, 93, 15, 211, 126, 244, 216, 188, 43, 77, 112, 50, 187, 61, 245, 189, 106, 180, 171, 38, 134, 155, 161, 183 }, new byte[] { 140, 97, 192, 66, 247, 16, 155, 189, 44, 216, 169, 24, 137, 177, 126, 197, 119, 70, 127, 25, 191, 13, 167, 141, 77, 153, 199, 9, 76, 175, 133, 185, 145, 97, 164, 230, 66, 217, 13, 197, 209, 216, 5, 81, 28, 214, 9, 19, 233, 254, 42, 38, 218, 43, 228, 176, 104, 178, 194, 149, 122, 121, 111, 2, 47, 54, 34, 30, 177, 40, 69, 224, 146, 227, 64, 174, 6, 238, 62, 91, 214, 156, 252, 72, 122, 55, 76, 152, 161, 152, 239, 250, 214, 130, 6, 213, 211, 3, 14, 191, 128, 135, 247, 220, 102, 139, 61, 48, 242, 32, 114, 136, 81, 21, 89, 197, 10, 157, 188, 143, 178, 243, 195, 225, 62, 6, 232, 89 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
