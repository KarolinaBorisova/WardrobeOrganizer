using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Search;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IRepository repo;

        public SearchService(IRepository _repo)
        {
                repo = _repo;
        }

        public IEnumerable<string> GetAllCategories()
        {
            var list = new List<string>();

            foreach (string item in Enum.GetNames(typeof(CategoryClothes)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryOuterwear)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryShoes)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryAccessories)))
            {
                list.Add(item);
            }
            return list;
        }

        public async Task<IEnumerable<string>> GetAllClothesSizes()
        {
            var clothesSizes = new List<string>();

            var clothes = await repo.AllReadonly<Clothes>()
                  .Where(c => c.Size != null)
                  .ToListAsync();
            foreach (var item in clothes)
            {
                if (!clothesSizes.Contains(item.Size))
                {
                    clothesSizes.Add(item.Size);
                }

            }
            var outwear = await repo.AllReadonly<Outerwear>()
                 .Where(c => c.Size != null)
                 .ToListAsync();
            foreach (var item in outwear)
            {
                if (!clothesSizes.Contains(item.Size))
                {
                    clothesSizes.Add(item.Size);
                }

            }

            return clothesSizes;
        }

        public async Task<IEnumerable<string>> GetAllColors()
        {
            var colors = new List<string>();

            var clothes = await repo.AllReadonly<Clothes>()
                  .Where(c => c.Color != null)
                  .Where(c => c.IsActive == true)
                  .ToListAsync();
            foreach (var item in clothes)
            {
                if (!colors.Contains(item.Color))
                {
                    colors.Add(item.Color);
                }

            }
            var accessories = await repo.AllReadonly<Accessories>()
              .Where(c => c.Color != null)
                .Where(c => c.IsActive == true)
              .ToListAsync();
            foreach (var item in accessories)
            {
                if (!colors.Contains(item.Color))
                {
                    colors.Add(item.Color);
                }

            }
            var shoes = await repo.AllReadonly<Shoes>()
              .Where(c => c.Color != null)
                .Where(c => c.IsActive == true)
              .ToListAsync();
            foreach (var item in shoes)
            {
                if (!colors.Contains(item.Color))
                {
                    colors.Add(item.Color);
                }

            }
            var outerwear = await repo.AllReadonly<Outerwear>()
              .Where(c => c.Color != null)
                .Where(c => c.IsActive == true)
              .ToListAsync();
            foreach (var item in outerwear)
            {
                if (!colors.Contains(item.Color))
                {
                    colors.Add(item.Color);
                }

            }

            return colors;

        }


        public async Task<IEnumerable<int>> GetAllShoeSizes()
        {
            var sizesEu = new List<int>();

            var shoes = await repo.AllReadonly<Shoes>()
                  .Where(c => c.SizeEu != null)
                  .ToListAsync();

            foreach (var item in shoes)
            {
                if (!sizesEu.Contains(item.SizeEu))
                {
                    sizesEu.Add(item.SizeEu);
                }

            }

            return sizesEu;
        }

        public async Task<IEnumerable<int>> GetAllSizesByAges()
        {
            var sizeByAges = new List<int>();

            var accessories = await repo.AllReadonly<Accessories>()
                  .Where(c => c.SizeAge != null)
                  .ToListAsync();

            foreach (var item in accessories)
            {
                if (!sizeByAges.Contains(item.SizeAge))
                {
                    sizeByAges.Add(item.SizeAge);
                }

            }

            return sizeByAges;
        }


        public async Task<IEnumerable<Item>> AllAccessoriesByCategory(string category, string userId)
        {
            return await repo.AllReadonly<Accessories>()
                .Where(c => c.UserId == userId)
                .Where(c => c.Category == category) 
                .Where(c=> c.IsActive == true)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Item>> AllClothesByCategory(string category, string userId)
        {
            return await repo.AllReadonly<Clothes>()
               .Where(c => c.UserId == userId)
               .Where(c => c.Category == category)
               .Where(c => c.IsActive == true)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Item>> AllOuterwearByCategory(string category, string userId)
        {
            return await repo.AllReadonly<Outerwear>()
               .Where(c => c.UserId == userId)
               .Where(c => c.Category == category)
               .Where(c => c.IsActive == true)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Item>> AllShoesByCategory(string category, string userId)
        {
            return await repo.AllReadonly<Shoes>()
              .Where(c => c.UserId == userId)
              .Where(c => c.Category == category)
              .Where(c => c.IsActive == true)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsByColor(SearchByColorViewModel model, string userId)
        {
            var items = new List<Item>();
            if (model.Colors == null)
            {
                return items;
            }
            var clothes = await repo.AllReadonly<Clothes>()
                .Where(c => c.UserId == userId)
                .Where(c => model.Colors.Contains(c.Color))
                .Where(c => c.IsActive == true)
                .ToListAsync();

            var shoes = await repo.AllReadonly<Shoes>()
               .Where(c => c.UserId == userId)
               .Where(c => model.Colors.Contains(c.Color))
               .Where(c => c.IsActive == true)
               .ToListAsync();

            var outerwears = await repo.AllReadonly<Outerwear>()
               .Where(c => c.UserId == userId)
               .Where(c => model.Colors.Contains(c.Color))
               .Where(c => c.IsActive == true)
               .ToListAsync();

            var accessories = await repo.AllReadonly<Accessories>()
               .Where(c => c.UserId == userId)
               .Where(c => model.Colors.Contains(c.Color))
               .Where(c => c.IsActive == true)
               .ToListAsync();

            items.AddRange(clothes);
            items.AddRange(shoes);
            items.AddRange(outerwears);
            items.AddRange(accessories);

            return items;

        }

        public async Task<IEnumerable<Item>> AllItems(string itemType, string userId)
        {
            try
            {
                switch (itemType)
                {
                    case "clothes":
                        return await repo.AllReadonly<Clothes>()
                            .Where(c => c.UserId == userId)
                            .Where(c => c.IsActive == true)
                            .ToListAsync();
       
                    case "shoes":
                        return await repo.AllReadonly<Shoes>()
                            .Where(c => c.UserId == userId)
                            .Where(c => c.IsActive == true)
                            .ToListAsync();
       
                    case "outerwear":
                        return await repo.AllReadonly<Outerwear>()
                            .Where(c => c.UserId == userId)
                              .Where(c => c.IsActive == true)
                            .ToListAsync();
       
                    case "accessories":
                        return await repo.AllReadonly<Accessories>()
                            .Where(c => c.UserId == userId)
                              .Where(c => c.IsActive == true)
                            .ToListAsync();
       
                    default:
                        throw new InvalidOperationException("Invalid itemType");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<IEnumerable<Item>> GetClothesBySize(SearchByClothesSizeViewModel model, string userId)
        {
            return await repo.AllReadonly<Clothes>()
                .Where(c => c.UserId == userId)
                .Where(c => c.IsActive == true)
                .Where(c => model.ClothesSizes.Contains(c.Size))
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetOuterwearsBySize(SearchByClothesSizeViewModel model, string userId)
        {
            return await repo.AllReadonly<Outerwear>()
                .Where(c => c.UserId == userId)
                .Where(c => c.IsActive == true)
                .Where(c => model.ClothesSizes.Contains(c.Size))
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAccessoriesBySize(SearchBySizeAgeViewModel model, string userId)
        {
            return await repo.AllReadonly<Accessories>()
               .Where(c => c.UserId == userId)
               .Where(c => c.IsActive == true)
               .Where(c => model.SizeByAges.Contains(c.SizeAge))
               .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetShoesBySize(SearchByShoesSizeViewModel model, string userId)
        {
            return await repo.AllReadonly<Shoes>()
                .Where(c => c.UserId == userId)
                .Where(c => c.IsActive == true)
                .Where(c => model.ShoeSizesEu.Contains(c.SizeEu))
                .ToListAsync();
        }




        // public async Task<IEnumerable<Item>> GetAllItemsFromTypeBySize(SearchListViewModel model, string userId)
        // {
        //     var items = new List<Item>();
        //
        //     if (model.Colors == null && model.ShoeSizesEu == null &&
        //         model.ClothesSizes ==null && model.SizeByAges == null)
        //     {
        //         throw new InvalidOperationException();
        //     }
        //     if (model.Type == "Clothes")
        //     {
        //         var clothes = repo.AllReadonly<Clothes>()
        //             .Where(c => c.UserId == userId)
        //             .Where(c => c.IsActive == true)
        //             .Where(c => model.ClothesSizes.Contains(c.Size))
        //             .AsQueryable();
        //
        //         if (model.Colors != null && model.Colors.Any())
        //         {
        //             clothes = clothes.Where(c=>model.Colors.Contains(c.Color));
        //         }
        //
        //         await clothes.ToListAsync();
        //         items.AddRange(clothes);
        //
        //     }
        //     if (model.Type == "Outerwear")
        //     {
        //         var outerwear = repo.AllReadonly<Outerwear>()
        //             .Where(c => c.UserId == userId)
        //             .Where(c => c.IsActive == true)
        //             .Where(c => model.ClothesSizes.Contains(c.Size))
        //             .AsQueryable();
        //
        //         if (model.Colors != null && model.Colors.Any())
        //         {
        //             outerwear = outerwear.Where(c => model.Colors.Contains(c.Color));
        //         }
        //
        //         await outerwear.ToListAsync();
        //         items.AddRange(outerwear);
        //
        //     }
        //     if (model.Type == "Shoes")
        //     {
        //         var shoes = repo.AllReadonly<Shoes>()
        //             .Where(c => c.UserId == userId)
        //             .Where(c => c.IsActive == true)
        //             .Where(c => model.ShoeSizesEu.Contains(c.SizeEu))
        //             .AsQueryable();
        //
        //         if (model.Colors != null && model.Colors.Any())
        //         {
        //             shoes = shoes.Where(c => model.Colors.Contains(c.Color));
        //         }
        //
        //         await shoes.ToListAsync();
        //         items.AddRange(shoes);
        //
        //     }
        //     if (model.Type == "Accessories")
        //     {
        //         var accessories = repo.AllReadonly<Accessories>()
        //             .Where(c => c.UserId == userId)
        //             .Where(c => c.IsActive == true)
        //             .Where(c => model.SizeByAges.Contains(c.SizeAge))
        //             .AsQueryable();
        //
        //         if (model.Colors != null && model.Colors.Any())
        //         {
        //             accessories = accessories.Where(c => model.Colors.Contains(c.Color));
        //         }
        //
        //         await accessories.ToListAsync();
        //         items.AddRange(accessories);
        //
        //     }
        //     return items;
        // }
    }
}
