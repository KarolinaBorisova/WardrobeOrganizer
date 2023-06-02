using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(HouseId))]
        public House House { get; set; } = null!;
        public int HouseId { get; set; }

        public bool IsActive { get; set; } = true;

        public IList<Clothes> Clothes { get; set; } = new List<Clothes>();

        public IList<Shoes> Shoes { get; set; } = new List<Shoes>();

        public IList<Outerwear> Outerwear { get; set; } = new List<Outerwear>();

    }
}
