using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IOuterwearService
    {
        Task<int> AddOuterWear(AddOuterwearViewModel model);

        Task<AllOuterwearByCategoryViewModel> AllOuterwearByCategory(int storageId, string category);

        Task<AllOuterwearViewModel> AllOutwear(int storageId);

        Task<DetailsOuterwearViewModel> GetOuterwearById(int outerwearId);

        Task<bool> ExistsById(int outerwearId);

        Task DeleteById(int outerwearId);
    }
}
