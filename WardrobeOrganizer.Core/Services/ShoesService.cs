using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class ShoesService : IShoesService
    {
        private readonly IRepository repo;

        public ShoesService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<int> AddShoes(AddShoesViewModel model)
        {
            var shoes = new Shoes()
            {
                Name = model.Name,
                Description = model.Description,
                SizeEu = model.SizeEu,
                Centimetres = model.Centimetres,
                ImgUrl = model.ImgUrl,
                Color = model.Color,
                StorageId = model.StorageId,
                Category = model.Category
            };

            await repo.AddAsync(shoes);
            await repo.SaveChangesAsync();

            return shoes.Id;

        }
    }
}
