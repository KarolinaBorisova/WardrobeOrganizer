﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;
using static System.Net.Mime.MediaTypeNames;

namespace WardrobeOrganizer.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository repo;
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        
        public MemberService(IRepository _repo,
            IFileService _fileService,
            IMapper _mapper)
        {
            this.repo = _repo;
            this.fileService = _fileService;
            this.mapper = _mapper;
        }

        public async Task<int> AddMember(AddMemberViewModel model, int familyId, string rootPath)
        {
            if (model == null || model.Image == null)
            {
                throw new ArgumentNullException("Member is not valid");
            }

            if (model.Image.Length > 2 *1024 * 1024)
            {
                throw new InvalidOperationException("Image size is too big");
            }

            Guid imgName = Guid.NewGuid();
            var folderName = "member";


            var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
            await fileService.SaveImage(model.Image, imgName, folderName , rootPath, extention);

            var member = new Member()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Birthdate = model.Birthdate,
                ShoeSizeEu = model.ShoeSizeEu,
                FootLengthCm = model.FootLengthCm,
                ClothesSize = model.ClothesSize,
                UserHeight = model.UserHeight,
                FamilyId = familyId,
                ImagePath = $"/images/{folderName}/{imgName}{extention}",     
            };

            try
            {
                await repo.AddAsync(member);
                await repo.SaveChangesAsync();

                return member.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<ICollection<AllMembersViewModel>> AllMembers(int familyId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
                .Where(f => f.FamilyId == familyId && f.IsActive)
            .Select(m => mapper.Map<AllMembersViewModel>(m)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> AllMembersBasic(int familyId)
        {
            try
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
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
           
        }

        public async Task<InfoMemberViewModel> GetMemberById(int memberId)
        {
            try
            {
                return await repo.AllReadonly<Member>()
            .Where(m => m.Id == memberId && m.IsActive)
            .Select(m => new InfoMemberViewModel()
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                ImagePath = m.ImagePath,
                Birthdate = m.Birthdate,
                Gender = m.Gender,
                ShoeSizeEu = m.ShoeSizeEu,
                FootLengthCm = m.FootLengthCm,
                ClothesSize = m.ClothesSize,
                UserHeight = m.UserHeight,
                Family = new Models.Family.FamilyViewModel()
                {
                    Name = m.Family.Name,
                    UserId = m.Family.UserId,
                    Id = m.Family.Id

                }


            })
            .FirstAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        
        }


          public async Task<bool> ExistsById(int id)
         {
            try
            {
                return await repo.AllReadonly<Member>()
              .AnyAsync(m => m.Id == id && m.IsActive);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            
          }

        public async Task Edit( EditMemberViewModel model, string rootPath)
        {

            if (model == null)
            {
                throw new ArgumentNullException("Member is not valid");
            }

            var member = await repo.GetByIdAsync<Member>(model.Id);

            if (model.Image != null)
            {
                if (model.Image.Length > 2 * 1024 * 1024)
                {
                    throw new InvalidOperationException("Image size is too big");
                }

                Guid imgName = Guid.NewGuid();
                var folderName = "member";

                var extention = Path.GetExtension(model.Image.FileName.TrimStart('.'));
                await fileService.SaveImage(model.Image, imgName, folderName, rootPath, extention);

                member.ImagePath = $"/images/{folderName}/{imgName}{extention}";
            }

            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.Birthdate = model.Birthdate;
            member.Gender = model.Gender;
            member.ShoeSizeEu = model.ShoeSizeEu;
            member.FootLengthCm = model.FootLengthCm;
            member.ClothesSize = model.ClothesSize;
            member.UserHeight = model.UserHeight;


            try
            {
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
