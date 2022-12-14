using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public abstract class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Url { get; set; }

        public string? Color { get; set; }

        public int StorageId { get; set; }

        [Required]
        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; } = null!;

    }
}
