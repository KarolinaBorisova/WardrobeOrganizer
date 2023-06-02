using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Clothes : Item
    {
        public int? SizeHeight { get; set; }

        [Required]
        [MaxLength(5)]
        public string Size { get; set; } = null!;

        
        public CategoryClothes Category { get; set; }


    }
}
