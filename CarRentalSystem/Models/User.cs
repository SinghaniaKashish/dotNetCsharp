using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class User
    {
        public int Id { get; set; }


        //name
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name length should be between 3 and 100")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name should only alphabets and space")]
        public string Name { get; set; }


        //email
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invaild Email Format")]
        public string Email { get; set; }


        //password
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number.")]
        public string Password { get; set; }


        //role
        [Required(ErrorMessage = "Role is required")]
        [RegularExpression(@"^(Admin|User)$", ErrorMessage = "Role must be either 'Admin' or 'User' " )]
        public string Role { get; set; }
    }
}
