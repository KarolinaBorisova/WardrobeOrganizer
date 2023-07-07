﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class ClothesService : IClothesService
    {

        private readonly IRepository repo;

        public ClothesService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<int> AddClothes(AddClothesViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Not valid clothes");
            }
            var clothing = new Clothes()
            {
                Name = model.Name,
                ImgUrl = model.ImgUrl,
                Color = model.Color,
                Size = model.Size,
                SizeHeight = model.SizeHeight,
                Description = model.Description,
                Category = model.Category,
                StorageId = model.StorageId,
                MemberId = model.MemberId,               
            };
            try
            {
                await repo.AddAsync(clothing);
                await repo.SaveChangesAsync();

                return clothing.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
         
        }

        public async Task<AllClothesViewModel> AllClothes(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
              .Where(c => c.Id == storageId && c.IsActive)
              .Select(c => new AllClothesViewModel()

              {
                  StorageId = storageId,
                  Clothes = c.Clothes
                  .Where(c => c.IsActive)
                  .Select(cl => new ClothesViewModel
                  {
                      Id = cl.Id,
                      Name = cl.Name,
                      ImgUrl = cl.ImgUrl,
                      Category = cl.Category,
                      Size = cl.Size,
                      SizeHeight = cl.SizeHeight,
                      StorageId = cl.StorageId,
                      MemberId = cl.MemberId

                  }).ToList()
              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllClothesByCategoryViewModel> AllClothesByCategory(int storageId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Storage>()
              .Where(c => c.Id == storageId && c.IsActive)
              .Select(c => new AllClothesByCategoryViewModel()

              {
                  Category = category,
                  StorageId = storageId,
                  Clothes = c.Clothes.Where(clt => clt.Category == category && clt.IsActive)
                  .Select(cl => new ClothesViewModel
                  {
                      Name = cl.Name,
                      Category = cl.Category,
                      Id = cl.Id,
                      Size = cl.Size,
                      StorageId = cl.StorageId,
                      ImgUrl = cl.ImgUrl,
                      MemberId = cl.MemberId

                  }).ToList()
              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public async Task<DetailsClothesViewModel> GetClothesDetailsModelById(int clothingId)
        {
            try
            {
                return await repo.AllReadonly<Clothes>()
            .Include(c => c.Member)
            .Include(c => c.Storage)
            .ThenInclude(s => s.House)
            .Where(c => c.Id == clothingId && c.IsActive)
            .Select(c => new DetailsClothesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category,
                Color = c.Color,
                Size = c.Size,
                SizeHeight = c.SizeHeight,
                StorageName = c.Storage.Name,
                StorageId = c.StorageId,
                HouseName = c.Storage.House.Name,
                ImgUrl = c.ImgUrl,
                MemberId = c.MemberId,
                MemberName = c.Member.FirstName + " " + c.Member.LastName

            }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(int clothingId)
        {
            try
            {
                return await repo.AllReadonly<Clothes>()
               .AnyAsync(c => c.Id == clothingId && c.IsActive);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task DeleteById(int clothingId)
        {
            var clothing = await repo.GetByIdAsync<Clothes>(clothingId);

            if (clothing == null)
            {
                throw new ArgumentNullException("Clothing not found");
            }

            clothing.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(EditClothesViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Clothing not found");
            }

            var clothing = await repo.GetByIdAsync<Clothes>(model.Id);

            if (clothing == null || clothing.IsActive == false)
            {
                throw new ArgumentNullException("Clothing not found");
            }

                clothing.Id = model.Id;
                clothing.Name = model.Name;
                clothing.ImgUrl = model.ImgUrl;
                clothing.Color = model.Color;
                clothing.Description = model.Description;
                clothing.Size = model.Size;
                clothing.SizeHeight = model.SizeHeight;
                clothing.MemberId = model.MemberId;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllMemberClothesViewModel> AllClothesByMemberId(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
          .Where(m => m.Id == memberId && m.IsActive)
          .Select(c => new AllMemberClothesViewModel()

          {
              MemberId = memberId,
              Clothes = c.Clothes
              .Where(c => c.IsActive)
              .Select(cl => new ClothesViewModel
              {
                  Name = cl.Name,
                  Category = cl.Category,
                  Id = cl.Id,
                  Size = cl.Size,
                  StorageId = cl.StorageId,
                  ImgUrl = cl.ImgUrl,
                  MemberId = memberId

              }).ToList()
          }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
       
        }

        public async Task<AllMemberClothesByCategoryViewModel> AllClothesByCategoryAndMemberId(int memberId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }
            try
            {
                return await repo.AllReadonly<Member>()
           .Where(m => m.Id == memberId && m.IsActive)
           .Select(c => new AllMemberClothesByCategoryViewModel()

           {
               Category = category,
               MemberId = memberId,
               Clothes = c.Clothes.Where(clt => clt.Category == category && clt.IsActive)
               .Select(cl => new ClothesViewModel
               {
                   Name = cl.Name,
                   Category = cl.Category,
                   Id = cl.Id,
                   Size = cl.Size,
                   StorageId = cl.StorageId,
                   ImgUrl = cl.ImgUrl,
                   MemberId = memberId,

               }).ToList()
           }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<EditClothesViewModel> GetClothesEditModelById(int clothingId)
        {

            try
            {
                return await repo.AllReadonly<Clothes>()
                 .Include(c => c.Member)
                 .Where(c => c.Id == clothingId && c.IsActive)
                 .Select(c => new EditClothesViewModel()
                 {
                     Id = clothingId,
                     Name = c.Name,
                     Description = c.Description,
                     Color = c.Color,
                     Size = c.Size,
                     SizeHeight = c.SizeHeight,
                     ImgUrl = c.ImgUrl,
                     MemberId = c.MemberId,

                 }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }
    }
}
