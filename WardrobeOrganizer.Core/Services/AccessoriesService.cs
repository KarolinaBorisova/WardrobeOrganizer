using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IRepository repo;

        public AccessoriesService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<int> AddAccessories(AddAccessoriesViewModel model)
        {
            var accessories = new Accessories()
            {
                Name = model.Name,
                SizeAge = model.SizeAge,
                StorageId = model.StorageId,
                Category = model.Category,
                Color = model.Color,
                Description = model.Description,
                ImgUrl = model.ImgUrl
            };

            await repo.AddAsync(accessories);
            await repo.SaveChangesAsync();

            return accessories.Id;
        }

        public async Task<AllAccessoriesViewModel> AllAccessories(int storageId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllAccessoriesViewModel()
                {
                    StorageId = storageId,
                    Accessories = s.Accessories
                    .Select(a => new AccessoriesViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        StorageId = a.StorageId,
                        SizeAge = a.SizeAge,
                        Category = a.Category,
                        ImgUrl = a.ImgUrl
                    }).ToList()
                }).FirstAsync();
        }

        public async Task<AllAccessoriesByCategoryViewModel> AllAccessoriesByCategory(int storageId, string category)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllAccessoriesByCategoryViewModel()
                {
                    Category = category,
                    StorageId = storageId,
                    Accessories = s.Accessories
                    .Where(a=>a.Category == category)
                    .Select(a => new AccessoriesViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        StorageId = a.StorageId,
                        SizeAge = a.SizeAge,
                        Category = a.Category,
                        ImgUrl = a.ImgUrl
                    }).ToList()
                }).FirstAsync();
        }
    }
}
