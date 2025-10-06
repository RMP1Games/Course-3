namespace lesson2_17_09_25.Models
{
    public class UserAttemptAnswer
    {
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public int ScoreAwarded { get; set; }
        public int AttemptId { get; set; }
        public Attempt Attempt { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public List<UserSelectedOption>? UserSelectOptions { get; set; }
        public UserTextAnwer? UserTextAnwer { get; set; }
    }
}