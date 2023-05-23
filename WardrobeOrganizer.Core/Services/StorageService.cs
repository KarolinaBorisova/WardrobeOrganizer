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

        public async Task<int> AddStorage(AddStorageViewModel model)
        {
            var storage = new Storage()
            {
                Name = model.Name,
                HouseId = model.HouseId,
                
                
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

        public async Task<InfoStorageViewModel> GetStorageById(int storageId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new InfoStorageViewModel()
                {
                    Name = s.Name,
                    House = new Models.House.AddHouseViewModel()
                    {
                        Address=s.House.Address,
                        Name=s.House.Name
                    }

                })
                .FirstAsync();
        }
    }
}
