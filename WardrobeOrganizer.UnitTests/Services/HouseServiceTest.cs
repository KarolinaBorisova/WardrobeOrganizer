using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class HouseServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IHouseService houseService;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IHouseService, HouseService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            houseService = serviceProvider.GetService<IHouseService>()!;
        }

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<bool>(await houseService.ExistsById(67));
        }

        [Test]
        [TestCase(67)]
        [TestCase(68)]
        public async Task ExistsByIdShouldReturnTrueWhenHouseExists(int houseId)
        {
            var result = await houseService.ExistsById(houseId);

            Console.WriteLine(result);
            Assert.That(await houseService.ExistsById(houseId), Is.True);

        }


        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenHouseDoesntExisits(int houseId) =>
           Assert.That(await houseService.ExistsById(houseId), Is.False);

        [Test]
        public async Task GetHouseByIdShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<InfoHouseViewModel>(await houseService.GetHouseById(67));
        }

        [Test]
        public async Task GetHouseByIdShouldReturnCorrectHouse()
        {
            var house = await houseService.GetHouseById(67);
            Assert.That(house.Name, Is.EqualTo("TestHouse"));
        }


        [Test]
        [TestCase("TestUserId")]
        public async Task GetHouseIdByUserIdShouldReturnCorrectHouseId(string userId)
        {
            var actualId = (await houseService.GetHouseId(userId));
            Assert.That(actualId, Is.EqualTo(67));
        }

        [Test]
        [TestCase("NotValidUserId")]
        public async Task GetHouseIdByUserIdShouldReturnZeroIfUserIdIsWrong(string userId)
        {
            var actualId = (await houseService.GetHouseId(userId));
            Assert.That(actualId, Is.EqualTo(0));
        }

        [Test]
        public async Task AddHouseShouldWorkCorrect()
        {
            var model = new AddHouseViewModel
            {
                Name = "HouseName",
                Address = "HouseAddress",
            };
            var houseId = await houseService.AddHouse(model, 67);

            Assert.That((await houseService.ExistsById(houseId)), Is.True);
        }

        [Test]
        public async Task AllHousesShouldReturnCorrectType() =>
           Assert.IsInstanceOf<ICollection<AllHousesViewModel>>(await houseService.AllHouses(67));

        [Test]
        public async Task AllHousesShouldRetutnCorrectCount() =>
            Assert.That((await houseService.AllHouses(67)).Count(), Is.EqualTo(1));


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var house = new House()
            {
                Id = 67,
                Name = "TestHouse",
                Address = "TestAddress",
                IsActive = true,
                Family = new Family
                {
                    Id = 67,
                    Name = "TestFamily",
                    UserId = "TestUserId"
                }
            };

            await repoTest.AddAsync(house);
            await repoTest.SaveChangesAsync();

            house = new House()
            {
                Id = 68,
                Name = "TestHouse2",
                Address = "TestAddress2",
                IsActive = true,
                Family = new Family
                {
                    Id = 68,
                    Name = "TestFamily",
                    UserId = "TestUserId"
                }
            };
            await repoTest.AddAsync(house);
            await repoTest.SaveChangesAsync();
        }
    }
}
