using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCoreMobile.Migrations
{
    public partial class ModInMobileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1ab84f60-78d2-4801-b80a-ce2e241fb6f9", "480e5190-5ff9-4897-9201-618ea09dda2d", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2810f511-b5e1-41b2-af69-5eb75c097036", "edf09ee2-1190-4a2b-87d8-39b538aa8037", "Adminstrator", "ADMINSTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab84f60-78d2-4801-b80a-ce2e241fb6f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2810f511-b5e1-41b2-af69-5eb75c097036");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12fac9a8-f803-4a0f-b255-15860fe7fcea", "f34e0b62-c643-4333-9180-ac1902229cfa", "Adminstrator", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b22a478-4cdc-42c5-8730-1a80a4efdc2f", "04d47e6d-2aa5-4226-90e5-af148f23c5c2", "user", "USER" });
        }
    }
}
