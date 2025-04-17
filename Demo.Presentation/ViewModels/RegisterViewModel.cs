
using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name Canno't be null"), MaxLength(50)]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; } = null!;
        public bool IsAgree { get; set; } = false;
    }
}
