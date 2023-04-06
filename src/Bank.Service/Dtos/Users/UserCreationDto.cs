using System.ComponentModel.DataAnnotations;

namespace Bank.Service.Dtos.Users
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "First Name required!")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth required!")]
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
