using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        public string? ImgUrl { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int ShoeSizeEu { get; set; }


        public double? FootLengthCm { get; set; }

        [Required]
        [MaxLength(5)]
        public string ClothesSize { get; set; } = null!;

        public double? UserHeight { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(FamilyId))]
        public Family? Family { get; set; }
        public int? FamilyId { get; set; }

        public IList<Clothes> Clothes { get; set; } = new List<Clothes>();

        public IList<Shoes> Shoes { get; set; } = new List<Shoes>();

        public IList<Outerwear> Outerwear { get; set; } = new List<Outerwear>();

        public IList<Accessories> Accessories { get; set; } = new List<Accessories>();

    }
}
