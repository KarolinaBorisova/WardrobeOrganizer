using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class AllMemberShoesViewModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public IEnumerable<ShoesViewModel> Shoes { get; set; }
    }
}
