using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Edukate.Models
{
    public class AppUser : IdentityUser
    {
        [MinLength(3),MaxLength(18)]
        public string FirstName { get; set; }
        [MinLength(5),MaxLength(18)]
        public string LastName
        {
            get; set;
        }
    }
}
