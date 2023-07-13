using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;

namespace WardrobeOrganizer.Core.Models.Outerwear
{
    public class AllOuterwearByCategoryViewModel
    {
        public string HouseName { get; set; }
        public string StorageName { get; set; }
        public int StorageId { get; set; }
        public string Category { get; set; }
        public IEnumerable<OuterwearViewModel> Outerwear { get; set; }
    }
}
