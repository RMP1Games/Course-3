namespace TestingPlatform.Domain.Models
{
    public class Attempt
    {
        public int Id { get; set; }
        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset EndedAt { get; set; } = DateTimeOffset.UtcNow;
        public int Score { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public List<UserAttemptAnswer> UserAttemptAnswers { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
