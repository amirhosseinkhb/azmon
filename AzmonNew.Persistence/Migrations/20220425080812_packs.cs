using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmonNew.Persistence.Migrations
{
    public partial class packs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionPacks_QuestionPacksId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionPacksId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionPacksId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "QuestionPacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionQuestionPacks",
                columns: table => new
                {
                    QuestionPacksId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuestionPacks", x => new { x.QuestionPacksId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_QuestionQuestionPacks_QuestionPacks_QuestionPacksId",
                        column: x => x.QuestionPacksId,
                        principalTable: "QuestionPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionQuestionPacks_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 4, 25, 12, 38, 11, 909, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPacks_UserId",
                table: "QuestionPacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuestionPacks_QuestionsId",
                table: "QuestionQuestionPacks",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionPacks_Users_UserId",
                table: "QuestionPacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionPacks_Users_UserId",
                table: "QuestionPacks");

            migrationBuilder.DropTable(
                name: "QuestionQuestionPacks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionPacks_UserId",
                table: "QuestionPacks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestionPacks");

            migrationBuilder.AddColumn<int>(
                name: "QuestionPacksId",
                table: "Questions",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionPacks_QuestionPacksId",
                table: "Questions",
                column: "QuestionPacksId",
                principalTable: "QuestionPacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
