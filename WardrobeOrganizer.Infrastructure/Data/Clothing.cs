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
    public class Clothing : Item
    {
        public int? SizeHeight { get; set; }

        [Required]
        [MaxLength(5)]
        public string Size { get; set; } = null!;

        [Required]
        public CategoryClothing CategoryClothing { get; set; }

        public int StorageId { get; set; }

        [Required]
        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; } = null!;
    }
}
