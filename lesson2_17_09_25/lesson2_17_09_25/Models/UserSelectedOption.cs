namespace lesson2_17_09_25.Models
{
    public class UserSelectedOption
    {
        public int Id { get; set; }
        public int UserAttemptAnswerId { get; set; }
        public UserAttemptAnswer UserAttemptAnswer { get; set; }
        public int AswerId { get; set; }
        public Answer Answer { get; set; }

    }
}