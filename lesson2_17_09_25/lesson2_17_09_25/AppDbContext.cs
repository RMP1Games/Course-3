using Microsoft.EntityFrameworkCore;
using lesson2_17_09_25.Models;

namespace lesson2_17_09_25
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Direction> Directions => Set<Direction>();

        public DbSet<Course> Courses => Set<Course>();
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Login).IsUnique();
                e.Property(x => x.Login).IsRequired();
                e.Property(x => x.PasswordHash).IsRequired();
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.FirstName).IsRequired();
                e.Property(x => x.LastName).IsRequired();
                e.Property(x => x.CreatedAt).HasDefaultValue("CURRENT_TIMESTAMP");

                e.HasOne(x => x.Student)
                    .WithOne(s => s.User)
                    .HasForeignKey<Student>(s => s.UserId);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.phoneNumber).HasMaxLength(30).IsRequired();
                e.Property(x => x.VkProfileLink).IsRequired();
                e.HasIndex(x => x.UserId).IsUnique();
                e.Property(x => x.UserId).IsRequired();

                e.HasMany(x => x.Groups)
                .WithMany(s => s.Students);

                e.HasMany(x => x.Attempts)
                .WithOne(s => s.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasMany(x => x.TestResults)
                .WithOne(s => s.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Direction>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Project>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Group>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.DirectionId).IsRequired();
                e.Property(x => x.CourseId).IsRequired();
                e.Property(x => x.ProjectId).IsRequired();

                e.HasOne(x => x.Description)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(x => x.DirectionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Course)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Project)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Test>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired();
                e.Property(x => x.Descripton).IsRequired();
                e.Property(x => x.IsRepeatable).HasDefaultValue(false);
                e.Property(x => x.Type).HasConversion<string>();
                e.Property(x => x.CreatedAt).HasDefaultValue("CURRENT_TIMESTAMP");
                e.Property(x => x.PublishedAt).IsRequired();
                e.Property(x => x.Deadline).IsRequired();
                e.Property(x => x.IsPublic).HasDefaultValue(false);

                e.HasMany(x => x.Students)
                    .WithMany(s => s.Tests)
                    .UsingEntity(s => s.ToTable("test_students"));

                e.HasMany(x => x.Projects)
                    .WithMany(s => s.Tests)
                    .UsingEntity(s => s.ToTable("test_projects"));  

                e.HasMany(x => x.Coursees)
                    .WithMany(s => s.Tests)
                    .UsingEntity(s => s.ToTable("test_courses"));

                e.HasMany(x => x.Groups)
                    .WithMany(s => s.Tests)
                    .UsingEntity(s => s.ToTable("test_groups"));

                e.HasMany(x => x.Directions)
                    .WithMany(s => s.Tests)
                    .UsingEntity(s => s.ToTable("test_directions"));
            });

            modelBuilder.Entity<Question>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.Number).IsRequired();
                e.Property(x => x.Description).HasMaxLength(2000);
                e.Property(x => x.AnswerType).HasConversion<string>();
                e.Property(x => x.IsScoring).HasDefaultValue(true);
                e.Property(x => x.TestId).IsRequired();

                e.HasOne(x => x.Test)
                    .WithMany(t => t.Questions)
                    .HasForeignKey(t => t.TestId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasIndex(x => new {x.TestId, x.Number}).IsUnique();
            });

            modelBuilder.Entity<Answer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.IsCorrect).IsRequired();
                e.Property(x => x.QuestionId).IsRequired();

                e.HasOne(x => x.Question)
                    .WithMany(t => t.Answers)
                    .HasForeignKey(t => t.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Attempt>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.StartedAt).HasDefaultValue("CURRENT_TIMESTAMP");
                e.Property(x => x.TestId).IsRequired();
                e.Property(x => x.StudentId).IsRequired();

                e.HasOne(x => x.Test)
                    .WithMany(t => t.Attempts)
                    .HasForeignKey(t => t.TestId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserAttemptAnswer>( e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.IsCorrect).IsRequired();
                e.Property(x => x.ScoreAwarded).HasColumnOrder(0|1); //MaxScore???
                e.Property(x => x.AttemptId).IsRequired();
                e.Property(x => x.QuestionId).IsRequired();

                e.HasOne(x => x.Attempt)
                    .WithMany(t => t.UserAttemptAnswers)
                    .HasForeignKey(t => t.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Question)
                    .WithMany(t => t.UserAttemptAnswers)
                    .HasForeignKey(t => t.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.UserTextAnwer)
                    .WithOne(t => t.UserAttemptAnswer)
                    .HasForeignKey<UserTextAnwer>(t => t.UserAttemptAnswerId);

                e.HasIndex(x => new { x.AttemptId, x.QuestionId }).IsUnique();
            });

            modelBuilder.Entity<UserSelectedOption>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.UserAttemptAnswer).IsRequired();
                e.Property(x => x.AswerId).IsRequired();

                e.HasOne(x => x.UserAttemptAnswer)
                    .WithMany(t => t.UserSelectOptions)
                    .HasForeignKey(t => t.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Answer)
                    .WithMany(t => t.UserSelectedOptions)
                    .HasForeignKey(t => t.AswerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTextAnwer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.TextAnswer).IsRequired();
                e.Property(x => x.UserAttemptAnswerId).IsRequired();

                e.HasOne(x => x.UserAttemptAnswer)
                    .WithOne(t => t.UserTextAnwer)
                    .HasForeignKey<UserTextAnwer>(t => t.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TestResult>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.IsPassed).IsRequired();
                e.Property(x => x.TestId).IsRequired();
                e.Property(x => x.AttemptId).IsRequired();
                e.Property(x => x.StudentId).IsRequired();

                e.HasOne(x => x.Test)
                    .WithMany(t => t.TestResults)
                    .HasForeignKey(t => t.TestId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Attempt)
                    .WithMany(t => t.TestResults)
                    .HasForeignKey(t => t.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasIndex(x => new { x.TestId, x.StudentId, x.AttemptId }).IsUnique();
            });
        }
    }
}
