using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmonNew.Persistence.Migrations
{
    public partial class packNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 26, 14, 22, 43, 955, DateTimeKind.Local).AddTicks(1286));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 26, 14, 6, 42, 217, DateTimeKind.Local).AddTicks(9520));
        }
    }
}
