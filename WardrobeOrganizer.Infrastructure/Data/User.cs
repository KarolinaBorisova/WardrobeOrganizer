using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class User:IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [MaxLength(100)]
        public Family? Family { get; set; }

    }
}
