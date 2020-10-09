using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostTest_Chapters_RefChapterId",
                table: "ChapterPostTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostTest_Tests_TestId",
                table: "ChapterPostTest");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreAssignment_Tasks_AssignmentDetailId",
                table: "ChapterPreAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreAssignment_Chapters_RefChapterId",
                table: "ChapterPreAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterTasks_Tasks_AssignmentDetailId",
                table: "ChapterTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterTasks_Chapters_RefChapterId",
                table: "ChapterTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterTests_Chapters_RefChapterId",
                table: "ChapterTests");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterTests_Tests_TestId",
                table: "ChapterTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostAssignment_Lessons_RefLessonId",
                table: "LessonPostAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostAssignment_Tasks_TaskId",
                table: "LessonPostAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostTest_Lessons_RefLessonId",
                table: "LessonPostTest");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostTest_Tests_TestId",
                table: "LessonPostTest");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTasks_Lessons_RefLessonId",
                table: "LessonTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTasks_Tasks_TaskId",
                table: "LessonTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTests_Lessons_RefLessonId",
                table: "LessonTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTests_Tests_TestId",
                table: "LessonTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonTests",
                table: "LessonTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonTasks",
                table: "LessonTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPostTest",
                table: "LessonPostTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPostAssignment",
                table: "LessonPostAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterTests",
                table: "ChapterTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterTasks",
                table: "ChapterTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPreAssignment",
                table: "ChapterPreAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPostTest",
                table: "ChapterPostTest");

            migrationBuilder.RenameTable(
                name: "LessonTests",
                newName: "LessonPreTests");

            migrationBuilder.RenameTable(
                name: "LessonTasks",
                newName: "LessonPreAssignments");

            migrationBuilder.RenameTable(
                name: "LessonPostTest",
                newName: "LessonPostTests");

            migrationBuilder.RenameTable(
                name: "LessonPostAssignment",
                newName: "LessonPostAssignments");

            migrationBuilder.RenameTable(
                name: "ChapterTests",
                newName: "ChapterPreTests");

            migrationBuilder.RenameTable(
                name: "ChapterTasks",
                newName: "ChapterPostAssignments");

            migrationBuilder.RenameTable(
                name: "ChapterPreAssignment",
                newName: "ChapterPreAssignments");

            migrationBuilder.RenameTable(
                name: "ChapterPostTest",
                newName: "ChapterPostTests");

            migrationBuilder.RenameIndex(
                name: "IX_LessonTests_RefLessonId",
                table: "LessonPreTests",
                newName: "IX_LessonPreTests_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonTasks_RefLessonId",
                table: "LessonPreAssignments",
                newName: "IX_LessonPreAssignments_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPostTest_RefLessonId",
                table: "LessonPostTests",
                newName: "IX_LessonPostTests_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPostAssignment_RefLessonId",
                table: "LessonPostAssignments",
                newName: "IX_LessonPostAssignments_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterTests_RefChapterId",
                table: "ChapterPreTests",
                newName: "IX_ChapterPreTests_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterTasks_RefChapterId",
                table: "ChapterPostAssignments",
                newName: "IX_ChapterPostAssignments_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterTasks_AssignmentDetailId",
                table: "ChapterPostAssignments",
                newName: "IX_ChapterPostAssignments_AssignmentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPreAssignment_RefChapterId",
                table: "ChapterPreAssignments",
                newName: "IX_ChapterPreAssignments_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPreAssignment_AssignmentDetailId",
                table: "ChapterPreAssignments",
                newName: "IX_ChapterPreAssignments_AssignmentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPostTest_RefChapterId",
                table: "ChapterPostTests",
                newName: "IX_ChapterPostTests_RefChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPreTests",
                table: "LessonPreTests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPreAssignments",
                table: "LessonPreAssignments",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPostTests",
                table: "LessonPostTests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPostAssignments",
                table: "LessonPostAssignments",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPreTests",
                table: "ChapterPreTests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPostAssignments",
                table: "ChapterPostAssignments",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPreAssignments",
                table: "ChapterPreAssignments",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPostTests",
                table: "ChapterPostTests",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostAssignments_Tasks_AssignmentDetailId",
                table: "ChapterPostAssignments",
                column: "AssignmentDetailId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostAssignments_Chapters_RefChapterId",
                table: "ChapterPostAssignments",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostTests_Chapters_RefChapterId",
                table: "ChapterPostTests",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostTests_Tests_TestId",
                table: "ChapterPostTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreAssignments_Tasks_AssignmentDetailId",
                table: "ChapterPreAssignments",
                column: "AssignmentDetailId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreAssignments_Chapters_RefChapterId",
                table: "ChapterPreAssignments",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreTests_Chapters_RefChapterId",
                table: "ChapterPreTests",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreTests_Tests_TestId",
                table: "ChapterPreTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostAssignments_Lessons_RefLessonId",
                table: "LessonPostAssignments",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostAssignments_Tasks_TaskId",
                table: "LessonPostAssignments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostTests_Lessons_RefLessonId",
                table: "LessonPostTests",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostTests_Tests_TestId",
                table: "LessonPostTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPreAssignments_Lessons_RefLessonId",
                table: "LessonPreAssignments",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPreAssignments_Tasks_TaskId",
                table: "LessonPreAssignments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPreTests_Lessons_RefLessonId",
                table: "LessonPreTests",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPreTests_Tests_TestId",
                table: "LessonPreTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostAssignments_Tasks_AssignmentDetailId",
                table: "ChapterPostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostAssignments_Chapters_RefChapterId",
                table: "ChapterPostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostTests_Chapters_RefChapterId",
                table: "ChapterPostTests");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPostTests_Tests_TestId",
                table: "ChapterPostTests");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreAssignments_Tasks_AssignmentDetailId",
                table: "ChapterPreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreAssignments_Chapters_RefChapterId",
                table: "ChapterPreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreTests_Chapters_RefChapterId",
                table: "ChapterPreTests");

            migrationBuilder.DropForeignKey(
                name: "FK_ChapterPreTests_Tests_TestId",
                table: "ChapterPreTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostAssignments_Lessons_RefLessonId",
                table: "LessonPostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostAssignments_Tasks_TaskId",
                table: "LessonPostAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostTests_Lessons_RefLessonId",
                table: "LessonPostTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPostTests_Tests_TestId",
                table: "LessonPostTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPreAssignments_Lessons_RefLessonId",
                table: "LessonPreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPreAssignments_Tasks_TaskId",
                table: "LessonPreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPreTests_Lessons_RefLessonId",
                table: "LessonPreTests");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPreTests_Tests_TestId",
                table: "LessonPreTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPreTests",
                table: "LessonPreTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPreAssignments",
                table: "LessonPreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPostTests",
                table: "LessonPostTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonPostAssignments",
                table: "LessonPostAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPreTests",
                table: "ChapterPreTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPreAssignments",
                table: "ChapterPreAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPostTests",
                table: "ChapterPostTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChapterPostAssignments",
                table: "ChapterPostAssignments");

            migrationBuilder.RenameTable(
                name: "LessonPreTests",
                newName: "LessonTests");

            migrationBuilder.RenameTable(
                name: "LessonPreAssignments",
                newName: "LessonTasks");

            migrationBuilder.RenameTable(
                name: "LessonPostTests",
                newName: "LessonPostTest");

            migrationBuilder.RenameTable(
                name: "LessonPostAssignments",
                newName: "LessonPostAssignment");

            migrationBuilder.RenameTable(
                name: "ChapterPreTests",
                newName: "ChapterTests");

            migrationBuilder.RenameTable(
                name: "ChapterPreAssignments",
                newName: "ChapterPreAssignment");

            migrationBuilder.RenameTable(
                name: "ChapterPostTests",
                newName: "ChapterPostTest");

            migrationBuilder.RenameTable(
                name: "ChapterPostAssignments",
                newName: "ChapterTasks");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPreTests_RefLessonId",
                table: "LessonTests",
                newName: "IX_LessonTests_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPreAssignments_RefLessonId",
                table: "LessonTasks",
                newName: "IX_LessonTasks_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPostTests_RefLessonId",
                table: "LessonPostTest",
                newName: "IX_LessonPostTest_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonPostAssignments_RefLessonId",
                table: "LessonPostAssignment",
                newName: "IX_LessonPostAssignment_RefLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPreTests_RefChapterId",
                table: "ChapterTests",
                newName: "IX_ChapterTests_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPreAssignments_RefChapterId",
                table: "ChapterPreAssignment",
                newName: "IX_ChapterPreAssignment_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPreAssignments_AssignmentDetailId",
                table: "ChapterPreAssignment",
                newName: "IX_ChapterPreAssignment_AssignmentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPostTests_RefChapterId",
                table: "ChapterPostTest",
                newName: "IX_ChapterPostTest_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPostAssignments_RefChapterId",
                table: "ChapterTasks",
                newName: "IX_ChapterTasks_RefChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_ChapterPostAssignments_AssignmentDetailId",
                table: "ChapterTasks",
                newName: "IX_ChapterTasks_AssignmentDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonTests",
                table: "LessonTests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonTasks",
                table: "LessonTasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPostTest",
                table: "LessonPostTest",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonPostAssignment",
                table: "LessonPostAssignment",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterTests",
                table: "ChapterTests",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPreAssignment",
                table: "ChapterPreAssignment",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterPostTest",
                table: "ChapterPostTest",
                column: "TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChapterTasks",
                table: "ChapterTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostTest_Chapters_RefChapterId",
                table: "ChapterPostTest",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPostTest_Tests_TestId",
                table: "ChapterPostTest",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreAssignment_Tasks_AssignmentDetailId",
                table: "ChapterPreAssignment",
                column: "AssignmentDetailId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterPreAssignment_Chapters_RefChapterId",
                table: "ChapterPreAssignment",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterTasks_Tasks_AssignmentDetailId",
                table: "ChapterTasks",
                column: "AssignmentDetailId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterTasks_Chapters_RefChapterId",
                table: "ChapterTasks",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterTests_Chapters_RefChapterId",
                table: "ChapterTests",
                column: "RefChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChapterTests_Tests_TestId",
                table: "ChapterTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostAssignment_Lessons_RefLessonId",
                table: "LessonPostAssignment",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostAssignment_Tasks_TaskId",
                table: "LessonPostAssignment",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostTest_Lessons_RefLessonId",
                table: "LessonPostTest",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPostTest_Tests_TestId",
                table: "LessonPostTest",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTasks_Lessons_RefLessonId",
                table: "LessonTasks",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTasks_Tasks_TaskId",
                table: "LessonTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTests_Lessons_RefLessonId",
                table: "LessonTests",
                column: "RefLessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTests_Tests_TestId",
                table: "LessonTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
