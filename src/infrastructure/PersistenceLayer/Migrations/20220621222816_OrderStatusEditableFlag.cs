using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class OrderStatusEditableFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrderEditable",
                table: "OrderStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("27f83608-434a-4f4b-8315-ff711a97bff4"),
                column: "IsOrderEditable",
                value: true);

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("93623d0a-914e-4252-9c1f-89563b4f9ee2"),
                column: "IsOrderEditable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 156, 191, 140, 215, 114, 183, 145, 68, 142, 23, 107, 22, 0, 116, 12, 34, 39, 182, 45, 232, 141, 245, 161, 85, 181, 182, 211, 196, 209, 187, 38, 240, 212, 199, 114, 198, 15, 19, 174, 118, 81, 34, 193, 114, 23, 37, 64, 75, 244, 199, 39, 243, 147, 143, 255, 26, 247, 239, 164, 224, 17, 45, 202, 102 }, new byte[] { 148, 182, 205, 72, 39, 24, 252, 241, 96, 228, 9, 52, 211, 41, 110, 224, 76, 38, 240, 80, 148, 229, 228, 230, 145, 90, 60, 76, 233, 13, 124, 208, 127, 12, 10, 117, 38, 41, 103, 22, 242, 137, 6, 27, 96, 56, 137, 244, 3, 147, 130, 178, 238, 196, 216, 77, 203, 83, 208, 86, 221, 5, 191, 5, 188, 147, 247, 227, 38, 142, 5, 173, 59, 93, 112, 61, 195, 221, 132, 46, 159, 117, 53, 147, 42, 140, 187, 143, 29, 132, 92, 48, 150, 59, 47, 64, 63, 80, 192, 123, 248, 151, 214, 92, 29, 64, 163, 125, 87, 186, 151, 31, 57, 149, 164, 130, 75, 95, 2, 218, 29, 138, 152, 65, 66, 204, 12, 181 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrderEditable",
                table: "OrderStatuses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 26, 52, 166, 12, 40, 240, 14, 234, 93, 117, 202, 77, 212, 132, 55, 26, 16, 76, 210, 21, 122, 157, 40, 1, 143, 83, 73, 241, 141, 254, 222, 21, 202, 48, 156, 129, 20, 231, 46, 173, 174, 19, 17, 23, 153, 83, 72, 99, 3, 124, 141, 105, 108, 101, 212, 144, 16, 160, 187, 141, 33, 105, 178, 156 }, new byte[] { 166, 173, 76, 3, 86, 50, 139, 27, 115, 245, 202, 71, 84, 225, 244, 132, 71, 38, 156, 253, 196, 3, 229, 90, 53, 170, 195, 69, 137, 170, 168, 205, 61, 121, 240, 167, 130, 205, 73, 189, 195, 10, 56, 166, 196, 217, 67, 108, 74, 35, 55, 112, 202, 172, 100, 181, 130, 89, 251, 126, 153, 81, 129, 64, 137, 42, 111, 166, 58, 248, 67, 197, 43, 84, 134, 98, 67, 237, 144, 140, 50, 137, 134, 21, 201, 237, 103, 120, 122, 171, 209, 195, 229, 103, 155, 206, 224, 15, 112, 183, 218, 156, 250, 6, 40, 184, 247, 167, 138, 96, 165, 167, 125, 213, 227, 173, 58, 41, 228, 250, 28, 133, 229, 177, 19, 20, 18, 243 } });
        }
    }
}
