using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.House;
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

            try
            {
                users.Users = await repo.AllReadonly<User>()
         .Where(u => u.LastName != "Admin")
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
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
         
        }

        public async Task InActive(string UserId)
        {
            var user = await repo.GetByIdAsync<User>(UserId);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            user.IsActive = false;
            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task Active(string UserId)
        {
            var user = await repo.GetByIdAsync<User>(UserId);

            if (user == null)
            {

                throw new ArgumentNullException("User not found");
            }

            user.IsActive = true;
            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> ExistsById(string id)
        {
            try
            {
                return await repo.AllReadonly<User>()
              .AnyAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
            
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("User not found");
            }
            try
            {
                return await repo.AllReadonly<User>()
               .Where(u => u.Id == id)
               .Select(h => new UserViewModel()
               {
                   Id = h.Id,
                   Email = h.Email,
                   FullName = h.FirstName + " " + h.LastName,
                   IsActive = h.IsActive,
               })
               .FirstAsync();

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
