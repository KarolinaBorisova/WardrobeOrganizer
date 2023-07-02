using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Models.User;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IUserService
    {
        Task<AllUsersViewModel> AllUsers();
        Task InActive(string UserId);
        Task Active(string UserId);
    }
}
