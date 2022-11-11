using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCoreMobile.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6896f509-3d3c-4008-8bd6-de3458215a5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2390c30-76ce-4cff-83d0-00dbcaecb1be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12fac9a8-f803-4a0f-b255-15860fe7fcea", "f34e0b62-c643-4333-9180-ac1902229cfa", "Adminstrator", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b22a478-4cdc-42c5-8730-1a80a4efdc2f", "04d47e6d-2aa5-4226-90e5-af148f23c5c2", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12fac9a8-f803-4a0f-b255-15860fe7fcea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b22a478-4cdc-42c5-8730-1a80a4efdc2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6896f509-3d3c-4008-8bd6-de3458215a5c", "86e28769-2ccf-4cbf-ac68-6a7ded92f493", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2390c30-76ce-4cff-83d0-00dbcaecb1be", "1e720b14-a175-4495-a81c-18660c86013b", "Adminstrator", "ADMINSTRATOR" });
        }
    }
}
