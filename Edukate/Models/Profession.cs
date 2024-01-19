namespace Edukate.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public bool IsDeleted { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
    }
}
