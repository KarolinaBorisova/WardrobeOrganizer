﻿using Microsoft.EntityFrameworkCore;
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
            var storage = new Storage()
            {
                Name = model.Name,
                HouseId = model.HouseId,
                   
            };
            try
            {
                await repo.AddAsync(storage);
                await repo.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }

           
            return storage.Id;
        }

        public async Task<ICollection<AllStoragesViewModel>> AllStorages(int houseId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
               .Where(s => s.HouseId == houseId)
               .Where(s => s.IsActive)
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
            return await repo.AllReadonly<Storage>()
                .AnyAsync(s=>s.Id == id && s.IsActive);
        }

        public async Task<InfoStorageViewModel> GetStorageById(int storageId)
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
                        Address=s.House.Address,
                        Name=s.House.Name,
                        FamilyId =s.House.FamilyId,
                    }
                })
                .FirstAsync();
        }
    }
}
