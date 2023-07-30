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
        private readonly IFileService fileService;


        public ShoesService(IRepository _repo,
            IFileService fileService)
        {
            this.repo = _repo;
            this.fileService = fileService;
        }

        public async Task<int> AddShoes(AddShoesViewModel model, string rootPath)
        {
            if (model == null || model.Image == null)
            {
                throw new ArgumentNullException("Shoes is not valid");
            }

            if (model.Image.Length > 2 * 1024 * 1024)
            {
                throw new InvalidOperationException("Image size is too big");
            }

            Guid imgName = Guid.NewGuid();
            var folderName = "shoes";

            var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
            await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

            var shoes = new Shoes()
            {
                Name = model.Name,
                Description = model.Description,
                SizeEu = model.SizeEu,
                Centimetres = model.Centimetres,
                ImagePath = $"/images/{folderName}/{imgName}{extention}",
                Color = model.Color,
                StorageId = model.StorageId,
                Category = model.Category,
                MemberId = model.MemberId,
           
            };

            try
            {
                await repo.AddAsync(shoes);
                await repo.SaveChangesAsync();

                return shoes.Id;
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
          

        }

        public async Task<AllShoesViewModel> AllShoes(int storageId)
        {
            try
            {
                return await repo.AllReadonly<Storage>()
            .Where(s => s.Id == storageId)
            .Select(s => new AllShoesViewModel()
            {
                StorageId = storageId,
                StorageName = s.Name,
                HouseName = s.House.Name,
                Shoes = s.Shoes
                .Where(sh => sh.IsActive == true)
                .Select(sh => new ShoesViewModel()
                {
                    Id = sh.Id,
                    Name = sh.Name,
                    SizeEu = sh.SizeEu,
                    StorageId = sh.StorageId,
                    Category = sh.Category,
                    Centimetres = sh.Centimetres,
                    ImagePath = sh.ImagePath,
                    MemberId = sh.MemberId

                }).ToList()
            }).FirstAsync();

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        
        }

        public async Task<AllShoesByCategoryViewModel> AllShoesByCategory(int storageId, string category)
        {
            if (category== null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Storage>()
                .Where(s => s.Id == storageId)
                .Select(s => new AllShoesByCategoryViewModel()
                {
                    StorageId = storageId,
                    Category = category,
                    StorageName = s.Name,
                    HouseName = s.House.Name,
                    Shoes = s.Shoes.Where(sh => sh.Category == category && sh.IsActive == true)
                    .Select(sh => new ShoesViewModel()
                    {
                        Id = sh.Id,
                        Name = sh.Name,
                        SizeEu = sh.SizeEu,
                        StorageId = sh.StorageId,
                        Category = sh.Category,
                        Centimetres = sh.Centimetres,
                        ImagePath = sh.ImagePath,
                        MemberId = sh.MemberId,


                    }).ToList()
                }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task DeleteById(int shoesId)
        {
            var shoes = await repo.GetByIdAsync<Shoes>(shoesId);

            if (shoes == null)
            {
                throw new ArgumentNullException("Shoes not found");
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

        public async Task Edit(EditShoesViewModel model , string rootPath)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Shoes are not valid");
            }
            var shoes = await repo.GetByIdAsync<Shoes>(model.Id);

            if (shoes == null || shoes.IsActive == false)
            {
                throw new ArgumentNullException("Shoes not found");
            }

            if (model.Image != null)
            {
                if (model.Image.Length > 2 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image size is too big");
                }

                Guid imgName = Guid.NewGuid();
                var folderName = "shoes";

                var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
                await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

                shoes.ImagePath = $"/images/{folderName}/{imgName}{extention}";
            }
            shoes.Name = model.Name;
            shoes.Centimetres = model.Centimetres;
            shoes.SizeEu = model.SizeEu;
            shoes.Description = model.Description;
            shoes.Color = model.Color;
            shoes.MemberId = model.MemberId;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }

        }

        public async Task<bool> ExistsById(int shoesId)
        {
            try
            {
                return await repo.AllReadonly<Shoes>()
             .AnyAsync(sh => sh.Id == shoesId && sh.IsActive == true);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
         
        }

        public async Task<DetailsShoesViewModel> GetShoesDetailsModelById(int shoesId)
        {
            try
            {
                return await repo.AllReadonly<Shoes>()
               .Include(s => s.Member)
               .Include(c => c.Storage)
               .ThenInclude(s => s.House)
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
                   ImagePath = s.ImagePath,
                   MemberName = s.Member.FirstName + " " + s.Member.LastName,
                   StorageName = s.Storage.Name,
                   HouseName = s.Storage.House.Name,
                   MemberId = s.MemberId,
                   HouseId = s.Storage.HouseId

               }).FirstAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
           
        }

      //public async Task<EditShoesViewModel> GetShoesEditModelById(int shoesId)
      //{
      //    try
      //    {
      //        return await repo.AllReadonly<Shoes>()
      //       .Include(s => s.Member)
      //       .Include(c => c.Storage)
      //       .ThenInclude(s => s.House)
      //       .Where(s => s.Id == shoesId)
      //       .Select(s => new EditShoesViewModel()
      //       {
      //           Id = s.Id,
      //           Name = s.Name,
      //           SizeEu = s.SizeEu,
      //           Centimetres = s.Centimetres,
      //           Description = s.Description,
      //           Color = s.Color,
      //           MemberId = s.MemberId,
      //
      //
      //
      //       }).FirstAsync();
      //    }
      //    catch (Exception ex)
      //    {
      //        throw new InvalidOperationException(ex.Message);
      //    }
      //
      //}

        public async Task<AllMemberShoesViewModel> AllShoesByMemberId(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
            .Where(m => m.Id == memberId && m.IsActive)
            .Select(sh => new AllMemberShoesViewModel()

            {
                MemberId = memberId,
                MemberName = sh.FirstName + " " + sh.LastName,
                Shoes = sh.Shoes
                .Where(sh => sh.IsActive)
                .Select(cl => new ShoesViewModel
                {
                    Name = cl.Name,
                    Category = cl.Category,
                    Id = cl.Id,
                    SizeEu = cl.SizeEu,
                    Centimetres = cl.Centimetres,
                    StorageId = cl.StorageId,
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

        public async Task<AllMemberShoesByCategoryViewModel> AllShoesByCategoryAndMemberId(int memberId, string category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            try
            {
                return await repo.AllReadonly<Member>()
           .Where(m => m.Id == memberId && m.IsActive)
           .Select(s => new AllMemberShoesByCategoryViewModel()

           {
               MemberId = memberId,
               MemberName = s.FirstName + " " + s.LastName,
               Category = category,
               Shoes = s.Shoes
               .Where(sh => sh.Category == category && sh.IsActive)
               .Select(s => new ShoesViewModel
               {
                   Name = s.Name,
                   Category = s.Category,
                   Id = s.Id,
                   SizeEu = s.SizeEu,
                   Centimetres = s.Centimetres,
                   StorageId = s.StorageId,
                   ImagePath = s.ImagePath,
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
