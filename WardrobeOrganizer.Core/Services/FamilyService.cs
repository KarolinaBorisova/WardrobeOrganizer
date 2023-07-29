using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        public FamilyService(IRepository _repo,
            IMapper _mapper)
        {
            this.repo = _repo;
            this.mapper = _mapper;

        }

        public async Task<int> Create(FamilyViewModel model, string userId)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Family is not valid");
            }

            var user = await repo.All<User>()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            var family = new Family()
            {
                Name = model.Name,
                UserId = userId,
                User = user,
            };

          
            user.Family = family;

            try
            {
                await repo.AddAsync(family);
                await repo.SaveChangesAsync();

                return family.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }

        public async Task Edit(FamilyViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Family is not valid");
            }
            try
            {
                var family = await repo.GetByIdAsync<Family>(model.Id);
                family.Id = model.Id;
                family.Name = model.Name;
                

                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(int id)
        {
            try
            {
                return await repo.AllReadonly<Family>()
                .AnyAsync(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<FamilyViewModel> GetFamilyById(int id)
        {

            try
            {
                return await repo.AllReadonly<Family>()
               .Where(f => f.Id == id)
               .Select(f => mapper.Map<FamilyViewModel>(f)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<FamilyViewModel> GetFamilyByUserId(string userId)
        {
           
            try
            {
                return await repo.AllReadonly<Family>()
               .Include(f => f.User)
               .Where(f => f.UserId == userId)
               .Select(f => new FamilyViewModel()
               {
                   Id = f.Id,
                   Name = f.Name,
                   UserId = userId
               }).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
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
