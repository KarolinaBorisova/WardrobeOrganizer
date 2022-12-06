using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Storage
{
    public class AddStorageViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Place { get; set; }

        public int? FamilyId { get; set; }

        public int? MemberId { get; set; }
    }
}
