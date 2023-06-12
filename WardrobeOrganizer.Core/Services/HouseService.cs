﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Member;
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

        public async Task<int> AddHouse(AddHouseViewModel model, int familiId)
        {
            var house = new House()
            {
                Name = model.Name,
                Address = model.Address,
                FamilyId = familiId
            };

            try
            {
                await repo.AddAsync(house);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

          

            return house.Id;
        }

        public async Task<ICollection<AllHousesViewModel>> AllHouses(int familyId)
        {
            return await repo.AllReadonly<House>()
                .Where(h => h.FamilyId == familyId && h.IsActive)
                .OrderBy(x => x.Name)
               .Select(s => new AllHousesViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Address = s.Address,
                    

               }).ToListAsync();
        }

        public async Task Delete(int houseId)
        {
            if (houseId == null)
            {
                //nqma kushta
            }
            var house = await repo.GetByIdAsync<House>(houseId);

            if (house == null)
            {
                //nqma kushta
            }

            house.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(InfoHouseViewModel model)
        {
            try
            {
                var house = await repo.GetByIdAsync<House>(model.Id);
                house.Name = model.Name;
                house.Address = model.Address;
                house.Id = model.Id;

                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(int houseId)
        {
            return await repo.AllReadonly<House>()
              .AnyAsync(h => h.Id == houseId);
        }

        public async Task<InfoHouseViewModel?> GetHouseById(int houseId)
        {
            if (houseId == null)
            {

            }
            try
            {
                return await repo.AllReadonly<House>()
               .Where(h => h.Id == houseId)
               .Select(h => new InfoHouseViewModel()
               {
                   Id = h.Id,
                   Address = h.Address,
                   FamilyId = h.FamilyId,
                   Name = h.Name,
               })
               .FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
         
            
        }


        public async Task<int> GetHouseId(string userId)
        {
            return (await repo.AllReadonly<Family>()
                   .FirstOrDefaultAsync(f => f.UserId == userId))?.Id ?? 0;

        }
    }
}
