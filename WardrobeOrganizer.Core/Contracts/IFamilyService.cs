using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IFamilyService
    {
        Task<int> Create(FamilyViewModel model);
    }
}
