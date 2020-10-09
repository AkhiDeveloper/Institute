using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class uniqueindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LessonPreTests_RefLessonId",
                table: "LessonPreTests");

            migrationBuilder.DropIndex(
                name: "IX_LessonPreAssignments_RefLessonId",
                table: "LessonPreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_LessonPostTests_RefLessonId",
                table: "LessonPostTests");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPreTests_RefChapterId",
                table: "ChapterPreTests");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPreAssignments_RefChapterId",
                table: "ChapterPreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPostTests_RefChapterId",
                table: "ChapterPostTests");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreTests_RefLessonId_SN",
                table: "LessonPreTests",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreAssignments_RefLessonId_SN",
                table: "LessonPreAssignments",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostTests_RefLessonId_SN",
                table: "LessonPostTests",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostAssignments_SN_RefLessonId",
                table: "LessonPostAssignments",
                columns: new[] { "SN", "RefLessonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreTests_RefChapterId_SN",
                table: "ChapterPreTests",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreAssignments_RefChapterId_SN",
                table: "ChapterPreAssignments",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostTests_RefChapterId_SN",
                table: "ChapterPostTests",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostAssignments_SN_RefChapterId",
                table: "ChapterPostAssignments",
                columns: new[] { "SN", "RefChapterId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LessonPreTests_RefLessonId_SN",
                table: "LessonPreTests");

            migrationBuilder.DropIndex(
                name: "IX_LessonPreAssignments_RefLessonId_SN",
                table: "LessonPreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_LessonPostTests_RefLessonId_SN",
                table: "LessonPostTests");

            migrationBuilder.DropIndex(
                name: "IX_LessonPostAssignments_SN_RefLessonId",
                table: "LessonPostAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPreTests_RefChapterId_SN",
                table: "ChapterPreTests");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPreAssignments_RefChapterId_SN",
                table: "ChapterPreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPostTests_RefChapterId_SN",
                table: "ChapterPostTests");

            migrationBuilder.DropIndex(
                name: "IX_ChapterPostAssignments_SN_RefChapterId",
                table: "ChapterPostAssignments");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreTests_RefLessonId",
                table: "LessonPreTests",
                column: "RefLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreAssignments_RefLessonId",
                table: "LessonPreAssignments",
                column: "RefLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostTests_RefLessonId",
                table: "LessonPostTests",
                column: "RefLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreTests_RefChapterId",
                table: "ChapterPreTests",
                column: "RefChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreAssignments_RefChapterId",
                table: "ChapterPreAssignments",
                column: "RefChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostTests_RefChapterId",
                table: "ChapterPostTests",
                column: "RefChapterId");
        }
    }
}
