namespace lesson2_17_09_25.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public bool IsPassed { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public int AttemptId { get; set; }
        public Attempt Attempt { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
