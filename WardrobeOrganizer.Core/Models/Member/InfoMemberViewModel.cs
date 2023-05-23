using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Member
{
    public class InfoMemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public FamilyViewModel? Family { get; set; }

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
        public string ClothesSize { get; set; } 

        public double? UserHeight { get; set; }
    }
}
