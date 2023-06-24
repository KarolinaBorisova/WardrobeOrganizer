using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Accessories
{
    public class AllMemberAccessoriesByCategoryViewModel
    {
        public int MemberId { get; set; }
        public string Category { get; set; }
        public IEnumerable<AccessoriesViewModel> Accessories { get; set; }
    }
}
