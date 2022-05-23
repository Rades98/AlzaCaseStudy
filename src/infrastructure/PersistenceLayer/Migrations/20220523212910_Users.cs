using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "UserRoleRelation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Name" },
                values: new object[] { new Guid("7cfd3e28-c6ed-48b9-8d08-424751e77eaf"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Email", "Name", "PasswordHash", "PasswordSalt", "Surname", "UserName" },
                values: new object[] { new Guid("1d984227-1a68-4aa2-98fe-8c398e02ff85"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "some@email.com", "Admin", new byte[] { 58, 60, 39, 66, 35, 163, 16, 219, 190, 168, 24, 104, 12, 208, 49, 205, 168, 66, 66, 164, 225, 222, 99, 202, 15, 168, 150, 166, 31, 98, 133, 198, 252, 52, 215, 236, 38, 82, 196, 179, 221, 124, 221, 197, 215, 214, 58, 99, 2, 98, 187, 200, 124, 196, 174, 11, 118, 130, 204, 108, 130, 172, 62, 154 }, new byte[] { 170, 109, 30, 10, 224, 39, 40, 167, 36, 239, 220, 27, 246, 192, 18, 152, 103, 195, 14, 126, 139, 194, 240, 91, 40, 189, 212, 158, 31, 141, 92, 237, 61, 132, 181, 156, 110, 34, 223, 218, 53, 89, 252, 103, 224, 73, 54, 26, 176, 68, 87, 213, 62, 112, 198, 95, 11, 140, 152, 149, 4, 22, 247, 224, 170, 246, 213, 151, 95, 252, 114, 129, 243, 217, 190, 69, 109, 155, 18, 180, 101, 239, 203, 175, 229, 116, 85, 215, 88, 197, 76, 179, 76, 76, 13, 64, 195, 80, 27, 247, 101, 163, 57, 188, 15, 79, 36, 103, 171, 205, 152, 175, 212, 248, 87, 18, 186, 83, 148, 255, 106, 225, 91, 8, 212, 158, 52, 218 }, "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelation_UserId",
                table: "UserRoleRelation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleRelation");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
