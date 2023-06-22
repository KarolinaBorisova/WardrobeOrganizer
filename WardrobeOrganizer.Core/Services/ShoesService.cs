using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Outerwear;
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
                Category = model.Category,
                MemberId = model.MemberId
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
                    Shoes = s.Shoes
                    .Where(sh=>sh.IsActive == true)
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

        public async Task<AllShoesByCategoryViewModel> AllShoesByCategory(int storageId, string category)
        {
           return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllShoesByCategoryViewModel()
                {
                    StorageId = storageId,
                    Category = category,
                    Shoes = s.Shoes.Where(sh => sh.Category == category && sh.IsActive == true)
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

        public async Task DeleteById(int shoesId)
        {
            if (shoesId == null)
            {

            }
            var shoes = await repo.GetByIdAsync<Shoes>(shoesId);

            if (shoes == null)
            {

            }

            shoes.IsActive = false;
            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(DetailsShoesViewModel model)
        {
            if (model == null)
            {

            }
            var shoes = await repo.GetByIdAsync<Shoes>(model.Id);
            if (shoes == null)
            {

            }
            shoes.Name = model.Name;
            shoes.Centimetres = model.Centimetres;
            shoes.SizeEu = model.SizeEu;
            shoes.Description = model.Description;
            shoes.Category = model.Category;
            shoes.Color = model.Color;
            shoes.StorageId = model.StorageId;
            shoes.ImgUrl = model.ImgUrl;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> ExistsById(int shoesId)
        {
            return await repo.AllReadonly<Shoes>()
                .AnyAsync(sh => sh.Id == shoesId && sh.IsActive == true);
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

        public async Task<AllShoesViewModel> AllShoesByMemberId(int memberId)
        {
            return await repo.AllReadonly<Member>()
               .Where(m => m.Id == memberId && m.IsActive)
               .Select(sh => new AllShoesViewModel()

               {
                   MemberId = memberId,
                   Shoes = sh.Shoes
                   .Where(sh => sh.IsActive)
                   .Select(cl => new ShoesViewModel
                   {
                       Name = cl.Name,
                       Category = cl.Category,
                       Id = cl.Id,
                       SizeEu= cl.SizeEu,
                       Centimetres= cl.Centimetres,
                       StorageId = cl.StorageId,
                       ImgUrl = cl.ImgUrl,
                       MemberId = memberId

                   }).ToList()
               }).FirstAsync();
        }

        public async Task<AllShoesByCategoryViewModel> AllShoesByCategoryAndMemberId(int memberId, string category)
        {
            return await repo.AllReadonly<Member>()
                .Where(m => m.Id == memberId && m.IsActive)
                .Select(s => new AllShoesByCategoryViewModel()

                {
                    Category = category,
                    MemberId = memberId,
                    Shoes = s.Shoes
                    .Where(sh=> sh.Category == category && sh.IsActive)
                    .Select(s => new ShoesViewModel
                    {
                        Name = s.Name,
                        Category = s.Category,
                        Id = s.Id,
                        SizeEu = s.SizeEu,
                        Centimetres = s.Centimetres,
                        StorageId = s.StorageId,
                        ImgUrl = s.ImgUrl,
                        MemberId = memberId,
                    }).ToList()
                }).FirstAsync();
        }
    }
}
