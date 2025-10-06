using lesson2_17_09_25.Controllers;
using lesson2_17_09_25.Enums;

namespace lesson2_17_09_25.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public bool IsRepeatable { get; set; }
        public TestType Type { get; set; }
        //public AnswerType AnswerType { get; set; } не нужен
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset PublishedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Deadline { get; set; } = DateTimeOffset.UtcNow;
        public int DurationMinutes { get; set; }
        public bool IsPublic { get; set; }
        public int PassingScore { get; set; }
        public int MaxAttempts { get; set; }
        public List<Question> Questions { get; set; }
        public List<Student> Students { get; set; }
        public List<Project> Projects { get; set; }
        public List<Course> Coursees { get; set; }
        public List<Direction> Directions { get; set; }
        public List<Group> Groups { get; set; }
        public List<Attempt> Attempts { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
