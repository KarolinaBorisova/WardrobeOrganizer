using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
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

        public async Task<IEnumerable<Item>> GetAllFilteredItems(SearchListViewModel model)
        {
           var items = new List<Item>();

            var queryClothes = repo.AllReadonly<Clothes>().AsQueryable();
            var queryShoes = repo.AllReadonly<Shoes>().AsQueryable();
            var queryAccessories = repo.AllReadonly<Accessories>().AsQueryable();
            var queryOutwear = repo.AllReadonly<Outerwear>().AsQueryable();

            if (model.Categories != null)
            {
                foreach (var category in model.Categories)
                {
                    queryClothes = queryClothes.Where(i => i.Category == category);
                    queryShoes = queryShoes.Where(i => i.Category == category);
                    queryAccessories = queryAccessories.Where(i => i.Category == category);
                    queryOutwear = queryOutwear.Where(i => i.Category == category);
                }
            }

            if (model.ClothesSizes != null)
            {
                queryClothes = queryClothes.Where(c => model.ClothesSizes.Contains(c.Size));

            //    items.AddRange(clothes);

                queryOutwear = queryOutwear.Where(c => model.ClothesSizes.Contains(c.Size));
               
              //  items.AddRange(outwears);
            }
            if (model.ShoeSizesEu != null)
            {
                queryShoes = queryShoes.Where(c => model.ShoeSizesEu.Contains(c.SizeEu));
          
               // items.AddRange(shoes);
            }

            if (model.SizeByAges != null)
            {
                queryAccessories = queryAccessories.Where(c => model.SizeByAges.Contains(c.SizeAge));

                //items.AddRange(accessories);
            }
           await queryClothes.ToListAsync();
            await queryShoes.ToListAsync();
            await queryAccessories.ToListAsync();
            await queryOutwear.ToListAsync();

            items.AddRange(queryClothes);
            items.AddRange(queryAccessories);
            items.AddRange(queryOutwear);
            items.AddRange(queryShoes);
            return items;

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
    }
}
