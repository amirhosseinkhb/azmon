using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmonNew.Persistence.Migrations
{
    public partial class pack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 24, 11, 44, 19, 901, DateTimeKind.Local).AddTicks(9087));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 20, 14, 58, 27, 20, DateTimeKind.Local).AddTicks(8715));
        }
    }
}
