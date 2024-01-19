using Edukate.Models;
using System.ComponentModel.DataAnnotations;

namespace Edukate.Areas.Admin.ViewModels.Instructor
{
    public class InstructorListItemVm
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(16)]

        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public bool IsDeleted { get; set; }

        public string ProfessionName { get; set; }
    }
}
