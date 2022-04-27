using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmonNew.Persistence.Migrations
{
    public partial class pack1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionPacksId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionPacksId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionPacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    QuestionCount = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPacks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 24, 11, 47, 17, 647, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionPacksId",
                table: "Questions",
                column: "QuestionPacksId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_QuestionPacksId",
                table: "Categories",
                column: "QuestionPacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_QuestionPacks_QuestionPacksId",
                table: "Categories",
                column: "QuestionPacksId",
                principalTable: "QuestionPacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionPacks_QuestionPacksId",
                table: "Questions",
                column: "QuestionPacksId",
                principalTable: "QuestionPacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_QuestionPacks_QuestionPacksId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionPacks_QuestionPacksId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionPacks");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionPacksId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_QuestionPacksId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "QuestionPacksId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionPacksId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 24, 11, 44, 19, 901, DateTimeKind.Local).AddTicks(9087));
        }
    }
}
