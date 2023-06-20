using Microsoft.EntityFrameworkCore;
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
            };

            await repo.AddAsync(clothing);
            await repo.SaveChangesAsync();

            return clothing.Id;
        }

        public async Task<AllClothesByCategoryViewModel> AllClothesByCategory(int storageId, string category)
        {
            return await repo.AllReadonly<Storage>()
                .Where(c => c.Id == storageId && c.IsActive)
                .Select(c => new AllClothesByCategoryViewModel()

                {
                    Category = category,
                    StorageId = storageId,
                    Clothes = c.Clothes.Where(clt=>clt.Category == category && clt.IsActive)
                    .Select(cl => new ClothesViewModel
                    {
                        Name = cl.Name,
                        Category = cl.Category,
                        Id = cl.Id,
                        Size = cl.Size,
                        StorageId = cl.StorageId,
                        ImgUrl = cl.ImgUrl
                    }).ToList()
                }).FirstAsync();
        }

        public async Task<AllClothesViewModel> AllClothes(int storageId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(c => c.Id == storageId && c.IsActive)
                .Select(c => new AllClothesViewModel()

                {
                    StorageId = storageId,
                    Clothes = c.Clothes
                    .Where(c=>c.IsActive)
                    .Select(cl => new ClothesViewModel
                    {
                        Name = cl.Name,
                        Category = cl.Category,
                        Id = cl.Id,
                        Size = cl.Size,
                        StorageId = cl.StorageId,
                        ImgUrl = cl.ImgUrl
                    }).ToList()
                }).FirstAsync();
        }

        public async Task<DetailsClothesViewModel> GetClothingById(int clothingId)
        {
            return await repo.AllReadonly<Clothes>()
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
                    StorageId = c.StorageId,
                    ImgUrl = c.ImgUrl

                }).FirstAsync();
        }

        public async Task<bool> ExistsById(int clothingId)
        {
            return await repo.AllReadonly<Clothes>()
                .AnyAsync(c => c.Id == clothingId && c.IsActive);
        }

        public async Task DeleteById(int clothingId)
        {
            if (clothingId == null)
            {
                //nqma dreha
            }
            var clothing = await repo.GetByIdAsync<Clothes>(clothingId);

            if (clothing == null)
            {
                //nqma dreaha
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

        public async Task Edit(DetailsClothesViewModel model)
        {
            if (model == null)
            {
                //nqma dreha
            }
            var clothing = await repo.GetByIdAsync<Clothes>(model.Id);

            if (clothing == null || clothing.IsActive == false)
            {
                //nqma dreaha
            }

                clothing.Id = model.Id;
                clothing.Name = model.Name;
                clothing.ImgUrl = model.ImgUrl;
                clothing.Category = model.Category;
                clothing.Color = model.Color;
                clothing.Description = model.Description;
                clothing.Size = model.Size;
                clothing.SizeHeight = model.SizeHeight;
                clothing.StorageId = model.StorageId;
            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllClothesViewModel> AllClothesByMemberId(int memberId)
        {
            return await repo.AllReadonly<Member>()
               .Where(m => m.Id == memberId && m.IsActive)
               .Select(c => new AllClothesViewModel()

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

        public async Task<AllClothesByCategoryViewModel> AllClothesByCategoryAndMemberId(int memberId, string category)
        {
            return await repo.AllReadonly<Member>()
                .Where(m => m.Id == memberId && m.IsActive)
                .Select(c => new AllClothesByCategoryViewModel()

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
    }
}
