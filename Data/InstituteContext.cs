﻿using Institute.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
//using System.Threading.Tasks;

namespace Institute.Data
{
    public class InstituteContext 
        : IdentityDbContext
        <ApplicationUser,IdentityRole<string>, string>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            //Creating Composite Key
            modelBuilder.Entity<UserTask>()
                .HasKey(o => new { o.PerformerId, o.GivenTaskId });

            modelBuilder.Entity<UserGivenTest>()
                .HasKey(x => new { x.PerformerId, x.ConductedTestId });

            modelBuilder.Entity<UserWatchedVideo>()
                .HasKey(x => new { x.UserWatchedId, x.WatchedVideoId });

            modelBuilder.Entity<UserTask>()
                .HasOne(x => x.Checker)
                .WithMany()
                .HasForeignKey(x => x.CheckerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne<Video>(x => x.TeachingVideo)
                .WithMany()
                .HasForeignKey(x => x.TeachingVideoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasIndex(x => x.code)
                .IsUnique();

            modelBuilder.Entity<Chapter>()
                .HasIndex(x => new { x.CourseId, x.SN})
                .IsUnique();

            modelBuilder.Entity<Lesson>()
                .HasIndex(x => new { x.ChapterId, x.SN })
                .IsUnique();

            modelBuilder.Entity<CoursePreTest>()
                .HasIndex(x => new { x.RefCourseId, x.SN })
                .IsUnique();

            modelBuilder.Entity<CoursePostTest>()
                .HasIndex(x => new { x.RefCourseId, x.SN })
                .IsUnique();

            modelBuilder.Entity<CoursePreAssignment>()
                .HasIndex(x => new { x.RefCourseId, x.SN })
                .IsUnique();

            modelBuilder.Entity<CoursePostAssignment>()
                .HasIndex(x => new { x.RefCourseId, x.SN })
                .IsUnique();

            modelBuilder.Entity<ChapterPreTest>()
                .HasIndex(x => new { x.RefChapterId, x.SN })
                .IsUnique();

            modelBuilder.Entity<ChapterPostTest>()
                .HasIndex(x => new { x.RefChapterId, x.SN })
                .IsUnique();

            modelBuilder.Entity<ChapterPreAssignment>()
                .HasIndex(x => new { x.RefChapterId, x.SN })
                .IsUnique();

            modelBuilder.Entity<ChapterPostAssignment>()
                .HasIndex(x => new { x.SN, x.RefChapterId })
                .IsUnique();

            modelBuilder.Entity<LessonPreTest>()
                .HasIndex(x => new { x.RefLessonId, x.SN })
                .IsUnique();

            modelBuilder.Entity<LessonPostTest>()
                .HasIndex(x => new { x.RefLessonId, x.SN })
                .IsUnique();

            modelBuilder.Entity<LessonPreAssignment>()
                .HasIndex(x => new { x.RefLessonId, x.SN })
                .IsUnique();

            modelBuilder.Entity<LessonPostAssignment>()
                .HasIndex(x => new { x.SN, x.RefLessonId })
                .IsUnique();

            modelBuilder.Entity<Test>()
                .HasIndex(x => x.Code)
                .IsUnique();

            modelBuilder.Entity<Question>()
                .HasIndex(x => x.Code)
                .IsUnique();

            base.OnModelCreating(modelBuilder);

            //Changing Table Names
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("AppUsers");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("UserTokens");
            });

            modelBuilder.Entity<IdentityRole<string>>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRoles");
            });

            
        }

        public InstituteContext(DbContextOptions<InstituteContext> opt) 
            : base(opt)
        {

        }
        
        //Main Table
        public DbSet<Course>  Courses { get; set; }
        public DbSet<RegisteredTutorCourse> RegisteredTutorCourses { get; set; }
        public DbSet<RequestedTutorCourse> RequestedTutorCourses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<EnrollmentPayment> EnrollmentBills { get; set; }


        //Relational or Axuillart Tables
        public DbSet<CoursePreAssignment> CoursePreAssignments { get; set; }
        public DbSet<CoursePostAssignment> CoursePostAssignments { get; set; }
        public DbSet<ChapterPreAssignment> ChapterPreAssignments { get; set; }
        public DbSet<ChapterPostAssignment> ChapterPostAssignments { get; set; }
        public DbSet<LessonPostAssignment> LessonPostAssignments { get; set; }
        public DbSet<LessonPreAssignment> LessonPreAssignments { get; set; }
        public DbSet<CoursePreTest> CoursePreTests { get; set; }
        public DbSet<CoursePostTest> CoursePostTests { get; set; }
        public DbSet<ChapterPreTest> ChapterPreTests { get; set; }
        public DbSet<ChapterPostTest> ChapterPostTests { get; set; }
        public DbSet<LessonPreTest> LessonPreTests { get; set; }
        public DbSet<LessonPostTest> LessonPostTests { get; set; }
        public DbSet<LessonMaterial> LessonMaterials { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserGivenTest> UserGivenTests { get; set; }
        public DbSet<UserWatchedVideo> UserWatchedVideos { get; set; }
        public DbSet<ConfirmedEnrollment> ConfirmedEnrollments { get; set; }
        public DbSet<PendingEnrollment> PendingEnrollments { get; set; }
        public DbSet<TrialEnrollment> TrialEnrollments { get; set; }
        public DbSet<CourseApplication> CourseApplications { get; set; }
        public DbSet<RequestedTutorCourse> TutorCourses { get; set; }
        public DbSet<TaskMaterial> TaskMaterials { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public DbSet<WrongAnswer> WrongAnswers { get; set; }

    }
}
