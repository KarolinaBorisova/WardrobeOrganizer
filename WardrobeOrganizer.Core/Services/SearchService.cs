﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
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
