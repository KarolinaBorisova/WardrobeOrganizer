using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IRepository repo;

        public FamilyService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<int> Create(FamilyViewModel model, string userId)
        {

            var user = await repo.All<User>()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

            var family = new Family()
            {
                Name = model.Name,
                UserId = userId,
                User = user,
            };
            // user e null?
            user.Family = family;

            try
            {
                await repo.AddAsync(family);
                await repo.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }


          
            return family.Id;
        }

        public async Task<FamilyViewModel> GetFamilyByUserId(string userId)
        {
            
            return await repo.AllReadonly<Family>()
                .Include(f=>f.User)
                .Where(f => f.UserId== userId)
                .Select(f => new FamilyViewModel() 
                {
                    Id = f.Id,
                    Name = f.Name,
                   UserId = userId
                }).FirstOrDefaultAsync();
                  
                
        }

        public async Task<int> GetFamilyId(string userId)
        {
            return (await repo.AllReadonly<Family>()
                 .FirstOrDefaultAsync(f => f.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> HasFamily(string userId)
        {
            var user = await repo.AllReadonly<User>()
                .Include(u=>u.Family)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();     

            if (user?.Family == null)
            {
                return false;
            }    
                return true;
        }
    }
}
