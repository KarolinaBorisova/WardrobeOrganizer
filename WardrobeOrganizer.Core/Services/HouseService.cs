using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class HouseService: IHouseService
    {
        private readonly IRepository repo;

        public HouseService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ICollection<AllHousesViewModel>> AllHouses(int familyId)
        {
            return await repo.AllReadonly<House>()
                .Where(h => h.FamilyId == familyId)
                .OrderBy(x => x.Name)
               .Select(s => new AllHousesViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Address = s.Address

               }).ToListAsync();
        }
    }
}
