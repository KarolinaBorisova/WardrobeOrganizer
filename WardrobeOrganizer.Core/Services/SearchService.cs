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

        public async Task<IEnumerable<Item>> AllItems(string itemType, string userId)
        {
          
            try
            {
                switch (itemType)
                {
                    case "clothes":
                        return await repo.AllReadonly<Clothes>()
                            .Where(c => c.UserId == userId)
                            .ToListAsync();

                    case "shoes":
                        return await repo.AllReadonly<Shoes>()
                            .Where(c => c.UserId == userId)
                            .ToListAsync();

                    case "outerwear":
                        return await repo.AllReadonly<Outerwear>()
                            .Where(c => c.UserId == userId)
                            .ToListAsync();

                    case "accessories":
                        return await repo.AllReadonly<Accessories>()
                            .Where(c => c.UserId == userId)
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

          var clothes =   await repo.AllReadonly<Clothes>()
                .Where(c => c.Color != null)
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

 
        //public async Task<IEnumerable<Item>> GetAllFilteredItems(SearchListViewModel model, string userId)
        //{
        //    var items = new List<Item>();
        //
        //    var clothes = repo.AllReadonly<Clothes>()
        //        .Where(c => c.UserId == userId)
        //        .AsQueryable();
        //
        //    var shoes = repo.AllReadonly<Shoes>()
        //       .Where(c => c.UserId == userId)
        //       .AsQueryable();
        //
        //    var outerwears = repo.AllReadonly<Outerwear>()
        //       .Where(c => c.UserId == userId)
        //       .AsQueryable();
        //
        //    var accessories = repo.AllReadonly<Accessories>()
        //       .Where(c => c.UserId == userId)
        //       .AsQueryable();
        //
        //    if (model.ClothesSizes != null)
        //     {
        //        clothes = clothes
        //        .Where(c => model.ClothesSizes.Contains(c.Size));
        //
        //        outerwears = outerwears
        //           .Where(c => model.ClothesSizes.Contains(c.Size));
        //         
        //     }
        //
        //     if (model.ShoeSizesEu != null)
        //     {
        //      shoes = shoes
        //      .Where(c => model.ShoeSizesEu.Contains(c.SizeEu));
        //
        //     }
        //   
        //     if (model.SizeByAges != null)
        //     {
        //        accessories = accessories
        //     .Where(c => model.SizeByAges.Contains(c.SizeAge));
        //     
        //     }
        //     if (model.Colors != null )
        //     {
        //        clothes = clothes
        //       .Where(c => model.Colors.Contains(c.Color));
        //
        //
        //        outerwears = outerwears
        //            .Where(c => model.Colors.Contains(c.Color));
        //
        //
        //        shoes = shoes
        //     .Where(c => model.Colors.Contains(c.Color));
        //
        //
        //        accessories = accessories
        //     .Where(c => model.Colors.Contains(c.Color));
        //      
        //     }
        //   
        //     if (model.Categories != null)
        //     {
        //        clothes = clothes
        //      .Where(c => model.Categories.Contains(c.Category));
        //
        //
        //        outerwears = outerwears
        //           .Where(c => model.Categories.Contains(c.Category));
        //
        //
        //        shoes = shoes
        //      .Where(c => model.Categories.Contains(c.Category));
        //
        //
        //        accessories = accessories
        //     .Where(c => model.Categories.Contains(c.Category));
        //     
        //     }
        //
        //     await clothes.ToListAsync();
        //     await shoes.ToListAsync();
        //     await outerwears.ToListAsync();
        //     await accessories.ToListAsync();
        //     
        //       var clothestest = await repo.AllReadonly<Clothes>()
        //       .Where(c => c.UserId == userId)
        //       .ToListAsync();
        //
        //       var shoestest = await repo.AllReadonly<Shoes>()
        //          .Where(c => c.UserId == userId).
        //          ToListAsync();
        //
        //       var outerwearstest = await repo.AllReadonly<Outerwear>()
        //          .Where(c => c.UserId == userId).
        //          ToListAsync();
        //
        //       var accessoriestest = await  repo.AllReadonly<Accessories>()
        //          .Where(c => c.UserId == userId).
        //          ToListAsync();
        //
        //
        //       if (clothes.Count() == clothestest.Count())
        //       {
        //           clothes = clothes.DefaultIfEmpty();
        //
        //       }
        //
        //       if (shoes.Count() == shoestest.Count())
        //       {
        //           shoes = shoes.DefaultIfEmpty();
        //
        //       }
        //       if (accessories.Count() == accessoriestest.Count())
        //       {
        //           accessories = accessories.DefaultIfEmpty();
        //
        //       }
        //       if (outerwears.Count() == outerwearstest.Count())
        //       {
        //           outerwears = outerwears.DefaultIfEmpty();
        //
        //       }
        //
        //       if (model.Colors == null && model.Categories == null &&
        //        model.ClothesSizes == null && model.ShoeSizesEu == null &&
        //        model.SizeByAges == null)
        //    {
        //        return new List<Item>();
        //    }
        //    else
        //    {
        //        items.AddRange(clothes);
        //        items.AddRange(shoes);
        //        items.AddRange(outerwears);
        //        items.AddRange(accessories);
        //    }
        //
        //     return items;
        //        ///////////////////////////////////
        //        ///
        //
        //
        //        //  var items = new List<Item>();
        //        //   if (model.ClothesSizes != null)
        //        //   {
        //        //       var clothes = await repo.AllReadonly<Clothes>()
        //        //       .Where(c => model.ClothesSizes.Contains(c.Size))
        //        //       .Where(c=>c.UserId == userId)
        //        //       .ToListAsync();
        //        //       items.AddRange(clothes);
        //        //
        //        //       var outwears = await repo.AllReadonly<Outerwear>()
        //        //          .Where(c => model.ClothesSizes.Contains(c.Size))
        //        //          .Where(c => c.UserId == userId)
        //        //          .ToListAsync();
        //        //       items.AddRange(outwears);
        //        //   }
        //        //   if (model.ShoeSizesEu != null)
        //        //   {
        //        //       var shoes = await repo.AllReadonly<Shoes>()
        //        //     .Where(c => model.ShoeSizesEu.Contains(c.SizeEu))
        //        //     .Where(c => c.UserId == userId)
        //        //     .ToListAsync();
        //        //       items.AddRange(shoes);
        //        //   }
        //        //
        //        //   if (model.SizeByAges != null)
        //        //   {
        //        //       var accessories = await repo.AllReadonly<Accessories>()
        //        //    .Where(c => model.SizeByAges.Contains(c.SizeAge))
        //        //    .Where(c => c.UserId == userId)
        //        //    .ToListAsync();
        //        //       items.AddRange(accessories);
        //        //   }
        //        //   if (model.Colors != null )
        //        //   {
        //        //       var clothes = await repo.AllReadonly<Clothes>()
        //        //      .Where(c => model.Colors.Contains(c.Color))
        //        //      .Where(c => c.UserId == userId)
        //        //      .ToListAsync();
        //        //       items.AddRange(clothes);
        //        //
        //        //       var outwears = await repo.AllReadonly<Outerwear>()
        //        //          .Where(c => model.Colors.Contains(c.Color))
        //        //          .Where(c => c.UserId == userId)
        //        //          .ToListAsync();
        //        //       items.AddRange(outwears);
        //        //
        //        //       var shoes = await repo.AllReadonly<Shoes>()
        //        //     .Where(c => model.Colors.Contains(c.Color))
        //        //     .Where(c => c.UserId == userId)
        //        //     .ToListAsync();
        //        //       items.AddRange(shoes);
        //        //
        //        //       var accessories = await repo.AllReadonly<Accessories>()
        //        //    .Where(c => model.Colors.Contains(c.Color))
        //        //    .Where(c => c.UserId == userId)
        //        //    .ToListAsync();
        //        //       items.AddRange(accessories);
        //        //   }
        //        //
        //        //   if (model.Categories != null)
        //        //   {
        //        //       var clothes = await repo.AllReadonly<Clothes>()
        //        //      .Where(c => model.Categories.Contains(c.Category))
        //        //      .Where(c => c.UserId == userId)
        //        //      .ToListAsync();
        //        //       items.AddRange(clothes);
        //        //
        //        //       var outwears = await repo.AllReadonly<Outerwear>()
        //        //          .Where(c => model.Categories.Contains(c.Category))
        //        //          .Where(c => c.UserId == userId)
        //        //          .ToListAsync();
        //        //       items.AddRange(outwears);
        //        //
        //        //       var shoes = await repo.AllReadonly<Shoes>()
        //        //     .Where(c => model.Categories.Contains(c.Category))
        //        //     .Where(c => c.UserId == userId)
        //        //     .ToListAsync();
        //        //       items.AddRange(shoes);
        //        //
        //        //       var accessories = await repo.AllReadonly<Accessories>()
        //        //    .Where(c => model.Categories.Contains(c.Category))
        //        //    .Where(c => c.UserId == userId)
        //        //    .ToListAsync();
        //        //
        //        //       items.AddRange(accessories);
        //        //
        //        //   }
        //        //   items.Distinct().ToList();
        //        //   var distinctList = items.DistinctBy(x => x.Id).ToList();
        //        //   return items;
        //
   // }

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

    }
}
