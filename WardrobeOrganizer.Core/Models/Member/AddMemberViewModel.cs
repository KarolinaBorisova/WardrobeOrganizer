using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Member
{
    public class AddMemberViewModel
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
        [EnumDataType(typeof(Gender))]
        public  Gender Gender { get; set; }

        [Required]
        public int ShoeSizeEu { get; set; }


        public double? FootLengthCm { get; set; }

        [Required]
        [MaxLength(5)]
        public string ClothesSize { get; set; } = null!;

        public double? UserHeight { get; set; }
    }
}
