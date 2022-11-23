using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Shoes:Item
    {
        public int? SizeEu { get; set; }

        public int? Centimetres { get; set; }

        [Required]
        public CategoryShoes CategoryShoes { get; set; }

        public int StorageId { get; set; }

        [Required]
        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; }
    }
}
