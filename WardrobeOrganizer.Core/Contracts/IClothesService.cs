using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IClothesService
    {

        Task<int> AddClothes(AddClothesViewModel model);

        Task<AllClothesByCategoryViewModel> AllClothesByCategory(int storageId, string category);

        Task<AllClothesViewModel> AllClothes(int storageId);

        Task<DetailsClothesViewModel> GetClothingById(int clothingId);

        Task<bool> ExistsById(int clothingId);

        Task DeleteById(int clothingId);

        Task Edit(DetailsClothesViewModel model);
    }
}
