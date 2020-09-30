using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class ChapterMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Videos_IntroVideoId",
                table: "Chapters");

            migrationBuilder.AlterColumn<int>(
                name: "IntroVideoId",
                table: "Chapters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Videos_IntroVideoId",
                table: "Chapters",
                column: "IntroVideoId",
                principalTable: "Videos",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Videos_IntroVideoId",
                table: "Chapters");

            migrationBuilder.AlterColumn<int>(
                name: "IntroVideoId",
                table: "Chapters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Videos_IntroVideoId",
                table: "Chapters",
                column: "IntroVideoId",
                principalTable: "Videos",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
