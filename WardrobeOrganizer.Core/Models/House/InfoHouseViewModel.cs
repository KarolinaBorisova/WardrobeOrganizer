using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Models.House
{
    public class InfoHouseViewModel
    {
        
        public int Id { get; set; }

        public string Name { get; set; } 

        public string Address { get; set; } 


        public int? FamilyId { get; set; }

        public ICollection<AllStoragesViewModel> Storages { get; set; } = new List<AllStoragesViewModel>();
    }
}
