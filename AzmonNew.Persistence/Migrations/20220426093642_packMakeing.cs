using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmonNew.Persistence.Migrations
{
    public partial class packMakeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QuestionPacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 26, 14, 6, 42, 217, DateTimeKind.Local).AddTicks(9520));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "QuestionPacks");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 25, 12, 38, 11, 909, DateTimeKind.Local).AddTicks(2888));
        }
    }
}
