using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IHouseService
    {
        Task<ICollection<AllHousesViewModel>> AllHouses(int familyId);

        Task<bool> ExistsById(int houseId);

        Task<InfoHouseViewModel> GetHouseById(int houseId);

        Task<int> AddHouse(AddHouseViewModel model, int familiId);

        Task<int> GetHouseId(string userId);
    }
}
