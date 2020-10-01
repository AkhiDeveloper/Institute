using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class SNUniqueMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CoursePreTests_SN",
                table: "CoursePreTests",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreAssignments_SN",
                table: "CoursePreAssignments",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostTests_SN",
                table: "CoursePostTests",
                column: "SN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostAssignments_SN",
                table: "CoursePostAssignments",
                column: "SN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoursePreTests_SN",
                table: "CoursePreTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePreAssignments_SN",
                table: "CoursePreAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostTests_SN",
                table: "CoursePostTests");

            migrationBuilder.DropIndex(
                name: "IX_CoursePostAssignments_SN",
                table: "CoursePostAssignments");
        }
    }
}
