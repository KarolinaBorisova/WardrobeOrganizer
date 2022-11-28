using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Models.Member
{
    public class HomeMemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StoragesViewModel MineStorage { get; set; }
        public FamilyViewModel Family { get; set; }
    }
}
