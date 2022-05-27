using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class ProductCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 195, 17, 46, 71, 227, 38, 7, 45, 96, 69, 255, 163, 3, 81, 211, 177, 239, 225, 242, 226, 146, 24, 209, 72, 82, 45, 230, 190, 122, 234, 222, 197, 221, 145, 70, 218, 26, 24, 253, 64, 178, 216, 67, 8, 245, 45, 31, 51, 0, 109, 86, 185, 118, 191, 147, 236, 79, 161, 93, 77, 96, 223, 221, 167 }, new byte[] { 255, 134, 50, 58, 169, 70, 149, 175, 237, 169, 137, 129, 4, 57, 233, 123, 9, 35, 245, 182, 102, 145, 78, 36, 162, 217, 42, 112, 101, 204, 7, 17, 248, 166, 64, 33, 76, 238, 120, 184, 85, 151, 68, 179, 233, 147, 188, 206, 225, 226, 82, 221, 103, 104, 163, 19, 34, 143, 240, 21, 215, 237, 147, 36, 203, 230, 35, 123, 145, 36, 45, 65, 108, 140, 152, 64, 153, 112, 172, 30, 79, 147, 179, 23, 125, 82, 201, 237, 160, 197, 120, 112, 223, 146, 20, 146, 140, 72, 95, 89, 17, 194, 177, 79, 165, 13, 232, 247, 151, 196, 141, 161, 172, 152, 217, 189, 233, 177, 50, 85, 23, 70, 123, 24, 167, 131, 226, 206 } });
        }
    }
}
