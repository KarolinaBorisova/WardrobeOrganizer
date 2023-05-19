using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Family
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;


        public string? UserId { get; set; }  
        public User? User { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();

        public ICollection<House> Houses { get; set; } = new List<House>();

    }
}
