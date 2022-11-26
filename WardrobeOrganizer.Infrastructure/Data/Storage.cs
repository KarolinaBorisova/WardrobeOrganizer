using System.ComponentModel.DataAnnotations;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Place { get; set; } = null!;

        public IList<Clothing> Clothes { get; set; } = new List<Clothing>();

        public IList<Shoes> Shoes { get; set; } = new List<Shoes>();

        public IList<Outerwear> Outerwear { get; set; } = new List<Outerwear>();

    }
}
