﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IShoesService
    {
        Task<int> AddShoes(AddShoesViewModel model, string rootPath);

        Task<AllShoesByCategoryViewModel> AllShoesByCategory(int storageId, string category);

        Task<AllShoesViewModel> AllShoes(int storageId);

        Task<DetailsShoesViewModel> GetShoesDetailsModelById(int shoesId);

       // Task<EditShoesViewModel> GetShoesEditModelById(int shoesId);

        Task<bool> ExistsById(int shoesId);

        Task DeleteById(int shoesId);

        Task Edit(EditShoesViewModel model, string rootPath);

        Task<AllMemberShoesViewModel> AllShoesByMemberId(int memberId);

        Task<AllMemberShoesByCategoryViewModel> AllShoesByCategoryAndMemberId(int memberId, string category);
    }
}
