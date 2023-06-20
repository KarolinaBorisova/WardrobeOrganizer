using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class OuterwearService : IOuterwearService
    {
        private readonly IRepository repo;

        public OuterwearService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> AddOuterWear(AddOuterwearViewModel model)
        {
            var outerwear = new Outerwear()
            {
                ImgUrl = model.ImgUrl,
                Description = model.Description,
                Name = model.Name,
                Size = model.Size,
                SizeHeight = model.SizeHeight,
                Category = model.Category,
                Color = model.Color,
                StorageId = model.StorageId,

            };
            await repo.AddAsync(outerwear);
            await repo.SaveChangesAsync();

            return outerwear.Id;
        }

        public async Task<AllOuterwearViewModel> AllOutwear(int storageId)
        {
            return await repo.AllReadonly<Storage>()
                 .Where(s => s.Id == storageId)
                 .Select(ow => new AllOuterwearViewModel()
                 {
                     StorageId = storageId,
                     Outerwear = ow.Outerwear
                     .Where(o=>o.IsActive == true)
                     .Select(o => new OuterwearViewModel()
                     {
                         Id = o.Id,
                         Name = o.Name,
                         ImgUrl = o.ImgUrl,
                         StorageId = storageId,
                         Size = o.Size,
                         SizeHeight = o.SizeHeight,
                         Category = o.Category,
                     }).ToList()
                 }).FirstAsync();
        }

        public async Task<AllOuterwearByCategoryViewModel> AllOuterwearByCategory(int storageId, string category)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllOuterwearByCategoryViewModel()
                {
                    StorageId = storageId,
                    Category = category,
                    Outerwear = s.Outerwear.Where(ow => ow.Category == category && ow.IsActive == true)
                    .Select(o => new OuterwearViewModel()
                    {
                        Id = o.Id,
                        Size = o.Size,
                        SizeHeight = o.SizeHeight,
                        StorageId = o.StorageId,
                        Category = category,
                        ImgUrl = o.ImgUrl,
                        Name = o.Name
                    }).ToList()
                }).FirstAsync();
        }

        public async Task<DetailsOuterwearViewModel> GetOuterwearById(int outerwearId)
        {
            return await repo.AllReadonly<Outerwear>()
                .Where(o => o.Id == outerwearId)
                .Select(o => new DetailsOuterwearViewModel()
                {
                    Id = o.Id,
                    Name = o.Name,
                    ImgUrl = o.ImgUrl,
                    Description = o.Description,
                    Category = o.Category,
                    Size = o.Size,
                    SizeHeight = o.SizeHeight,
                    StorageId = o.StorageId,
                    Color = o.Color
                }).FirstAsync();
        }

        public async Task<bool> ExistsById(int outerwearId)
        {
            return await repo.AllReadonly<Outerwear>()
                .AnyAsync(o => o.Id == outerwearId && o.IsActive);
        }

        public async Task DeleteById(int outerwearId)
        {
            if (outerwearId == null)
            {

            }

            var outerwear = await repo.GetByIdAsync<Outerwear>(outerwearId);

            if (outerwear == null)
            {

            }

            outerwear.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(DetailsOuterwearViewModel model)
        {
            if (model == null)
            {

            }
            var outerwear = await repo.GetByIdAsync<Outerwear>(model.Id);
            if (outerwear == null)
            {

            }
            outerwear.Name = model.Name;
            outerwear.ImgUrl = model.ImgUrl;
            outerwear.SizeHeight = model.SizeHeight;
            outerwear.Category = model.Category;
            outerwear.Color = model.Color;
            outerwear.Description = model.Description;
            outerwear.StorageId = model.StorageId;
            outerwear.Size = model.Size;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AllOuterwearViewModel> AllOuterwearByMemberId(int memberId)
        {
            return await repo.AllReadonly<Member>()
               .Where(m => m.Id == memberId && m.IsActive)
               .Select(o => new AllOuterwearViewModel()

               {
                   MemberId = memberId, 
                   Outerwear = o.Outerwear
                   .Where(o => o.IsActive)
                   .Select(cl => new OuterwearViewModel
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

        public async Task<AllOuterwearByCategoryViewModel> AllOuterwearByCategoryAndMemberId(int memberId, string category)
        {
            return await repo.AllReadonly<Member>()
                .Where(m => m.Id == memberId && m.IsActive)
                .Select(c => new AllOuterwearByCategoryViewModel()

                {
                    Category = category,
                    MemberId = memberId,
                    Outerwear = c.Outerwear.Where(clt => clt.Category == category && clt.IsActive)
                    .Select(cl => new OuterwearViewModel
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
