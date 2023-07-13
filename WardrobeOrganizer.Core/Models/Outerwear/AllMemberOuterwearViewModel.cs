using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Outerwear
{
    public class AllMemberOuterwearViewModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public IEnumerable<OuterwearViewModel> Outerwear { get; set; }

    }
}
