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
            if (model == null)
            {
                throw new ArgumentNullException("Shoes are not valid");
            }
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
                    ImgUrl = sh.ImgUrl,
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
                        ImgUrl = sh.ImgUrl,
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

        public async Task Edit(EditShoesViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Shoes are not valid");
            }
            var shoes = await repo.GetByIdAsync<Shoes>(model.Id);

            if (shoes == null)
            {
                throw new ArgumentNullException("Shoes not found");
            }
            shoes.Name = model.Name;
            shoes.Centimetres = model.Centimetres;
            shoes.SizeEu = model.SizeEu;
            shoes.Description = model.Description;
            shoes.Color = model.Color;
            shoes.ImgUrl = model.ImgUrl;
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
                   ImgUrl = s.ImgUrl,
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

        public async Task<EditShoesViewModel> GetShoesEditModelById(int shoesId)
        {
            try
            {
                return await repo.AllReadonly<Shoes>()
               .Include(s => s.Member)
               .Include(c => c.Storage)
               .ThenInclude(s => s.House)
               .Where(s => s.Id == shoesId)
               .Select(s => new EditShoesViewModel()
               {
                   Id = s.Id,
                   Name = s.Name,
                   SizeEu = s.SizeEu,
                   Centimetres = s.Centimetres,
                   Description = s.Description,
                   Color = s.Color,
                   ImgUrl = s.ImgUrl,
                   MemberId = s.MemberId

               }).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        
        }

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
                    ImgUrl = cl.ImgUrl,
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
                   ImgUrl = s.ImgUrl,
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
