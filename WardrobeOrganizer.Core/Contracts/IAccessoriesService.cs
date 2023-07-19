using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IAccessoriesService
    {

        Task<int> AddAccessories(AddAccessoriesViewModel model, string rootPath);

        Task<AllAccessoriesByCategoryViewModel> AllAccessoriesByCategory(int storageId, string category);

        Task<AllAccessoriesViewModel> AllAccessories(int storageId);

        Task<DetailsAccessoriesViewModel> GetAccessoriesDetailsModelById(int accessoriesId);

        Task<EditAccessoriesViewModel> GetAccessoriesEditModelById(int accessoriesId);

        Task<bool> ExistsById(int accessoriesId);

        Task DeleteById(int accessoriesId);

        Task Edit(EditAccessoriesViewModel model, string rootPath);

        Task<AllMemberAccessoriesViewModel> AllAccessoriesByMemberId(int memberId);

        Task<AllMemberAccessoriesByCategoryViewModel> AllAccessoriesByCategoryAndMemberId(int memberId, string category);
    }
}
