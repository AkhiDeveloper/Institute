using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class SNUniqueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SN",
                table: "Lessons",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SN",
                table: "Chapters",
                column: "SN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_SN",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_SN",
                table: "Chapters");
        }
    }
}
