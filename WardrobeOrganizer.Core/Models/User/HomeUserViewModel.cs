using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Houses;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Models.User
{
    public class HomeUserViewModel
    {
        public FamilyViewModel Family { get; set; }

        public ICollection<AllHousesViewModel> Houses { get; set; }

        public ICollection<AllMembersViewModel> Members { get; set; }
    }
}
