using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class User:IdentityUser
    {
     
        [MaxLength(50)]
        public string?FirstName { get; set; } = null!;

 
        [MaxLength(50)]
        public string? LastName { get; set; } = null!;


        //[ForeignKey(nameof(FamilyId))]
        public Family? Family { get; set; }
        public int? FamilyId { get; set; }

    }
}
