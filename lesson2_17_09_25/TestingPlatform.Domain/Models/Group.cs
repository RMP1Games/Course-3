//using Microsoft.AspNetCore.Mvc.ModelBinding; ??
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingPlatform.Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectionId { get; set; }
        public Direction Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [NotMapped]
        public List<Student> Students { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Test> Tests { get; set; }
    }
}
