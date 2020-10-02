using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class AssignmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePostAssignments_Tasks_TaskId",
                table: "CoursePostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePreAssignments_Tasks_TaskId",
                table: "CoursePreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePreAssignments",
                table: "CoursePreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePostAssignments",
                table: "CoursePostAssignments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "CoursePreAssignments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "CoursePostAssignments");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "CoursePreAssignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "CoursePostAssignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePreAssignments",
                table: "CoursePreAssignments",
                column: "AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePostAssignments",
                table: "CoursePostAssignments",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePostAssignments_Tasks_AssignmentId",
                table: "CoursePostAssignments",
                column: "AssignmentId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePreAssignments_Tasks_AssignmentId",
                table: "CoursePreAssignments",
                column: "AssignmentId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePostAssignments_Tasks_AssignmentId",
                table: "CoursePostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursePreAssignments_Tasks_AssignmentId",
                table: "CoursePreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePreAssignments",
                table: "CoursePreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePostAssignments",
                table: "CoursePostAssignments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "CoursePreAssignments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "CoursePostAssignments");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "CoursePreAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "CoursePostAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePreAssignments",
                table: "CoursePreAssignments",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePostAssignments",
                table: "CoursePostAssignments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePostAssignments_Tasks_TaskId",
                table: "CoursePostAssignments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePreAssignments_Tasks_TaskId",
                table: "CoursePreAssignments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
