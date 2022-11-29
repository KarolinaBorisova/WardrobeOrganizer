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

        public async Task<int> Create(FamilyViewModel model)
        {
            var family = new Family()
            {
                Name = model.Name,

            };

           await repo.AddAsync(family);
            await repo.SaveChangesAsync();

            return family.Id;
        }
    }
}
