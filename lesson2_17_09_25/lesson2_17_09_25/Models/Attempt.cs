namespace lesson2_17_09_25.Models
{
    public class Attempt
    {
        public int Id { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
        public int Score { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public List<UserAttemptAnswer> UserAttemptAnswers { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
