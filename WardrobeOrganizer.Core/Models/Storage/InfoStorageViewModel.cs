using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.House;

namespace WardrobeOrganizer.Core.Models.Storage
{
    public class InfoStorageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AllHousesViewModel? House { get; set; }
    }
}
