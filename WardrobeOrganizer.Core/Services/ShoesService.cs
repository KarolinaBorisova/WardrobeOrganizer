using Microsoft.EntityFrameworkCore;
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

        public async Task<AllShoesViewModel> AllShoes(int storageId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllShoesViewModel()
                {
                    StorageId = storageId,
                    Shoes = s.Shoes.Select(sh => new ShoesViewModel()
                    {
                        Id = sh.Id,
                        Name = sh.Name,
                        SizeEu = sh.SizeEu,
                        StorageId = sh.StorageId,
                        Category = sh.Category,
                        Centimetres = sh.Centimetres,
                        ImgUrl = sh.ImgUrl

                    }).ToList()
                }).FirstAsync();
        }

        public async Task<AllShoesByCategoryViewModel> AllShoesByCategory(int storageId, string category)
        {
           return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllShoesByCategoryViewModel()
                {
                    StorageId = storageId,
                    Category = category,
                    Shoes = s.Shoes.Where(sh => sh.Category == category)
                    .Select(sh => new ShoesViewModel()
                    {
                        Id = sh.Id,
                        Name = sh.Name,
                        SizeEu = sh.SizeEu,
                        StorageId = sh.StorageId,
                        Category = sh.Category,
                        Centimetres = sh.Centimetres,
                        ImgUrl = sh.ImgUrl
                    }).ToList()
                }).FirstAsync();
        }

        public Task DeleteById(int shoesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(int shoesId)
        {
            throw new NotImplementedException();
        }

        public async Task<DetailsShoesViewModel> GetShoesById(int shoesId)
        {
            return await repo.AllReadonly<Shoes>()
                .Where(s => s.Id == shoesId)
                .Select(s => new DetailsShoesViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    SizeEu = s.SizeEu,
                    Centimetres = s.Centimetres,
                    Category = s.Category,
                    Description = s.Description,
                    Color = s.Color,
                    StorageId = s.StorageId,
                    ImgUrl = s.ImgUrl
                }).FirstAsync();
        }
    }
}
