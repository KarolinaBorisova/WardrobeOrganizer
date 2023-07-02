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
           .Where(u=> u.LastName != "Admin")
           .Select(c => new UserViewModel()
           {
               Id = c.Id,
               Email = c.Email,
               FullName = c.FirstName + " " + c.LastName,
               IsActive = c.IsActive,
           }).ToListAsync();

            await repo.SaveChangesAsync();

            return users;
        }

        public async Task InActive(string UserId)
        {
            try
            {
                var user = await repo.GetByIdAsync<User>(UserId);

                user.IsActive = false;
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Active(string UserId)
        {
            try
            {
                var user = await repo.GetByIdAsync<User>(UserId);

                user.IsActive = true;
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
