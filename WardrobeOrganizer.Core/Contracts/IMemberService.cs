﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Member;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IMemberService
    { 
        Task<bool> ExistsById(string userId);

        Task Create(string userId);

        Task AddMember(AddMemberViewModel model);
    }
}
