using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IRepository repo;
        private readonly IFileService fileService;



        public AccessoriesService(IRepository _repo,
            IFileService fileService)
        {
            this.repo = _repo;
            this.fileService = fileService;
        }

        public async Task<int> AddAccessories(AddAccessoriesViewModel model, string rootPath)
        {
            if (model == null || model.Image == null)
            {
                throw new ArgumentNullException("Accessorie is not valid");
            }

            if (model.Image.Length > 2 * 1024 * 1024)
            {
                throw new InvalidOperationException("Image size is too big");
            }

            Guid imgName = Guid.NewGuid();
            var folderName = "accessories";

            var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
            await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

            var accessories = new Accessories()
            {
                Name = model.Name,
                SizeAge = model.SizeAge,
                StorageId = model.StorageId,
                Category = model.Category,
                Color = model.Color,
                Description = model.Description,
                ImagePath = $"/images/{folderName}/{imgName}{extention}",
                MemberId = model.MemberId,
                UserId = model.UserId,
            };

            try
            {
                await repo.AddAsync(accessories);
                await repo.SaveChangesAsync();

                return accessories.Id;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllAccessoriesViewModel> AllAccessories(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
            .Where(s => s.Id == storageId)
            .Select(s => new AllAccessoriesViewModel()
            {
                StorageId = storageId,
                StorageName = s.Name,
                HouseName = s.House.Name,
                Accessories = s.Accessories
                .Where(a => a.IsActive == true)
                .Select(a => new AccessoriesViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    StorageId = a.StorageId,
                    SizeAge = a.SizeAge,
                    Category = a.Category,
                    ImagePath = a.ImagePath,
                    MemberId = a.MemberId
                }).ToList()
            }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        
        }

        public async Task<AllAccessoriesByCategoryViewModel> AllAccessoriesByCategory(int storageId, string category)
        {
            if ( category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Storage>()
               .Where(s => s.Id == storageId)
               .Select(s => new AllAccessoriesByCategoryViewModel()
               {
                   Category = category,
                   StorageId = storageId,
                   StorageName = s.Name,
                   HouseName = s.House.Name,
                   Accessories = s.Accessories
                   .Where(a => a.Category == category && a.IsActive == true)
                   .Select(a => new AccessoriesViewModel()
                   {
                       Id = a.Id,
                       Name = a.Name,
                       StorageId = a.StorageId,
                       SizeAge = a.SizeAge,
                       Category = a.Category,
                       ImagePath = a.ImagePath,
                       MemberId = a.MemberId,

                   }).ToList()
               }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task DeleteById(int accessoriesId)
        {
            var accessories = await repo.GetByIdAsync<Accessories>(accessoriesId);

            if (accessories == null)
            {
                throw new ArgumentNullException("Accessorie not found");
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

        public async Task Edit(EditAccessoriesViewModel model , string rootPath)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Accessorie not found");
            }
            var accessorie = await repo.GetByIdAsync<Accessories>(model.Id);

            if (accessorie == null || accessorie.IsActive == false)
            {
                throw new ArgumentNullException("Accessorie not found");
            }

            if (model.Image != null)
            {
                if (model.Image.Length > 2 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image size is too big");
                }

                Guid imgName = Guid.NewGuid();
                var folderName = "accessories";

                var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
                await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

                accessorie.ImagePath = $"/images/{folderName}/{imgName}{extention}";
            }

            accessorie.Id = model.Id;
            accessorie.Name = model.Name;
            accessorie.Description = model.Description;
            accessorie.SizeAge = model.SizeAge;
            accessorie.Color = model.Color;        
            accessorie.MemberId = model.MemberId;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(int accessoriesId)
        {
            try
            {
                return await repo.AllReadonly<Accessories>()
              .AnyAsync(a => a.Id == accessoriesId && a.IsActive == true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
          
        }

        public async Task<DetailsAccessoriesViewModel> GetAccessoriesDetailsModelById(int accessoriesId)
        {
            try
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
                   ImagePath = a.ImagePath,
                   MemberName = a.Member.FirstName + " " + a.Member.LastName,
                   HouseName = a.Storage.House.Name,
                   StorageName = a.Storage.Name,
                   MemberId = a.MemberId,
                   HouseId = a.Storage.HouseId,
                   UserId = a.UserId

               }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
          
        }
     //  public async Task<EditAccessoriesViewModel> GetAccessoriesEditModelById(int accessoriesId)
     //  {
     //      try
     //      {
     //          return await repo.AllReadonly<Accessories>()
     //      .Include(a => a.Member)
     //       .Where(a => a.Id == accessoriesId)
     //       .Select(a => mapper.Map<EditAccessoriesViewModel>(a)).FirstAsync();
     //      }
     //      catch (Exception ex)
     //      {
     //          throw new InvalidOperationException(ex.Message);
     //      }
     //  }

        public async Task<AllMemberAccessoriesViewModel> AllAccessoriesByMemberId(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
             .Where(m => m.Id == memberId && m.IsActive)
             .Select(c => new AllMemberAccessoriesViewModel()

             {
                 MemberId = memberId,
                 MemberName = c.FirstName + " " + c.LastName,
                 Accessories = c.Accessories
                 .Where(c => c.IsActive)
                 .Select(a => new AccessoriesViewModel
                 {
                     Name = a.Name,
                     Category = a.Category,
                     Id = a.Id,
                     SizeAge = a.SizeAge,
                     StorageId = a.StorageId,
                     ImagePath = a.ImagePath,
                     MemberId = memberId,

                 }).ToList()
             }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
          
        }

        public async Task<AllMemberAccessoriesByCategoryViewModel> AllAccessoriesByCategoryAndMemberId(int memberId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Member>()
              .Where(m => m.Id == memberId && m.IsActive)
              .Select(c => new AllMemberAccessoriesByCategoryViewModel()

              {
                  Category = category,
                  MemberId = memberId,
                  MemberName = c.FirstName + " " + c.LastName,
                  Accessories = c.Accessories
                  .Where(a => a.Category == category && a.IsActive)
                  .Select(ac => new AccessoriesViewModel
                  {
                      Name = ac.Name,
                      Category = ac.Category,
                      Id = ac.Id,
                      SizeAge = ac.SizeAge,
                      StorageId = ac.StorageId,
                      ImagePath = ac.ImagePath,
                      MemberId = memberId,

                  }).ToList()
              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
          
        }
    }
}
