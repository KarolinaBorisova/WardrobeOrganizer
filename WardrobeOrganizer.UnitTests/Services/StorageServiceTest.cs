using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class StorageServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IStorageService storageService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IStorageService, StorageService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            storageService = serviceProvider.GetService<IStorageService>()!;
        }

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() =>
            Assert.IsInstanceOf<bool>(await storageService.ExistsById(2));
        

        [Test]
        [TestCase(20)]
        [TestCase(25)]
        public async Task ExistsByIdShouldReturnTrueWhenStorageExists(int storageId) => 
            Assert.That(await storageService.ExistsById(storageId), Is.True);
        


        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenStorageDoesntExisits(int storageId) =>
           Assert.That(await storageService.ExistsById(storageId), Is.False);

        [Test]
        public async Task GetStorageByIdShouldReturnCorrectType() =>
            Assert.IsInstanceOf<InfoStorageViewModel>(await storageService.GetStorageById(20));
        

        [Test]
        public async Task GetStorageByIdShouldReturnCorrectStorage()
        {
            var house = await storageService.GetStorageById(20);
            Assert.That(house.Name, Is.EqualTo("TestStorage"));
        }

        [Test]
        public async Task GetStorageByIdShouldThrowException() =>
            Assert.That(() =>  storageService.GetStorageById(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AddStorageShouldWorkCorrect()
        {
            var model = new AddStorageViewModel
            {
                Name = "StorageName",
               HouseId = 51,
            };
            var storageId = await storageService.AddStorage(model);

            Assert.That((await storageService.GetStorageById(storageId)).Name, Is.EqualTo("StorageName"));
        }


        [Test]
        public async Task AddStorageShouldThrowExceptionWhenHouseIdIsWrong()
        {
            var model = new AddStorageViewModel
            {
                Name = "StorageName",
                HouseId = 10,
            };

            Assert.That(() => storageService.AddStorage(model), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public async Task AllStoragesShouldReturnCorrectType() =>
         Assert.IsInstanceOf<ICollection<AllStoragesViewModel>>(await storageService.AllStorages(50));

        [Test]
        public async Task AllStoragesShouldReturnCorrectCount() =>
            Assert.That((await storageService.AllStorages(50)).Count(), Is.EqualTo(1));

        [Test]
        public async Task AllStoragesShouldReturn0WhenHouseIdIsWrong() =>
          Assert.That((await storageService.AllStorages(500)).Count(), Is.EqualTo(0));

        [Test]
        [TestCase("20")]
        [TestCase("25")]
        public async Task DeleteShouldWorkCorrect(int storageId)
        {
            await storageService.Delete(storageId);

            Assert.That(await storageService.ExistsById(storageId), Is.False);
        }
        [Test]

        public async Task EditShouldWorkCorrect()
        {
            InfoStorageViewModel model = new()
            {
                Id = 20,
                Name = "TestStorageEdited"

            };

            await storageService.Edit(model);

            var storage = await storageService.GetStorageById(model.Id);

            Assert.That(model.Name, Is.EqualTo(storage.Name));
        }
        public async Task EditShouldThrowExceptionIfModelIsNull() =>
            Assert.That(() => storageService.Edit(null), Throws.Exception.TypeOf<ArgumentNullException>());
       

        [TearDown]
        public void TearDown() => dbContext.Dispose();
        

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var storage = new Storage()
            {
               Id = 20,
               HouseId = 20,
               Name = "TestStorage",
               House = new House()
               {
                   Id = 50,
                   Name = "TestHouse2",
                   Address = "TestAddress2",
                   IsActive = true,
                   Family = new Family
                   {
                       Id = 50,
                       Name = "TestFamily",
                       UserId = "TestUserId"
                   }
               }
        };

            await repoTest.AddAsync(storage);
            await repoTest.SaveChangesAsync();

            storage = new Storage()
            {
                Id = 25,
                HouseId = 25,
                Name = "TestStorage",
                House = new House()
                {
                    Id = 51,
                    Name = "TestHouse2",
                    Address = "TestAddress2",
                    IsActive = true,
                    Family = new Family
                    {
                        Id = 51,
                        Name = "TestFamily",
                        UserId = "TestUserId"
                    }
                }
        };
            await repoTest.AddAsync(storage);
            await repoTest.SaveChangesAsync();
        }
    }
}
