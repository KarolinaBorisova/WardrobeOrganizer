using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Outerwear
{
    public class AddOuterwearViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public string ImgUrl { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [MaxLength(20)]
        public string Size { get; set; }

        public int? SizeHeight { get; set; }

        public int? MemberId { get; set; }

        // public  IEnumerable<MemberViewModel> Members{ get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        public int StorageId { get; set; }
    }
}
