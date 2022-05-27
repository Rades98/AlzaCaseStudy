using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class OrderCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 104, 181, 193, 108, 25, 237, 186, 60, 44, 112, 86, 243, 233, 242, 101, 171, 32, 100, 193, 92, 109, 153, 89, 38, 68, 91, 226, 7, 176, 202, 56, 24, 229, 71, 72, 151, 124, 129, 82, 225, 213, 145, 194, 147, 107, 78, 243, 178, 32, 39, 140, 189, 243, 184, 62, 12, 248, 169, 116, 49, 208, 185, 225 }, new byte[] { 254, 23, 18, 98, 167, 252, 54, 250, 104, 67, 251, 246, 68, 0, 210, 35, 225, 112, 232, 249, 234, 114, 202, 204, 134, 135, 22, 67, 131, 186, 228, 174, 133, 131, 249, 25, 114, 98, 31, 21, 130, 103, 151, 181, 146, 122, 18, 17, 135, 159, 106, 99, 83, 152, 36, 9, 8, 175, 70, 94, 5, 131, 17, 26, 164, 171, 163, 160, 53, 179, 118, 226, 197, 20, 81, 248, 110, 60, 207, 29, 157, 10, 111, 82, 199, 52, 64, 27, 124, 89, 220, 103, 234, 149, 42, 5, 76, 4, 152, 13, 71, 249, 81, 89, 200, 129, 90, 38, 156, 29, 52, 214, 49, 52, 123, 86, 224, 175, 100, 153, 167, 203, 12, 237, 92, 203, 245, 241 } });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 133, 6, 137, 18, 141, 96, 83, 12, 146, 77, 101, 15, 206, 241, 70, 7, 250, 36, 146, 158, 213, 211, 211, 79, 201, 144, 14, 57, 241, 63, 199, 199, 165, 72, 233, 166, 77, 26, 175, 147, 253, 227, 142, 121, 90, 184, 206, 5, 17, 187, 5, 47, 79, 248, 21, 121, 229, 201, 224, 67, 75, 187, 107 }, new byte[] { 107, 102, 39, 73, 221, 61, 210, 77, 158, 109, 41, 202, 216, 47, 163, 2, 238, 206, 130, 144, 238, 114, 188, 107, 217, 177, 60, 31, 34, 230, 155, 74, 195, 77, 20, 178, 23, 17, 29, 194, 75, 68, 251, 95, 110, 31, 34, 184, 28, 215, 241, 69, 144, 141, 9, 124, 38, 228, 235, 14, 222, 255, 231, 180, 37, 38, 220, 215, 211, 123, 214, 248, 2, 114, 101, 49, 109, 188, 87, 24, 86, 122, 177, 253, 112, 115, 46, 1, 167, 79, 99, 32, 16, 24, 244, 158, 71, 15, 245, 4, 113, 65, 190, 164, 155, 107, 183, 89, 39, 1, 43, 110, 204, 94, 129, 252, 212, 24, 197, 232, 190, 141, 186, 116, 155, 65, 124, 187 } });
        }
    }
}
