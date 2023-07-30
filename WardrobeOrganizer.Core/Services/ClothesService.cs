using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly IFileService fileService;


        public ClothesService(IRepository _repo,
            IFileService fileService)
        {
            this.repo = _repo;
            this.fileService = fileService;
        }

        public async Task<int> AddClothes(AddClothesViewModel model, string rootPath)
        {
            if (model == null || model.Image == null)
            {
                throw new ArgumentNullException("Clothe is not valid");
            }

            if (model.Image.Length > 2 * 1024 * 1024)
            {
                throw new InvalidOperationException("Image size is too big");
            }

            Guid imgName = Guid.NewGuid();
            var folderName = "clothes";

            var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
            await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

            var clothing = new Clothes()
            {
                Name = model.Name,
                Color = model.Color,
                Size = model.Size,
                SizeHeight = model.SizeHeight,
                Description = model.Description,
                Category = model.Category,
                StorageId = model.StorageId,
                MemberId = model.MemberId,
                ImagePath = $"/images/{folderName}/{imgName}{extention}",
            };
            try
            {
                await repo.AddAsync(clothing);
                await repo.SaveChangesAsync();

                return clothing.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
         
        }

        public async Task<AllClothesViewModel> AllClothes(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
              .Where(c => c.Id == storageId && c.IsActive)
              .Select(c => new AllClothesViewModel()

              {
                  StorageId = storageId,
                  StorageName = c.Name,
                  HouseName = c.House.Name,
                  Clothes = c.Clothes
                  .Where(c => c.IsActive)
                  .Select(cl => new ClothesViewModel
                  {
                      Id = cl.Id,
                      Name = cl.Name,
                      Category = cl.Category,
                      Size = cl.Size,
                      SizeHeight = cl.SizeHeight,
                      StorageId = cl.StorageId,
                      MemberId = cl.MemberId,
                      ImagePath = cl.ImagePath

                  }).ToList()
              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllClothesByCategoryViewModel> AllClothesByCategory(int storageId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Storage>()
              .Where(c => c.Id == storageId && c.IsActive)
              .Select(c => new AllClothesByCategoryViewModel()

              {
                  Category = category,
                  StorageId = storageId,
                  StorageName = c.Name,
                  HouseName = c.House.Name,
                  Clothes = c.Clothes.Where(clt => clt.Category == category && clt.IsActive)
                  .Select(cl => new ClothesViewModel
                  {
                      Name = cl.Name,
                      Category = cl.Category,
                      Id = cl.Id,
                      Size = cl.Size,
                      StorageId = cl.StorageId,
                      SizeHeight = cl.SizeHeight,
                      MemberId = cl.MemberId,
                      ImagePath = cl.ImagePath

                  }).ToList()
              }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public async Task<DetailsClothesViewModel> GetClothesDetailsModelById(int clothingId)
        {
            try
            {
                return await repo.AllReadonly<Clothes>()
            .Include(c => c.Member)
            .Include(c => c.Storage)
            .ThenInclude(s => s.House)
            .Where(c => c.Id == clothingId && c.IsActive)
            .Select(c => new DetailsClothesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category,
                Color = c.Color,
                Size = c.Size,
                SizeHeight = c.SizeHeight,
                StorageName = c.Storage.Name,
                StorageId = c.StorageId,
                HouseName = c.Storage.House.Name,
                HouseId = c.Storage.House.Id,
                ImagePath = c.ImagePath,
                MemberId = c.MemberId,
                MemberName = c.Member.FirstName + " " + c.Member.LastName,


            }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(int clothingId)
        {
            try
            {
                return await repo.AllReadonly<Clothes>()
               .AnyAsync(c => c.Id == clothingId && c.IsActive);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task DeleteById(int clothingId)
        {
            var clothing = await repo.GetByIdAsync<Clothes>(clothingId);

            if (clothing == null)
            {
                throw new ArgumentNullException("Clothing not found");
            }

            clothing.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Edit(EditClothesViewModel model, string rootPath)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Clothing not found");
            }

            var clothing = await repo.GetByIdAsync<Clothes>(model.Id);

            if (clothing == null || clothing.IsActive == false)
            {
                throw new ArgumentNullException("Clothing not found");
            }

            if (model.Image != null)
            {
                if (model.Image.Length > 2 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image size is too big");
                }

                Guid imgName = Guid.NewGuid();
                var folderName = "clothing";

                var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
                await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

                clothing.ImagePath = $"/images/{folderName}/{imgName}{extention}";
            }

            clothing.Id = model.Id;
            clothing.Name = model.Name;
            clothing.Color = model.Color;
            clothing.Description = model.Description;
            clothing.Size = model.Size;
            clothing.SizeHeight = model.SizeHeight;
            clothing.MemberId = model.MemberId;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllMemberClothesViewModel> AllClothesByMemberId(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
          .Where(m => m.Id == memberId && m.IsActive)
          .Select(c => new AllMemberClothesViewModel()

          {
              MemberId = memberId,
              MemberName = c.FirstName + " " + c.LastName,
              Clothes = c.Clothes
              .Where(c => c.IsActive)
              .Select(cl => new ClothesViewModel
              {
                  Name = cl.Name,
                  Category = cl.Category,
                  Id = cl.Id,
                  Size = cl.Size,
                  StorageId = cl.StorageId,
                  SizeHeight = cl.SizeHeight,
                  MemberId = memberId,
                  ImagePath = cl.ImagePath

              }).ToList()
          }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
       
        }

        public async Task<AllMemberClothesByCategoryViewModel> AllClothesByCategoryAndMemberId(int memberId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }
            try
            {
                return await repo.AllReadonly<Member>()
           .Where(m => m.Id == memberId && m.IsActive)
           .Select(c => new AllMemberClothesByCategoryViewModel()

           {
               Category = category,
               MemberName = c.FirstName + " " + c.LastName,
               MemberId = memberId,
               Clothes = c.Clothes.Where(clt => clt.Category == category && clt.IsActive)
               .Select(cl => new ClothesViewModel
               {
                   Name = cl.Name,
                   Category = cl.Category,
                   Id = cl.Id,
                   Size = cl.Size,
                   StorageId = cl.StorageId,
                   SizeHeight = cl.SizeHeight,
                   MemberId = memberId,
                   ImagePath = cl.ImagePath

               }).ToList()
           }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

       // public async Task<EditClothesViewModel> GetClothesEditModelById(int clothingId)
       // {
       //
       //     try
       //     {
       //         return await repo.AllReadonly<Clothes>()
       //          .Include(c => c.Member)
       //          .Where(c => c.Id == clothingId && c.IsActive)
       //          .Select(c => new EditClothesViewModel()
       //          {
       //              Id = clothingId,
       //              Name = c.Name,
       //              Description = c.Description,
       //              Color = c.Color,
       //              Size = c.Size,
       //              SizeHeight = c.SizeHeight,
       //              MemberId = c.MemberId,
       //
       //          }).FirstAsync();
       //     }
       //     catch (Exception ex)
       //     {
       //         throw new InvalidOperationException(ex.Message);
       //     }
       //    
       // }

    }
}
