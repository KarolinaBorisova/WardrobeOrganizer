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



        public async Task<IEnumerable<AddClothesViewModel>> AllCategories()
        {
            return null;
        }

        public async Task<AllClothesByCategoryViewModel> AllClothesByCategory(int storageId, string category)
        {
            return await repo.AllReadonly<Storage>()
                .Where(c => c.Id == storageId)
                .Select(c => new AllClothesByCategoryViewModel()

                {
                    Category = category,
                    StorageId = storageId,
                    Clothes = c.Clothes.Where(clt=>clt.Category == category)
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
                .Where(c => c.Id == storageId)
                .Select(c => new AllClothesViewModel()

                {
                    StorageId = storageId,
                    Clothes = c.Clothes
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

        public async Task<DetailsClothesViewModel> DetailsClothes(int clothingId)
        {
            return await repo.AllReadonly<Clothes>()
                .Where(c => c.Id == clothingId)
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
    }
}
