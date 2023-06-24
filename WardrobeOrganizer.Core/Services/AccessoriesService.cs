using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Clothes;
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
                ImgUrl = model.ImgUrl,
                MemberId = model.MemberId
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
                    .Where(a=> a.IsActive == true)
                    .Select(a => new AccessoriesViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        StorageId = a.StorageId,
                        SizeAge = a.SizeAge,
                        Category = a.Category,
                        ImgUrl = a.ImgUrl,
                        MemberId = a.MemberId
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
                    .Where(a=>a.Category == category && a.IsActive == true)
                    .Select(a => new AccessoriesViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        StorageId = a.StorageId,
                        SizeAge = a.SizeAge,
                        Category = a.Category,
                        ImgUrl = a.ImgUrl,
                        MemberId = a.MemberId,

                    }).ToList()
                }).FirstAsync();
        }

        public async Task DeleteById(int accessoriesId)
        {
            if (accessoriesId == null)
            {
                //nqma dreha
            }
            var accessories = await repo.GetByIdAsync<Accessories>(accessoriesId);

            if (accessories == null)
            {
                //nqma dreaha
            }

            accessories.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(EditAccessoriesViewModel model)
        {
            if (model == null)
            {

            }
            var accessorie = await repo.GetByIdAsync<Accessories>(model.Id);

            if (accessorie == null || accessorie.IsActive == false)
            {

            }

            accessorie.Id = model.Id;
            accessorie.Name = model.Name;
            accessorie.Description = model.Description;
            accessorie.SizeAge = model.SizeAge;
            accessorie.Color = model.Color;
            accessorie.ImgUrl = model.ImgUrl;
            accessorie.MemberId = model.MemberId;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExistsById(int accessoriesId)
        {
            return await repo.AllReadonly<Accessories>()
                .AnyAsync(a=>a.Id == accessoriesId && a.IsActive == true);
        }

        public async Task<DetailsAccessoriesViewModel> GetAccessoriesDetailsModelById(int accessoriesId)
        {
            return await repo.AllReadonly<Accessories>()
                .Include(a => a.Member)
                .Include(a => a.Storage)
                .ThenInclude(s => s.House)
                 .Where(a => a.Id == accessoriesId)
                 .Select(a => new DetailsAccessoriesViewModel()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Category = a.Category,
                     Description = a.Description,
                     Color = a.Color,
                     SizeAge = a.SizeAge,
                     StorageId = a.StorageId,
                     ImgUrl = a.ImgUrl,
                     MemberName = a.Member.FirstName + " " + a.Member.LastName,
                     HouseName = a.Storage.House.Name,
                     StorageName = a.Storage.Name
                 }).FirstAsync();
        }
        public async Task<EditAccessoriesViewModel> GetAccessoriesEditModelById(int accessoriesId)
        {
            return await repo.AllReadonly<Accessories>()
                .Include(a => a.Member)
                 .Where(a => a.Id == accessoriesId)
                 .Select(a => new EditAccessoriesViewModel()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Description = a.Description,
                     Color = a.Color,
                     SizeAge = a.SizeAge,
                     ImgUrl = a.ImgUrl,
                     MemberId= a.MemberId

                 }).FirstAsync();
        }

        public async Task<AllMemberAccessoriesViewModel> AllAccessoriesByMemberId(int memberId)
        {
            return await repo.AllReadonly<Member>()
               .Where(m => m.Id == memberId && m.IsActive)
               .Select(c => new AllMemberAccessoriesViewModel()

               {
                   MemberId = memberId,
                   Accessories = c.Accessories
                   .Where(c => c.IsActive)
                   .Select(a => new AccessoriesViewModel
                   {
                       Name = a.Name,
                       Category = a.Category,
                       Id = a.Id,
                       SizeAge = a.SizeAge,
                       StorageId = a.StorageId,
                       ImgUrl = a.ImgUrl,
                       MemberId = memberId,

                   }).ToList()
               }).FirstAsync();
        }

        public async Task<AllMemberAccessoriesByCategoryViewModel> AllAccessoriesByCategoryAndMemberId(int memberId, string category)
        {
            return await repo.AllReadonly<Member>()
                .Where(m => m.Id == memberId && m.IsActive)
                .Select(c => new AllMemberAccessoriesByCategoryViewModel()

                {
                    Category = category,
                    MemberId = memberId,
                    Accessories = c.Accessories
                    .Where(a => a.Category == category && a.IsActive)
                    .Select(ac => new AccessoriesViewModel
                    {
                        Name = ac.Name,
                        Category = ac.Category,
                        Id = ac.Id,
                        SizeAge=ac.SizeAge,
                        StorageId = ac.StorageId,
                        ImgUrl = ac.ImgUrl,
                        MemberId = memberId,

                    }).ToList()
                }).FirstAsync();
        }
    }
}
