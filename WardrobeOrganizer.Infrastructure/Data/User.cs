using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class User:IdentityUser
    {
     
        [MaxLength(50)]
        public string?FirstName { get; set; } = null!;

 
        [MaxLength(50)]
        public string? LastName { get; set; } = null!;

        [MaxLength(100)]
        public Family? Family { get; set; }

    }
}
