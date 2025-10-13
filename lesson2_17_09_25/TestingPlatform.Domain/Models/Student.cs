using System.ComponentModel.DataAnnotations.Schema;

namespace TestingPlatform.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string phoneNumber { get; set; }
        public string VkProfileLink { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [NotMapped]
        public List<Group> Groups { get; set; }
        public List<Test> Tests { get; set; }
        public List<Attempt> Attempts { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
