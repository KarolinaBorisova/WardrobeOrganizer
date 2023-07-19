using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Member
{
    public class EditMemberViewModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? ImagePath { get; set; }

        public IFormFile? Image { get; set; }

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
