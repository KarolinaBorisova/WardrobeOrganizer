using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Controllers;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Tests
{
    public class MembersServiceTests
    {
        [Fact]
        public async Task ExistShoudReturnTrueIfTheMemberIsFound()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "KariTest",
                LastName = "BorisovaTest",
                FootLengthCm = 1,
                ShoeSizeEu = 1,
                ClothesSize = "L",
                FamilyId = 1,
                Birthdate = DateTime.Now,
                IsActive = true,
                Gender = Infrastructure.Data.Enums.Gender.Male,
                ImagePath = "/images/member/e031de77-c950-4539-a040-717885f0339f.jpg",
                UserHeight = 1, 
            };

            var list = new List<Member>();
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(x => x.AllReadonly<Member>()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Member>()))
                .Callback((Member member) => list.Add(member));

            var mockFileService = new Mock<IFileService>();
          // mockFileService.Setup(x => x.SaveImage(It.IsAny<Member>()))
          //     .Callback((Member member) => list.Add(member));

            var service = new MemberService(mockRepo.Object,mockFileService.Object);

            var result = service.ExistsById(1);
            Assert.NotNull(result);
            Assert.Equal("true", result.ToString());

            //TODO: exisist


        }

        [Fact]
        public async Task Exist()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "KariTest",
                LastName = "BorisovaTest",
                FootLengthCm = 1,
                ShoeSizeEu = 1,
                ClothesSize = "L",
                FamilyId = 1,
                Birthdate = DateTime.Now,
                IsActive = true,
                Gender = Infrastructure.Data.Enums.Gender.Male,
                ImagePath = "/images/member/e031de77-c950-4539-a040-717885f0339f.jpg",
                UserHeight = 1,
            };

            var list = new List<Member>();
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(x => x.AllReadonly<Member>()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Member>()))
                .Callback((Member member) => list.Add(member));

            var mockFileService = new Mock<IFileService>();
            // mockFileService.Setup(x => x.SaveImage(It.IsAny<Member>()))
            //     .Callback((Member member) => list.Add(member));

            var service = new MemberService(mockRepo.Object, mockFileService.Object);

            service.ExistsById(1);

            //TODO: exisist


        }
    }
}
