using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceLayer.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "ImgUri", "Name", "Price" },
                values: new object[] { new Guid("076d49af-6bc0-4dda-84ab-473c9f72bf60"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Realy cool stuff", "http://www.someuri.sf/smth-cool", "Something cool", 250m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Description", "ImgUri", "Name", "Price" },
                values: new object[] { new Guid("36faa1fb-88bc-4664-bc94-0ffa86e048a4"), null, new DateTime(2022, 4, 12, 17, 0, 0, 222, DateTimeKind.Local), null, "Realy cool and cheap stuff", "http://www.someuri.sf/smth-cool", "Something way cooler", 250m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("076d49af-6bc0-4dda-84ab-473c9f72bf60"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36faa1fb-88bc-4664-bc94-0ffa86e048a4"));
        }
    }
}
