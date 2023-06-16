using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IAccessoriesService
    {

        Task<int> AddAccessories(AddAccessoriesViewModel model);

        Task<AllAccessoriesByCategoryViewModel> AllAccessoriesByCategory(int storageId, string category);

        Task<AllAccessoriesViewModel> AllAccessories(int storageId);

        Task<DetailsAccessoriesViewModel> DetailsAccessories(int accessoriesId);
    }
}
