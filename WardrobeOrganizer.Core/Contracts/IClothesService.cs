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

        Task<int> AddClothes(AddClothesViewModel model, int familyId);

        Task<IEnumerable<AddClothesViewModel>> AllCategories();
    }
}
