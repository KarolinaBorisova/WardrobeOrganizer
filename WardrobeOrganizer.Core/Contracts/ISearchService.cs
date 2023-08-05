using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface ISearchService
    {
        IEnumerable<string> GetAllColors();
        IEnumerable<string> GetAllCategories();
        IEnumerable<int> GetAllSizesByAges();
        IEnumerable<string> GetAllClothesSizes();
        IEnumerable<int> GetAllShoeSizes();
        IEnumerable<int> GetAllShoeSizesinCm();
    }
}
