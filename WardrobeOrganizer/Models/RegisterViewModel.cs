using System.ComponentModel.DataAnnotations;

namespace WardrobeOrganizer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string Password { get; set; }

        [Required]
        
        public string PasswordRepeat { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
