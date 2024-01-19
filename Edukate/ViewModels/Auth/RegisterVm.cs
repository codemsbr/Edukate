using System.ComponentModel.DataAnnotations;

namespace Edukate.ViewModels.Auth
{
    public class RegisterVm
    {
        [MinLength(3), MaxLength(18)]
        public string FirstName { get; set; }
        [MinLength(5), MaxLength(18)]
        public string LastName
        {
            get; set;
        }

        [MinLength(5), MaxLength(18)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(32),MinLength(6),DataType(DataType.Password),Compare(nameof(ConfiredPassword))]
        public string Password { get; set; }
        [MaxLength(32), MinLength(6), DataType(DataType.Password)]
        public string ConfiredPassword { get; set; }
    }
}
