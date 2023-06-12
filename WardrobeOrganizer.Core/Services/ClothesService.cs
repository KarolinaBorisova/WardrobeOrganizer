using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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

        public async Task<int> AddClothes(AddOuterwearViewModel model)
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

   

        public async Task<IEnumerable<AddOuterwearViewModel>> AllCategories()
        {
            return null;
        }

        public async Task<ICollection<AllClothesViewModel>> AllClothes(int storageId)
        {
            return await repo.AllReadonly<Clothes>()
             //   .Where(c=>c.StorageId==storageId)
                .Select(c => new AllClothesViewModel()
                {
                    Id=c.Id,
                    Name=c.Name,
                    ImgUrl=c.ImgUrl,
                    Size = c.Size,

                })
                .ToListAsync();
        }
    }
}
