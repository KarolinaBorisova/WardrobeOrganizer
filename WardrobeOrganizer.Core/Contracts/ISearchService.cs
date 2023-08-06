using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface ISearchService
    {
        Task<IEnumerable<string>> GetAllColors();
        IEnumerable<string> GetAllCategories();
        Task<IEnumerable<int>> GetAllSizesByAges();
        Task<IEnumerable<string>> GetAllClothesSizes();
        Task<IEnumerable<int>> GetAllShoeSizes();
    }
}
