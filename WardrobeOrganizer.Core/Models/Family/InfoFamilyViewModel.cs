using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Member;

namespace WardrobeOrganizer.Core.Models.Family
{
    public class InfoFamilyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MemberViewModel> Members { get; set; }
    }
}
