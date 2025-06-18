using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class RegistrationFormModel
    {
        [Required(ErrorMessage = "Please enter your full name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}