using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class OrderStatusCancel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[] { new Guid("b0b29346-d5c0-401a-8466-f0780686f072"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Canceled" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 26, 52, 166, 12, 40, 240, 14, 234, 93, 117, 202, 77, 212, 132, 55, 26, 16, 76, 210, 21, 122, 157, 40, 1, 143, 83, 73, 241, 141, 254, 222, 21, 202, 48, 156, 129, 20, 231, 46, 173, 174, 19, 17, 23, 153, 83, 72, 99, 3, 124, 141, 105, 108, 101, 212, 144, 16, 160, 187, 141, 33, 105, 178, 156 }, new byte[] { 166, 173, 76, 3, 86, 50, 139, 27, 115, 245, 202, 71, 84, 225, 244, 132, 71, 38, 156, 253, 196, 3, 229, 90, 53, 170, 195, 69, 137, 170, 168, 205, 61, 121, 240, 167, 130, 205, 73, 189, 195, 10, 56, 166, 196, 217, 67, 108, 74, 35, 55, 112, 202, 172, 100, 181, 130, 89, 251, 126, 153, 81, 129, 64, 137, 42, 111, 166, 58, 248, 67, 197, 43, 84, 134, 98, 67, 237, 144, 140, 50, 137, 134, 21, 201, 237, 103, 120, 122, 171, 209, 195, 229, 103, 155, 206, 224, 15, 112, 183, 218, 156, 250, 6, 40, 184, 247, 167, 138, 96, 165, 167, 125, 213, 227, 173, 58, 41, 228, 250, 28, 133, 229, 177, 19, 20, 18, 243 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("b0b29346-d5c0-401a-8466-f0780686f072"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 72, 179, 69, 224, 178, 170, 47, 46, 203, 59, 175, 80, 224, 7, 241, 24, 101, 0, 180, 81, 255, 175, 44, 214, 44, 117, 77, 181, 138, 167, 75, 203, 175, 136, 130, 76, 25, 196, 11, 106, 1, 222, 109, 26, 130, 169, 204, 245, 178, 213, 60, 18, 167, 221, 138, 67, 1, 32, 81, 23, 4, 86, 79, 203 }, new byte[] { 37, 6, 150, 4, 193, 18, 6, 244, 228, 181, 129, 132, 241, 135, 74, 242, 197, 121, 33, 108, 191, 116, 108, 170, 15, 208, 148, 40, 178, 139, 83, 55, 21, 173, 111, 106, 53, 123, 241, 119, 207, 53, 75, 3, 192, 151, 200, 32, 255, 114, 74, 129, 84, 219, 138, 196, 83, 131, 102, 79, 237, 154, 245, 252, 252, 235, 50, 53, 148, 0, 55, 120, 157, 87, 175, 205, 39, 14, 234, 96, 228, 128, 9, 223, 97, 186, 58, 251, 181, 61, 182, 95, 89, 107, 139, 234, 67, 142, 116, 32, 247, 38, 55, 233, 88, 156, 2, 86, 51, 181, 109, 133, 1, 179, 180, 195, 78, 192, 134, 132, 154, 191, 32, 45, 175, 214, 15, 147 } });
        }
    }
}
