using Microsoft.EntityFrameworkCore;
using Olm.Domain.Entities.Assignments;
using Olm.Domain.Entities.Courses;
using Olm.Domain.Entities.Lessons;
using Olm.Domain.Entities.ProgressTrackings;
using Olm.Domain.Entities.Quizzes;
using Olm.Domain.Entities.UserEnrollments;

namespace Olm.Data.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<ProgressTracking> ProgressTrackings { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<UserEnrollment> UserEnrollments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Course)
            .WithMany()
            .HasForeignKey(a => a.CourseId);

         modelBuilder.Entity<Lesson>()
            .HasOne(u => u.Course)
            .WithMany()
            .HasForeignKey(a => a.CourseId);

        modelBuilder.Entity<Answer>()
            .HasOne(a => a.Question)
            .WithMany()
            .HasForeignKey(a => a.QuestionId);

        modelBuilder.Entity<Question>()
            .HasOne(a=>a.Course)
            .WithMany()
            .HasForeignKey(a=>a.CourseId);

        modelBuilder.Entity<Quiz>()
            .HasOne(a => a.Course)
            .WithMany()
            .HasForeignKey(a => a.CourseId);

        modelBuilder.Entity<UserEnrollment>()
            .HasOne(a=>a.Course)
            .WithMany()
            .HasForeignKey(a=>a.CourseId);
    }
}
            