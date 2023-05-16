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

        public async Task<int> AddClothes(AddClothesViewModel model, int familyId)
        {
            var clothing = new Clothing()
            {
                Name = model.Name,
                Url = model.Url,
                Color = model.Color,
                Size = model.Size,
                SizeHeight = model.SizeHeight,
                Description = model.Description,
                Category = model.Category,
                StorageId = 1
            };

            await repo.AddAsync(clothing);
            await repo.SaveChangesAsync();

            return clothing.Id;
        }

   

        public async Task<IEnumerable<AddClothesViewModel>> AllCategories()
        {
            return null;
        }
    }
}
