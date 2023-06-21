using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository repo;
      

        
        public MemberService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<int> AddMember(AddMemberViewModel model, int familyId)
        {
            
            var member = new Member()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
               //GenderId = model.Gender,
                Birthdate = model.Birthdate,
                ShoeSizeEu = model.ShoeSizeEu,
                FootLengthCm = model.FootLengthCm,
                ClothesSize = model.ClothesSize,
                UserHeight = model.UserHeight,
                FamilyId = familyId,
                ImgUrl = model.ImgUrl
                
            };

            try
            {
                await repo.AddAsync(member);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info", ex);
            }

            

            return member.Id;
        }

        public async Task<ICollection<AllMembersViewModel>> AllMembers(int familyId)
        {
            return await repo.AllReadonly<Member>()
                .Where(f => f.FamilyId == familyId && f.IsActive)
                .Select(m => new AllMembersViewModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    ImgUrl = m.ImgUrl

                }).ToListAsync();
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> AllMembersBasic(int familyId)
        {
            var members = await repo.AllReadonly<Member>()
                .Where(f => f.FamilyId == familyId && f.IsActive)
                .Select(f => new MemberAsKVP()
                {
                    Id = f.Id,
                    FullName = f.FirstName + " " + f.LastName,
                }).ToListAsync();

                return members.Select(f => new KeyValuePair<string, string>(f.Id.ToString(), f.FullName));
        }

        public async Task<InfoMemberViewModel> GetMemberById(int memberId)
        {
            return await repo.AllReadonly<Member>()
                .Where(m=>m.Id == memberId)
                .Select(m => new InfoMemberViewModel()
                {
                    Id=m.Id,
                    FirstName=m.FirstName,
                    LastName=m.LastName,
                    ImgUrl=m.ImgUrl,
                    Birthdate = m.Birthdate,
                    Gender = m.Gender,
                    ShoeSizeEu = m.ShoeSizeEu,
                    FootLengthCm = m.FootLengthCm,
                    ClothesSize=m.ClothesSize,
                    UserHeight=m.UserHeight,
                    Family = new Models.Family.FamilyViewModel()
                    {
                        Name = m.Family.Name,
                        UserId = m.Family.UserId,
                        Id = m.Family.Id

                    }
                    

                })
                .FirstAsync();
        }


        //  public async Task Create(string userId)
        //  {
        //      var member = new Member()
        //      {
        //
        //          UserId = userId,
        //      };
        //
        //      await repo.AddAsync(member);
        //      await repo.SaveChangesAsync();
        //  }
        //
        //
          public async Task<bool> ExistsById(int id)
         {
              return await repo.AllReadonly<Member>()
                .AnyAsync(m=>m.Id == id);
          }

        public async Task Edit( InfoMemberViewModel model)
        {
            try
            {
                var member = await repo.GetByIdAsync<Member>(model.Id);

                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.ImgUrl = model.ImgUrl;
                member.Birthdate = model.Birthdate;
                member.Gender = model.Gender;
                member.ShoeSizeEu = model.ShoeSizeEu;
                member.FootLengthCm = model.FootLengthCm;
                member.ClothesSize = model.ClothesSize;
                member.UserHeight = model.UserHeight;

                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        
        }

        public async Task Delete(int MemberId)
        {
            try
            {
                var member = await repo.GetByIdAsync<Member>(MemberId);

                member.IsActive = false;
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
            
        }
    }
}
