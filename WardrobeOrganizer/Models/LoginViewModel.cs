using System.ComponentModel.DataAnnotations;

namespace WardrobeOrganizer.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }
    }
}
