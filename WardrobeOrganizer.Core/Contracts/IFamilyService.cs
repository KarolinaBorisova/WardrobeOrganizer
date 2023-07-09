using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IFamilyService
    {
        Task<int> Create(FamilyViewModel model, string userId);

        Task<bool> ExistsById(int id);

        Task<FamilyViewModel> GetFamilyByUserId(string id);

        Task<FamilyViewModel> GetFamilyById(int id);

        Task<bool> HasFamily(string userId);

        Task<int> GetFamilyId(string userId);

        Task Edit(FamilyViewModel model);
    }
}
