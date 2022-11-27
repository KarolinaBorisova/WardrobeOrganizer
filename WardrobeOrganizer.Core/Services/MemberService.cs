using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository repo;
        
        public MemberService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task Create(string userId)
        {
            var member = new Member()
            {

                UserId = userId,
            };

            await repo.AddAsync(member);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Member>()
                .AnyAsync(m => m.UserId == userId);
        }
    }
}
