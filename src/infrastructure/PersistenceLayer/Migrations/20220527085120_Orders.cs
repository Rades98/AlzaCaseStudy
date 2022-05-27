using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                table: "OrderStatuses",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[,]
                {
                    { new Guid("27f83608-434a-4f4b-8315-ff711a97bff4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "New" },
                    { new Guid("91ba34e8-3bf7-4168-9e59-bb68642f602e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InExpedition" },
                    { new Guid("93623d0a-914e-4252-9c1f-89563b4f9ee2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Created" },
                    { new Guid("953ff38d-ba59-41fe-9246-594d6af35b1f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Delivered" },
                    { new Guid("c958ddec-c8c3-410d-8fb3-7bba41b9cdd8"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "WaitingForPayment" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 195, 17, 46, 71, 227, 38, 7, 45, 96, 69, 255, 163, 3, 81, 211, 177, 239, 225, 242, 226, 146, 24, 209, 72, 82, 45, 230, 190, 122, 234, 222, 197, 221, 145, 70, 218, 26, 24, 253, 64, 178, 216, 67, 8, 245, 45, 31, 51, 0, 109, 86, 185, 118, 191, 147, 236, 79, 161, 93, 77, 96, 223, 221, 167 }, new byte[] { 255, 134, 50, 58, 169, 70, 149, 175, 237, 169, 137, 129, 4, 57, 233, 123, 9, 35, 245, 182, 102, 145, 78, 36, 162, 217, 42, 112, 101, 204, 7, 17, 248, 166, 64, 33, 76, 238, 120, 184, 85, 151, 68, 179, 233, 147, 188, 206, 225, 226, 82, 221, 103, 104, 163, 19, 34, 143, 240, 21, 215, 237, 147, 36, 203, 230, 35, 123, 145, 36, 45, 65, 108, 140, 152, 64, 153, 112, 172, 30, 79, 147, 179, 23, 125, 82, 201, 237, 160, 197, 120, 112, 223, 146, 20, 146, 140, 72, 95, 89, 17, 194, 177, 79, 165, 13, 232, 247, 151, 196, 141, 161, 172, 152, 217, 189, 233, 177, 50, 85, 23, 70, 123, 24, 167, 131, 226, 206 } });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 167, 1, 57, 72, 244, 223, 151, 83, 113, 161, 87, 21, 77, 92, 238, 13, 99, 251, 160, 26, 14, 159, 231, 46, 232, 213, 245, 169, 186, 146, 68, 131, 127, 244, 88, 150, 136, 237, 9, 53, 125, 172, 218, 28, 119, 53, 203, 105, 153, 178, 104, 235, 194, 182, 195, 33, 232, 94, 3, 193, 129, 33, 101, 61 }, new byte[] { 82, 207, 235, 114, 110, 208, 18, 198, 47, 219, 136, 72, 168, 42, 220, 145, 172, 114, 209, 8, 208, 102, 73, 76, 72, 127, 154, 145, 141, 3, 87, 95, 134, 9, 7, 7, 12, 120, 122, 27, 90, 161, 192, 14, 184, 128, 3, 49, 116, 156, 0, 110, 35, 126, 133, 210, 203, 166, 181, 172, 13, 88, 254, 14, 224, 50, 184, 102, 11, 219, 9, 46, 116, 117, 204, 161, 20, 56, 15, 177, 114, 47, 214, 107, 175, 44, 172, 98, 109, 71, 164, 168, 114, 132, 104, 182, 117, 57, 19, 184, 89, 241, 13, 163, 178, 196, 96, 36, 49, 5, 235, 33, 133, 197, 177, 65, 247, 225, 119, 137, 161, 31, 114, 61, 16, 127, 82, 76 } });
        }
    }
}
