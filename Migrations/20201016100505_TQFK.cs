using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class TQFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId1",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_QuestionId1",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionId1",
                table: "TestQuestions");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId",
                table: "TestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId",
                table: "TestQuestions");

            migrationBuilder.AddColumn<string>(
                name: "QuestionId1",
                table: "TestQuestions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_QuestionId1",
                table: "TestQuestions",
                column: "QuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Questions_QuestionId1",
                table: "TestQuestions",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
