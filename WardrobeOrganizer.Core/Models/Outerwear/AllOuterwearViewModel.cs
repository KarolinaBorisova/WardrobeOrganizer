using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;

namespace WardrobeOrganizer.Core.Models.Outerwear
{
    public class AllOuterwearViewModel
    {
        public int MemberId { get; set; }
        public int StorageId { get; set; }
        public IEnumerable<OuterwearViewModel> Outerwear { get; set; }

    }
}
