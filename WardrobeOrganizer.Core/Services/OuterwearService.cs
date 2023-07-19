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
        private readonly IFileService fileService;

        public OuterwearService(IRepository _repo, IFileService fileService)
        {
            repo = _repo;
            this.fileService = fileService;
        }

        public async Task<int> AddOuterWear(AddOuterwearViewModel model, string rootPath)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Outerwear is not valid");
            }

            Guid imgName = Guid.NewGuid();
            var folderName = "outerwear";


            var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
            await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

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
                MemberId = model.MemberId,
                ImagePath = $"/images/{folderName}/{imgName}{extention}",

            };

            try
            {
                await repo.AddAsync(outerwear);
                await repo.SaveChangesAsync();

                return outerwear.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task<AllOuterwearViewModel> AllOutwear(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(ow => new AllOuterwearViewModel()
                {
                    StorageId = storageId,
                    StorageName = ow.Name,
                    HouseName = ow.House.Name,
                    Outerwear = ow.Outerwear
                    .Where(o => o.IsActive == true)
                    .Select(o => new OuterwearViewModel()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        ImgUrl = o.ImgUrl,
                        StorageId = storageId,
                        Size = o.Size,
                        SizeHeight = o.SizeHeight,
                        Category = o.Category,
                        MemberId = o.MemberId,
                        ImagePath = o.ImagePath,

                    }).ToList()
                }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task<AllOuterwearByCategoryViewModel> AllOuterwearByCategory(int storageId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllOuterwearByCategoryViewModel()
                    {
                         StorageId = storageId,
                         Category = category,
                         StorageName = s.Name,
                         HouseName = s.House.Name,
                         Outerwear = s.Outerwear.Where(ow => ow.Category == category && ow.IsActive == true)
                 .Select(o => new OuterwearViewModel()
                         {
                     Id = o.Id,
                     Size = o.Size,
                     SizeHeight = o.SizeHeight,
                     StorageId = o.StorageId,
                     Category = category,
                     ImgUrl = o.ImgUrl,
                     ImagePath = o.ImagePath,
                     Name = o.Name,
                         }).ToList()
                     }).FirstAsync();

        }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }                   

        public async Task<DetailsOuterwearViewModel> GetOuterwearDetailsModelById(int outerwearId)
        {
            try
            {
                return await repo.AllReadonly<Outerwear>()
             .Include(o => o.Member)
             .Include(o => o.Storage)
             .ThenInclude(s => s.House)
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
                 Color = o.Color,
                 HouseName = o.Storage.House.Name,
                 StorageName = o.Storage.Name,
                 MemberName = o.Member.FirstName + " " + o.Member.LastName,
                 MemberId = o.MemberId,
                 HouseId = o.Storage.HouseId

             }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
         
        }

        public async Task<EditOuterwearViewModel> GetOuterwearEditModelById(int outerwearId)
        {
            try
            {
                return await repo.AllReadonly<Outerwear>()
             .Include(o => o.Member)
             .Include(o => o.Storage)
             .ThenInclude(s => s.House)
             .Where(o => o.Id == outerwearId)
             .Select(o => new EditOuterwearViewModel()
             {
                 Id = o.Id,
                 Name = o.Name,
                 ImgUrl = o.ImgUrl,
                 Description = o.Description,
                 Size = o.Size,
                 SizeHeight = o.SizeHeight,
                 Color = o.Color,
                 MemberId = o.MemberId

             }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
         
        }


        public async Task<bool> ExistsById(int outerwearId)
        {
            try
            {
                return await repo.AllReadonly<Outerwear>()
               .AnyAsync(o => o.Id == outerwearId && o.IsActive);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task DeleteById(int outerwearId)
        {

            var outerwear = await repo.GetByIdAsync<Outerwear>(outerwearId);

            if (outerwear == null)
            {
                throw new ArgumentNullException("Outerwear not found");
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

        public async Task Edit(EditOuterwearViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Outerwear is not valid");
            }

            var outerwear = await repo.GetByIdAsync<Outerwear>(model.Id);
            if (outerwear == null)
            {
                throw new ArgumentNullException("Outerwear not found");
            }
            outerwear.IsActive = true;
            outerwear.Name = model.Name;
            outerwear.ImgUrl = model.ImgUrl;
            outerwear.SizeHeight = model.SizeHeight;
            outerwear.Size = model.Size;
            outerwear.Color = model.Color;
            outerwear.Description = model.Description;
            outerwear.MemberId = model.MemberId;
          
   
            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AllMemberOuterwearViewModel> AllOuterwearByMemberId(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
             .Where(m => m.Id == memberId && m.IsActive)
             .Select(o => new AllMemberOuterwearViewModel()

             {
                 MemberId = memberId,
                 MemberName = o.FirstName + " " + o.LastName,
                 Outerwear = o.Outerwear
                 .Where(o => o.IsActive)
                 .Select(cl => new OuterwearViewModel
                 {
                     Name = cl.Name,
                     Category = cl.Category,
                     Id = cl.Id,
                     Size = cl.Size,
                     SizeHeight = cl.SizeHeight,
                     StorageId = cl.StorageId,
                     ImgUrl = cl.ImgUrl,
                     ImagePath = cl.ImagePath,
                     MemberId = memberId,


                 }).ToList()
             }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
          
        }

        public async Task<AllMemberOutwearByCategoryViewModel> AllOuterwearByCategoryAndMemberId(int memberId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Member>()
               .Where(m => m.Id == memberId && m.IsActive)
               .Select(c => new AllMemberOutwearByCategoryViewModel()

               {
                   Category = category,
                   MemberName = c.FirstName + " " + c.LastName,
                   MemberId = memberId,
                   Outerwear = c.Outerwear.Where(clt => clt.Category == category && clt.IsActive)
                   .Select(cl => new OuterwearViewModel
                   {
                       Name = cl.Name,
                       Category = cl.Category,
                       Id = cl.Id,
                       Size = cl.Size,
                       SizeHeight = cl.SizeHeight,
                       StorageId = cl.StorageId,
                       ImgUrl = cl.ImgUrl,
                       ImagePath = cl.ImagePath,
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
