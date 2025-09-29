namespace lesson2_17_09_25.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string phoneNumber { get; set; }
        public string VkProfileLink { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
