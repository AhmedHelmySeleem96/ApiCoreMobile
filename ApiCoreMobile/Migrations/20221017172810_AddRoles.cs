using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCoreMobile.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6896f509-3d3c-4008-8bd6-de3458215a5c", "86e28769-2ccf-4cbf-ac68-6a7ded92f493", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2390c30-76ce-4cff-83d0-00dbcaecb1be", "1e720b14-a175-4495-a81c-18660c86013b", "Adminstrator", "ADMINSTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6896f509-3d3c-4008-8bd6-de3458215a5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2390c30-76ce-4cff-83d0-00dbcaecb1be");
        }
    }
}
