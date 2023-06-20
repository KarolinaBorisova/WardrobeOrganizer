using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class AllShoesByCategoryViewModel
    {
        public int MemberId { get; set; }
        public int StorageId { get; set; }
        public string Category { get; set; }
        public IEnumerable<ShoesViewModel> Shoes { get; set; }
    }
}
