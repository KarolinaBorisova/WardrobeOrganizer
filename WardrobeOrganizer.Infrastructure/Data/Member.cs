using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public int? StorageId { get; set; }
        //[ForeignKey(nameof(StorageId))]
        public Storage? Storage { get; set; }


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
        public Gender Gender { get; set; }

        [Required]
        public int ShoeSizeEu { get; set; }


        public double? FootLengthCm { get; set; }

        [Required]
        [MaxLength(5)]
        public string ClothesSize { get; set; } = null!;

        public double? UserHeight { get; set; }

       
        [ForeignKey(nameof(FamilyId))]
        public Family? Family { get; set; }
        public int? FamilyId { get; set; }

    }
}
