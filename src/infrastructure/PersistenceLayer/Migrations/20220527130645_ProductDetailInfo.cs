using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class ProductDetailInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductDetailInfoId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductDetailInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 72, 179, 69, 224, 178, 170, 47, 46, 203, 59, 175, 80, 224, 7, 241, 24, 101, 0, 180, 81, 255, 175, 44, 214, 44, 117, 77, 181, 138, 167, 75, 203, 175, 136, 130, 76, 25, 196, 11, 106, 1, 222, 109, 26, 130, 169, 204, 245, 178, 213, 60, 18, 167, 221, 138, 67, 1, 32, 81, 23, 4, 86, 79, 203 }, new byte[] { 37, 6, 150, 4, 193, 18, 6, 244, 228, 181, 129, 132, 241, 135, 74, 242, 197, 121, 33, 108, 191, 116, 108, 170, 15, 208, 148, 40, 178, 139, 83, 55, 21, 173, 111, 106, 53, 123, 241, 119, 207, 53, 75, 3, 192, 151, 200, 32, 255, 114, 74, 129, 84, 219, 138, 196, 83, 131, 102, 79, 237, 154, 245, 252, 252, 235, 50, 53, 148, 0, 55, 120, 157, 87, 175, 205, 39, 14, 234, 96, 228, 128, 9, 223, 97, 186, 58, 251, 181, 61, 182, 95, 89, 107, 139, 234, 67, 142, 116, 32, 247, 38, 55, 233, 88, 156, 2, 86, 51, 181, 109, 133, 1, 179, 180, 195, 78, 192, 134, 132, 154, 191, 32, 45, 175, 214, 15, 147 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailInfos_ProductDetailId",
                table: "ProductDetailInfos",
                column: "ProductDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetailInfos");

            migrationBuilder.DropColumn(
                name: "ProductDetailInfoId",
                table: "ProductDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 104, 181, 193, 108, 25, 237, 186, 60, 44, 112, 86, 243, 233, 242, 101, 171, 32, 100, 193, 92, 109, 153, 89, 38, 68, 91, 226, 7, 176, 202, 56, 24, 229, 71, 72, 151, 124, 129, 82, 225, 213, 145, 194, 147, 107, 78, 243, 178, 32, 39, 140, 189, 243, 184, 62, 12, 248, 169, 116, 49, 208, 185, 225 }, new byte[] { 254, 23, 18, 98, 167, 252, 54, 250, 104, 67, 251, 246, 68, 0, 210, 35, 225, 112, 232, 249, 234, 114, 202, 204, 134, 135, 22, 67, 131, 186, 228, 174, 133, 131, 249, 25, 114, 98, 31, 21, 130, 103, 151, 181, 146, 122, 18, 17, 135, 159, 106, 99, 83, 152, 36, 9, 8, 175, 70, 94, 5, 131, 17, 26, 164, 171, 163, 160, 53, 179, 118, 226, 197, 20, 81, 248, 110, 60, 207, 29, 157, 10, 111, 82, 199, 52, 64, 27, 124, 89, 220, 103, 234, 149, 42, 5, 76, 4, 152, 13, 71, 249, 81, 89, 200, 129, 90, 38, 156, 29, 52, 214, 49, 52, 123, 86, 224, 175, 100, 153, 167, 203, 12, 237, 92, 203, 245, 241 } });
        }
    }
}
