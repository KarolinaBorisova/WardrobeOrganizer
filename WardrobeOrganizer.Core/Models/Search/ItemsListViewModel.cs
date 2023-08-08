using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Core.Models.Search
{
    public class ItemsListViewModel
    {
        // public IEnumerable<ClothesViewModel> Clothes { get; set; }
        // public IEnumerable<AccessoriesViewModel> Accessories { get; set; }
        // public IEnumerable<OuterwearViewModel> Outerwears { get; set; }
        // public IEnumerable<ShoesViewModel> Shoes { get; set; }
        public string Category { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<string> ClothesSizes { get; set; }

        public IEnumerable<int> ShoeSizesEu { get; set; }

        public IEnumerable<int> SizeByAges { get; set; }
    }
}
