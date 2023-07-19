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
        Task<int> AddOuterWear(AddOuterwearViewModel model, string rootPath);

        Task<AllOuterwearByCategoryViewModel> AllOuterwearByCategory(int storageId, string category);

        Task<AllOuterwearViewModel> AllOutwear(int storageId);

        Task<DetailsOuterwearViewModel> GetOuterwearDetailsModelById(int outerwearId);

        Task<EditOuterwearViewModel> GetOuterwearEditModelById(int outerwearId);

        Task<bool> ExistsById(int outerwearId);

        Task DeleteById(int outerwearId);

        Task Edit(EditOuterwearViewModel model);

        Task<AllMemberOuterwearViewModel> AllOuterwearByMemberId(int memberId);

        Task<AllMemberOutwearByCategoryViewModel> AllOuterwearByCategoryAndMemberId(int memberId, string category);


    }
}
