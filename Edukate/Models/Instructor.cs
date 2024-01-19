using System.ComponentModel.DataAnnotations;

namespace Edukate.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [MinLength(3),MaxLength(16)]       
        
        public string Name { get; set; }
        public int ProfessionId { get; set; }
        public string ImgUrl { get; set; }
        public bool IsDeleted { get; set; }

        public Profession? Profession { get; set; }

    }
}
