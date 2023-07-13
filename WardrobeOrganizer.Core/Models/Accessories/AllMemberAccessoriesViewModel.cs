using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Accessories
{
    public class AllMemberAccessoriesViewModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public IEnumerable<AccessoriesViewModel> Accessories { get; set; }
    }
}
