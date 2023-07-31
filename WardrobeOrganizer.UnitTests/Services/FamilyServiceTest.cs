using Microsoft.Extensions.DependencyInjection;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class FamilyServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IFamilyService familyService;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();    

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IFamilyService, FamilyService>()
                .AddAutoMapper(typeof(Program).Assembly)
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            familyService = serviceProvider.GetService<IFamilyService>()!;
        }

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() {
            Assert.IsInstanceOf<bool>(await familyService.ExistsById(1));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task ExistsByIdShouldReturnTrueWhenFamilyExists(int familyId)
        {
            var result = await familyService.ExistsById(familyId);

            Console.WriteLine(result);
            Assert.That(await familyService.ExistsById(familyId), Is.True);

        }

        [Test]
        [TestCase(50)]
        public async Task ExistsByIdShouldReturnFalseWhenFamilyDoesntExisits(int familyd) =>
           Assert.That(await familyService.ExistsById(familyd), Is.False);

        [Test]
        public async Task GetFamilyByIdShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<FamilyViewModel>(await familyService.GetFamilyById(1));
        }


        [Test]
        [TestCase(1)]
        public async Task GetFamilyByIdShouldReturnCorrectFamily(int expectedId)
        {
            var actualId = (await familyService.GetFamilyById(expectedId)).Id;
            Assert.That(actualId,Is.EqualTo(expectedId));
        }

        [Test]
        [TestCase("TestUserId")]
        public async Task GetFamilyByUserIdShouldReturnCorrectFamily(string userId)
        {
            var actualUserId = (await familyService.GetFamilyByUserId(userId)).UserId;
            Assert.That(actualUserId, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetFamilyByUserIdShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<FamilyViewModel>(await familyService.GetFamilyByUserId("TestUserId"));
        }

        [Test]
        [TestCase("TestUserId")]
        public async Task GetFamilyIdByUserIdShouldReturnCorrectFamilyId(string userId)
        {
            var actualId = (await familyService.GetFamilyId(userId));
            Assert.That(actualId, Is.EqualTo(67));
        }

        [Test]
        [TestCase("NotValidUserId")]
        public async Task GetFamilyIdByUserIdShouldReturnZeroIfUserIdIsWrong(string userId)
        {
            var actualId = (await familyService.GetFamilyId(userId));
            Assert.That(actualId, Is.EqualTo(0));
        }

        [Test]
        public async Task HasFamilyShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<bool>(await familyService.HasFamily("da"));
        }

        [Test]
        public async Task HasFamilyShouldReturnTrueIfUserHaveFamily()
        {
            Assert.That(await familyService.HasFamily("1"), Is.True);
        }

        [Test]
        public async Task HasFamilyShouldReturnFalseIfUserHaveFamily()
        {
            Assert.That(await familyService.HasFamily("UserWithoutFamily"), Is.False);
        }
          

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var family = new Family()
            {
                Id = 67,
                Name = "TestFamily",
                UserId = "TestUserId"
            };


            await repoTest.AddAsync(family);
            await repoTest.SaveChangesAsync();
        }
    }
}
