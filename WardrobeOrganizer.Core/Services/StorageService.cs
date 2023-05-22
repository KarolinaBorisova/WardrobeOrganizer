using Microsoft.EntityFrameworkCore;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class StorageService : IStorageService
    {

        private readonly IRepository repo;

        public StorageService(IRepository _repo)
        {   
            repo = _repo;
        }

        public async Task<int> AddStorage(AddStorageViewModel model, int houseId)
        {
            var storage = new Storage()
            {
                Name = model.Name,
                HouseId = houseId,
                
            };

            await repo.AddAsync(storage);
            await repo.SaveChangesAsync();

            return storage.Id;
        }

        public async Task<ICollection<AllStoragesViewModel>> AllStorages(int houseId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.HouseId == houseId)
                .OrderBy(x => x.Name)
               .Select(s => new AllStoragesViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   House = new Models.House.AddHouseViewModel()
                   {
                       Name = s.House.Name,
                       //FamilyId = s.House.FamilyId,
                       Address = s.House.Address
                   }

               }).ToListAsync();
        }
    }
}
