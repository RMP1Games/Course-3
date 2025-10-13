using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingPlatform.Domain.Models
{
    public class UserSelectedOption
    {
        public int Id { get; set; }
        public int UserAttemptAnswerId { get; set; }
        //[NotMapped]
        //[Required]
        public UserAttemptAnswer UserAttemptAnswer { get; set; }
        public int AswerId { get; set; }
        public Answer Answer { get; set; }

    }
}