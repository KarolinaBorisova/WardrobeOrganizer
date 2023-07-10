using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            if (model== null)
            {
                throw new ArgumentNullException("Storage not valid");
            }
            var storage = new Storage()
            {
                Name = model.Name,
                HouseId = model.HouseId,
                   
            };
            try
            {
                await repo.AddAsync(storage);
                await repo.SaveChangesAsync();


                return storage.Id;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

        }

        public async Task<ICollection<AllStoragesViewModel>> AllStorages(int houseId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
               .Where(s => s.HouseId == houseId && s.IsActive)
               .OrderBy(x => x.Name)
              .Select(s => new AllStoragesViewModel
              {
                  Id = s.Id,
                  Name = s.Name,
                  House = new Models.House.AddHouseViewModel()
                  {
                      Name = s.House.Name,
                     // FamilyId = s.House.FamilyId,
                      Address = s.House.Address
                  }
              }).ToListAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
           
        }

        public async Task Delete(int storageId)
        {
            
            try
            {
                var storage = await repo.GetByIdAsync<Storage>(storageId);

                storage.IsActive = false;

                await repo.SaveChangesAsync();
            }
            catch (Exception e )
            {
                
                throw new InvalidOperationException(e.Message);
            }
         
        }

        public async Task Edit(InfoStorageViewModel model)
        {
            if (model== null)
            {
                throw new ArgumentNullException("Storage not valid");
            }
            try
            {
                var storage = await repo.GetByIdAsync<Storage>(model.Id);

                storage.Name = model.Name;

                await repo.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message); ;
            }
            
        }

        public async Task<bool> ExistsById(int id)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
          .AnyAsync(s => s.Id == id && s.IsActive);
            }
            catch (Exception ex) 
            {
                throw new InvalidOperationException(ex.Message); 
            }
      
        }

        public async Task<InfoStorageViewModel> GetStorageById(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Where(s => s.IsActive)
                .Select(s => new InfoStorageViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    House = new Models.House.AllHousesViewModel()
                    {
                        Id = s.House.Id,
                        Address = s.House.Address,
                        Name = s.House.Name,
                        FamilyId = s.House.FamilyId,
                    }
                })
                .FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            
        }
    }
}
