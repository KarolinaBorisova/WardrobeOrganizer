﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Search;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface ISearchService
    {
        Task<IEnumerable<string>> GetAllColors();
        IEnumerable<string> GetAllCategories();
        Task<IEnumerable<int>> GetAllSizesByAges();
        Task<IEnumerable<string>> GetAllClothesSizes();
        Task<IEnumerable<int>> GetAllShoeSizes();
        Task<IEnumerable<Item>> AllItems(string category, string userId);
        Task<IEnumerable<Item>> AllClothesByCategory(string category, string userId);
        Task<IEnumerable<Item>> AllShoesByCategory(string category, string userId);
        Task<IEnumerable<Item>> AllOuterwearByCategory(string category, string userId);
        Task<IEnumerable<Item>> AllAccessoriesByCategory(string category, string userId);
        Task<IEnumerable<Item>> GetAllItemsByColor(SearchByColorViewModel model,  string userId);
        Task<IEnumerable<Item>> GetClothesBySizeAndCategory(SearchByClothesSizeViewModel model,  string userId, string category);
        Task<IEnumerable<Item>> GetOuterwearsBySizeAndCategory(SearchByClothesSizeViewModel model,  string userId, string category);
        Task<IEnumerable<Item>> GetAccessoriesBySizeAndCategory(SearchBySizeAgeViewModel model,  string userId, string category);
        Task<IEnumerable<Item>> GetShoesBySizeAndCategory(SearchByShoesSizeViewModel model,  string userId, string category);
     //   Task<IEnumerable<Item>> GetAllItemsFromTypeBySize(SearchListViewModel model, string userId);
    }
}
