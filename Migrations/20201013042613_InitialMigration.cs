using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Institute.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    statement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FName = table.Column<string>(maxLength: 20, nullable: true),
                    MName = table.Column<string>(maxLength: 20, nullable: true),
                    LName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statement = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: false),
                    UploadDateTime = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    PaidBy = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: false),
                    PaymentedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Statement = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutors_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    PerformerId = table.Column<string>(nullable: false),
                    GivenTaskId = table.Column<int>(nullable: false),
                    Submitted = table.Column<bool>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(maxLength: 200, nullable: false),
                    Passed = table.Column<bool>(nullable: false),
                    CheckerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => new { x.PerformerId, x.GivenTaskId });
                    table.ForeignKey(
                        name: "FK_UserTasks_AppUsers_CheckerId",
                        column: x => x.CheckerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTasks_Assignments_GivenTaskId",
                        column: x => x.GivenTaskId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_AppUsers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    FileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Images_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    FileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Videos_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrectAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<string>(nullable: false),
                    RefQsnId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_CorrectAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectAnswers_Questions_RefQsnId",
                        column: x => x.RefQsnId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WrongAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<string>(nullable: false),
                    RefQsnId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrongAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_WrongAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrongAnswers_Questions_RefQsnId",
                        column: x => x.RefQsnId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefTestId = table.Column<int>(nullable: false),
                    QuestionId1 = table.Column<string>(nullable: true),
                    RefTestId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Questions_QuestionId1",
                        column: x => x.QuestionId1,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_RefTestId1",
                        column: x => x.RefTestId1,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGivenTests",
                columns: table => new
                {
                    PerformerId = table.Column<int>(nullable: false),
                    ConductedTestId = table.Column<int>(nullable: false),
                    FacedQsns = table.Column<int>(nullable: false),
                    CorrectlyAnswered = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    PerformerId1 = table.Column<string>(nullable: true),
                    ConductedTestId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGivenTests", x => new { x.PerformerId, x.ConductedTestId });
                    table.ForeignKey(
                        name: "FK_UserGivenTests_Tests_ConductedTestId1",
                        column: x => x.ConductedTestId1,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGivenTests_AppUsers_PerformerId1",
                        column: x => x.PerformerId1,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Fee = table.Column<decimal>(type: "money", nullable: false),
                    Goals = table.Column<string>(maxLength: 150, nullable: false),
                    Objectives = table.Column<string>(maxLength: 200, nullable: false),
                    Requriements = table.Column<string>(maxLength: 200, nullable: false),
                    IntroVideoId = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Videos_IntroVideoId",
                        column: x => x.IntroVideoId,
                        principalTable: "Videos",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchedVideos",
                columns: table => new
                {
                    UserWatchedId = table.Column<int>(nullable: false),
                    WatchedVideoId = table.Column<int>(nullable: false),
                    WatchedDuration = table.Column<TimeSpan>(nullable: false),
                    NumofTimeCompletlyWatched = table.Column<int>(nullable: false),
                    UserWatchedId1 = table.Column<string>(nullable: true),
                    WatchedVideoFileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchedVideos", x => new { x.UserWatchedId, x.WatchedVideoId });
                    table.ForeignKey(
                        name: "FK_UserWatchedVideos_AppUsers_UserWatchedId1",
                        column: x => x.UserWatchedId1,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWatchedVideos_Videos_WatchedVideoFileId",
                        column: x => x.WatchedVideoFileId,
                        principalTable: "Videos",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    SN = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Goal = table.Column<string>(maxLength: 150, nullable: false),
                    Objectives = table.Column<string>(maxLength: 200, nullable: true),
                    IntroVideoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chapters_Videos_IntroVideoId",
                        column: x => x.IntroVideoId,
                        principalTable: "Videos",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmedEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CourseId1 = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmedEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmedEnrollments_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfirmedEnrollments_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    CourseId1 = table.Column<string>(nullable: true),
                    AplicantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseApplications_Students_AplicantId",
                        column: x => x.AplicantId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseApplications_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursePostAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false),
                    RefCourseId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePostAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_CoursePostAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePostAssignments_Courses_RefCourseId",
                        column: x => x.RefCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePostTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefCourseId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePostTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_CoursePostTests_Courses_RefCourseId",
                        column: x => x.RefCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePostTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePreAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false),
                    RefCourseId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePreAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_CoursePreAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePreAssignments_Courses_RefCourseId",
                        column: x => x.RefCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePreTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefCourseId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePreTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_CoursePreTests_Courses_RefCourseId",
                        column: x => x.RefCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePreTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PendingEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseAccesss = table.Column<bool>(nullable: false),
                    CourseId1 = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingEnrollments_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PendingEnrollments_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredTutorCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    TutorId = table.Column<string>(nullable: false),
                    TutorShare = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    CourseId1 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredTutorCourses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_RegisteredTutorCourses_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredTutorCourses_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestedTutorCourse",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    TutorId = table.Column<string>(nullable: false),
                    TutorShare = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    NumberofReviews = table.Column<int>(nullable: false),
                    AdminComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedTutorCourse", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_RequestedTutorCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestedTutorCourse_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrialEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId1 = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialEnrollments_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrialEnrollments_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChapterPostAssignments",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefChapterId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false),
                    AssignmentDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPostAssignments", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_ChapterPostAssignments_Assignments_AssignmentDetailId",
                        column: x => x.AssignmentDetailId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChapterPostAssignments_Chapters_RefChapterId",
                        column: x => x.RefChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterPostTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefChapterId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPostTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_ChapterPostTests_Chapters_RefChapterId",
                        column: x => x.RefChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterPostTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterPreAssignments",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefChapterId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false),
                    AssignmentDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPreAssignments", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_ChapterPreAssignments_Assignments_AssignmentDetailId",
                        column: x => x.AssignmentDetailId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChapterPreAssignments_Chapters_RefChapterId",
                        column: x => x.RefChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterPreTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefChapterId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPreTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_ChapterPreTests_Chapters_RefChapterId",
                        column: x => x.RefChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterPreTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ChapterId = table.Column<string>(nullable: true),
                    SN = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Goal = table.Column<string>(maxLength: 150, nullable: false),
                    TeachingVideoId = table.Column<string>(nullable: true),
                    IsFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Videos_TeachingVideoId",
                        column: x => x.TeachingVideoId,
                        principalTable: "Videos",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentBills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentId = table.Column<int>(nullable: false),
                    PaymentDetailId = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentBills_PendingEnrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "PendingEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentBills_Payments_PaymentDetailId",
                        column: x => x.PaymentDetailId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonMaterials",
                columns: table => new
                {
                    FileId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false),
                    RefLessonId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonMaterials", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_LessonMaterials_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonMaterials_Lessons_RefLessonId",
                        column: x => x.RefLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonPostAssignments",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    RefLessonId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPostAssignments", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_LessonPostAssignments_Lessons_RefLessonId",
                        column: x => x.RefLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPostAssignments_Assignments_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonPostTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefLessonId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPostTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_LessonPostTests_Lessons_RefLessonId",
                        column: x => x.RefLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPostTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonPreAssignments",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    RefLessonId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPreAssignments", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_LessonPreAssignments_Lessons_RefLessonId",
                        column: x => x.RefLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPreAssignments_Assignments_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonPreTests",
                columns: table => new
                {
                    TestId = table.Column<string>(nullable: false),
                    RefLessonId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPreTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_LessonPreTests_Lessons_RefLessonId",
                        column: x => x.RefLessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPreTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMaterials",
                columns: table => new
                {
                    FileId = table.Column<string>(nullable: false),
                    SN = table.Column<int>(nullable: false),
                    RefTaskId = table.Column<int>(nullable: true),
                    RefTaskId1 = table.Column<string>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMaterials", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_TaskMaterials_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskMaterials_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMaterials_Lessons_RefTaskId1",
                        column: x => x.RefTaskId1,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostAssignments_AssignmentDetailId",
                table: "ChapterPostAssignments",
                column: "AssignmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostAssignments_RefChapterId",
                table: "ChapterPostAssignments",
                column: "RefChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostAssignments_SN_RefChapterId",
                table: "ChapterPostAssignments",
                columns: new[] { "SN", "RefChapterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPostTests_RefChapterId_SN",
                table: "ChapterPostTests",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreAssignments_AssignmentDetailId",
                table: "ChapterPreAssignments",
                column: "AssignmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreAssignments_RefChapterId_SN",
                table: "ChapterPreAssignments",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPreTests_RefChapterId_SN",
                table: "ChapterPreTests",
                columns: new[] { "RefChapterId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_IntroVideoId",
                table: "Chapters",
                column: "IntroVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId_SN",
                table: "Chapters",
                columns: new[] { "CourseId", "SN" },
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedEnrollments_CourseId1",
                table: "ConfirmedEnrollments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedEnrollments_StudentId1",
                table: "ConfirmedEnrollments",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswers_RefQsnId",
                table: "CorrectAnswers",
                column: "RefQsnId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_AplicantId",
                table: "CourseApplications",
                column: "AplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_CourseId1",
                table: "CourseApplications",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostAssignments_RefCourseId_SN",
                table: "CoursePostAssignments",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePostTests_RefCourseId_SN",
                table: "CoursePostTests",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreAssignments_RefCourseId_SN",
                table: "CoursePreAssignments",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePreTests_RefCourseId_SN",
                table: "CoursePreTests",
                columns: new[] { "RefCourseId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IntroVideoId",
                table: "Courses",
                column: "IntroVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_code",
                table: "Courses",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBills_EnrollmentId",
                table: "EnrollmentBills",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentBills_PaymentDetailId",
                table: "EnrollmentBills",
                column: "PaymentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonMaterials_RefLessonId",
                table: "LessonMaterials",
                column: "RefLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostAssignments_RefLessonId",
                table: "LessonPostAssignments",
                column: "RefLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostAssignments_SN_RefLessonId",
                table: "LessonPostAssignments",
                columns: new[] { "SN", "RefLessonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPostTests_RefLessonId_SN",
                table: "LessonPostTests",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreAssignments_RefLessonId_SN",
                table: "LessonPreAssignments",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPreTests_RefLessonId_SN",
                table: "LessonPreTests",
                columns: new[] { "RefLessonId", "SN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeachingVideoId",
                table: "Lessons",
                column: "TeachingVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ChapterId_SN",
                table: "Lessons",
                columns: new[] { "ChapterId", "SN" },
                unique: true,
                filter: "[ChapterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PendingEnrollments_CourseId1",
                table: "PendingEnrollments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_PendingEnrollments_StudentId1",
                table: "PendingEnrollments",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTutorCourses_CourseId1",
                table: "RegisteredTutorCourses",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTutorCourses_TutorId",
                table: "RegisteredTutorCourses",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedTutorCourse_TutorId",
                table: "RequestedTutorCourse",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMaterials_AssignmentId",
                table: "TaskMaterials",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMaterials_RefTaskId1",
                table: "TaskMaterials",
                column: "RefTaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_QuestionId1",
                table: "TestQuestions",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_RefTestId1",
                table: "TestQuestions",
                column: "RefTestId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrialEnrollments_CourseId1",
                table: "TrialEnrollments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrialEnrollments_StudentId1",
                table: "TrialEnrollments",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGivenTests_ConductedTestId1",
                table: "UserGivenTests",
                column: "ConductedTestId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserGivenTests_PerformerId1",
                table: "UserGivenTests",
                column: "PerformerId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_CheckerId",
                table: "UserTasks",
                column: "CheckerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_GivenTaskId",
                table: "UserTasks",
                column: "GivenTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchedVideos_UserWatchedId1",
                table: "UserWatchedVideos",
                column: "UserWatchedId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchedVideos_WatchedVideoFileId",
                table: "UserWatchedVideos",
                column: "WatchedVideoFileId");

            migrationBuilder.CreateIndex(
                name: "IX_WrongAnswers_RefQsnId",
                table: "WrongAnswers",
                column: "RefQsnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ChapterPostAssignments");

            migrationBuilder.DropTable(
                name: "ChapterPostTests");

            migrationBuilder.DropTable(
                name: "ChapterPreAssignments");

            migrationBuilder.DropTable(
                name: "ChapterPreTests");

            migrationBuilder.DropTable(
                name: "ConfirmedEnrollments");

            migrationBuilder.DropTable(
                name: "CorrectAnswers");

            migrationBuilder.DropTable(
                name: "CourseApplications");

            migrationBuilder.DropTable(
                name: "CoursePostAssignments");

            migrationBuilder.DropTable(
                name: "CoursePostTests");

            migrationBuilder.DropTable(
                name: "CoursePreAssignments");

            migrationBuilder.DropTable(
                name: "CoursePreTests");

            migrationBuilder.DropTable(
                name: "EnrollmentBills");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LessonMaterials");

            migrationBuilder.DropTable(
                name: "LessonPostAssignments");

            migrationBuilder.DropTable(
                name: "LessonPostTests");

            migrationBuilder.DropTable(
                name: "LessonPreAssignments");

            migrationBuilder.DropTable(
                name: "LessonPreTests");

            migrationBuilder.DropTable(
                name: "RegisteredTutorCourses");

            migrationBuilder.DropTable(
                name: "RequestedTutorCourse");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "TaskMaterials");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "TrialEnrollments");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserGivenTests");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "UserWatchedVideos");

            migrationBuilder.DropTable(
                name: "WrongAnswers");

            migrationBuilder.DropTable(
                name: "PendingEnrollments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
