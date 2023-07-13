using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Clothes
{
    public class AllClothesByCategoryViewModel
    {
        public string HouseName { get; set; }
        public string StorageName { get; set; }
        public int StorageId { get; set; }
        public string Category { get; set; }
        public IEnumerable<ClothesViewModel> Clothes { get; set; }
    }
}
