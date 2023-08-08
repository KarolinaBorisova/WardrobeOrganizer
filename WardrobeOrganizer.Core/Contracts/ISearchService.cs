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
        //  Task<IEnumerable<Item>> GetAllFilteredItems(SearchListViewModel model,  string userId);
    }
}
