using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCoreMobile.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Iphone" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Samsung" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Oppo" });

            migrationBuilder.InsertData(
                table: "mobiles",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 1, 1, "Iphone 6 ", 6500.0 });

            migrationBuilder.InsertData(
                table: "mobiles",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 2, 1, "Iphone 7 ", 7500.0 });

            migrationBuilder.InsertData(
                table: "mobiles",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 3, 1, "Iphone 8 ", 9500.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mobiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "mobiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "mobiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
