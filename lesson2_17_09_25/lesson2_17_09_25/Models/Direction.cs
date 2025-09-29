namespace lesson2_17_09_25.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}
