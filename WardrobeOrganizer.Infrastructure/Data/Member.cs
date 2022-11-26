using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

     
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
