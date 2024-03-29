﻿using Microsoft.AspNetCore.Http;
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
        Task<bool> ExistsById(int id);

        Task<int> AddMember(AddMemberViewModel model, int familyId, string rootPath);

        Task<ICollection<AllMembersViewModel>> AllMembers(int familyId);

        Task<InfoMemberViewModel> GetMemberById(int MemberId);

        Task Edit( EditMemberViewModel model, string rootPath);

        Task Delete(int MemberId);

        Task<IEnumerable<KeyValuePair<string, string>>> AllMembersBasic(int familyId);

    }
}
