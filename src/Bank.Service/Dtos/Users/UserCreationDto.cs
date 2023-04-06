using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Dtos.Users
{
    public class UserCreationDto
    {
        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "First Name required!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Last Name required!")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth required!")]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Required(ErrorMessage = "Phone number required required!")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid Email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should contain at least 6 symbols")]
        public string Password { get; set; }
    }
}
