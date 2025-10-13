using System.ComponentModel.DataAnnotations.Schema;

namespace TestingPlatform.Domain.Models
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
        //[NotMapped]
        public List<UserSelectedOption>? UserSelectedOptions { get; set; }
        public UserTextAnwer? UserTextAnwer { get; set; }
    }
}