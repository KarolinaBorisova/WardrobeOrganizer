using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(FamilyId))]
        public Family? Family { get; set; }
        public int? FamilyId { get; set; }

        public IList<Storage> Storages { get; set; } = new List<Storage>();

    }
}
