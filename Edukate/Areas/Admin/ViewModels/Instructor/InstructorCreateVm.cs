using Edukate.Models;
using System.ComponentModel.DataAnnotations;

namespace Edukate.Areas.Admin.ViewModels.Instructor
{
    public class InstructorCreateVm
    {
        [MinLength(3), MaxLength(16)]
        public string Name { get; set; }
        public IFormFile ImgUrl { get; set; }
        public int ProfessionId { get; set; }
        public Profession? Profession { get; set; }
    }
}
