using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostBuilder_Testing.Migrations
{
    /// <inheritdoc />
    public partial class add_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("4bca57e3-b8b9-44f8-b201-29897a7bb85c"), "Sinthon", "Sinthon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("4bca57e3-b8b9-44f8-b201-29897a7bb85c"));
        }
    }
}
