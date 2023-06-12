using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Shoes;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IShoesService
    {
        Task<int> AddShoes(AddShoesViewModel model);
    }
}
