using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class SNAttributeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_SN",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreTests_RefCourseId",
                table: "CoursePreTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreTests_SN",
                table: "CoursePreTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreAssignments_RefCourseId",
                table: "CoursePreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreAssignments_SN",
                table: "CoursePreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostTests_RefCourseId",
                table: "CoursePostTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostTests_SN",
                table: "CoursePostTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostAssignments_RefCourseId",
                table: "CoursePostAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostAssignments_SN",
                table: "CoursePostAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_SN",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Id_SN",
                table: "Lessons",
                columns: new[] { "Id", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreTests_RefCourseId_SN",
                table: "CoursePreTests",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreAssignments_RefCourseId_SN",
                table: "CoursePreAssignments",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostTests_RefCourseId_SN",
                table: "CoursePostTests",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostAssignments_RefCourseId_SN",
                table: "CoursePostAssignments",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_Id_SN",
                table: "Chapters",
                columns: new[] { "Id", "SN" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_Id_SN",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreTests_RefCourseId_SN",
                table: "CoursePreTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreAssignments_RefCourseId_SN",
                table: "CoursePreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostTests_RefCourseId_SN",
                table: "CoursePostTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostAssignments_RefCourseId_SN",
                table: "CoursePostAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_Id_SN",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SN",
                table: "Lessons",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreTests_RefCourseId",
                table: "CoursePreTests",
                column: "RefCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreTests_SN",
                table: "CoursePreTests",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreAssignments_RefCourseId",
                table: "CoursePreAssignments",
                column: "RefCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreAssignments_SN",
                table: "CoursePreAssignments",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostTests_RefCourseId",
                table: "CoursePostTests",
                column: "RefCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostTests_SN",
                table: "CoursePostTests",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostAssignments_RefCourseId",
                table: "CoursePostAssignments",
                column: "RefCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostAssignments_SN",
                table: "CoursePostAssignments",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SN",
                table: "Chapters",
                column: "SN",
                unique: true);
        }
    }
}
