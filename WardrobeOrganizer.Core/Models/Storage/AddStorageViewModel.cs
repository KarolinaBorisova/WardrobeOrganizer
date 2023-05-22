using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.House;

namespace WardrobeOrganizer.Core.Models.Storage
{
    public class AddStorageViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int HouseId { get; set; }

      
    }
}
