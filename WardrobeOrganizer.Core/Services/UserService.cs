using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;



        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }


        public async Task<AllUsersViewModel> AllUsers()
        {
            var users = new AllUsersViewModel();

           users.Users = await repo.AllReadonly<User>()
           .Select(c => new UserViewModel()
           {
               Email = c.Email,
               FullName = c.FirstName + " " + c.LastName,
           }).ToListAsync();

            repo.SaveChangesAsync();

            return users;
        }
    }
}
