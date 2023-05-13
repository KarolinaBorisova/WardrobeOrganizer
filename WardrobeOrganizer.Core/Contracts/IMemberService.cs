using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IMemberService
    { 
       // Task<bool> ExistsById(string userId);

       // Task Create(string userId);

        Task<int> AddMember(AddMemberViewModel model, int familyId);

        Task<ICollection<AllMembersViewModel>> AllMembers(int familyId);

    }
}
