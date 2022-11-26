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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        public int ShoeSizeEu { get; set; }


        public int? FootLengthCm { get; set; }

        [Required]
        [MaxLength(5)]
        public string  ClothesSize { get; set; } = null!;

        public int? UserHeight { get; set; }

    }
}
