using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data.Common;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Core.Models.Accessories;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class AccessoriesServiceTest
    {

        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IAccessoriesService accessoriesService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IAccessoriesService, AccessoriesService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            accessoriesService = serviceProvider.GetService<IAccessoriesService>()!;
        }

        [Test]
        public async Task AddAccessoriesShouldThrowExceptionIfImageOrModelAreNull()
        {
            var model = new AddAccessoriesViewModel
            {
                Name = "Foo",
                Description = "Bar",
                Category = "Category",
                Color = "pink",
                SizeAge = 40,
                StorageId = 20,
                UserId = "1"
            };
            var roothpath = "testRooth";

            Assert.That(() => accessoriesService.AddAccessories(model, roothpath), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task AllAccessoriesShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllAccessoriesViewModel>(await accessoriesService.AllAccessories(20));

        [Test]
        public async Task AllAccessoriesShouldReturnCorrectCount() =>
            Assert.That((await accessoriesService.AllAccessories(20)).Accessories.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllAccessoriesShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => accessoriesService.AllAccessories(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllAccessoriesByCategoryShouldReturnCorrectType() =>
       Assert.IsInstanceOf<AllAccessoriesByCategoryViewModel>(await accessoriesService.AllAccessoriesByCategory(20, "Hats"));

        [Test]
        public async Task AllAccessoriesByCategoryShouldReturnCorrectCount() =>
            Assert.That((await accessoriesService.AllAccessoriesByCategory(20, "Hats")).Accessories.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllAccessoriesByCategoryShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => accessoriesService.AllAccessoriesByCategory(200, "Hats"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllAccessoriesByCategoryShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => accessoriesService.AllAccessoriesByCategory(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllAccessoriesByCategoryShouldReturn0WhenCategoryIsWrong() =>
           Assert.That((await accessoriesService.AllAccessoriesByCategory(20, "WrongCatwgory")).Accessories.Count(), Is.EqualTo(0));

        [Test]
        public async Task GetAccessoriesDetailsModelByIdShouldReturnCorrectType() =>
      Assert.IsInstanceOf<DetailsAccessoriesViewModel>(await accessoriesService.GetAccessoriesDetailsModelById(10));

        [Test]
        public async Task GetAccessoriesDetailsModelByIdShouldThrowExceptionWhenIdIsWrong() =>
          Assert.That(() => accessoriesService.GetAccessoriesDetailsModelById(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task GetAccessoriesDetailsModelByIdShouldWorkCorrect() =>
         Assert.That((await accessoriesService.GetAccessoriesDetailsModelById(10)).Name, Is.EqualTo("TestAccessorie"));

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() =>
          Assert.IsInstanceOf<bool>(await accessoriesService.ExistsById(10));


        [Test]
        [TestCase(10)]
        [TestCase(11)]
        public async Task ExistsByIdShouldReturnTrueWhenAccessoriesExists(int accessorieId) =>
            Assert.That(await accessoriesService.ExistsById(accessorieId), Is.True);



        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenAccessoriesDoesntExisits(int accessorieId) =>
           Assert.That(await accessoriesService.ExistsById(accessorieId), Is.False);



        [Test]
        [TestCase("10")]
        [TestCase("11")]
        public async Task DeleteShouldWorkCorrect(int accessorieId)
        {
            await accessoriesService.DeleteById(accessorieId);

            Assert.That(await accessoriesService.ExistsById(accessorieId), Is.False);
        }

        [Test]
        public async Task AllAccessoriesByMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberAccessoriesViewModel>(await accessoriesService.AllAccessoriesByMemberId(10));

        [Test]
        public async Task AllAccessoriesByMemberIdShouldReturnCorrectCount() =>
            Assert.That((await accessoriesService.AllAccessoriesByMemberId(10)).Accessories.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllAccessoriesByMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => accessoriesService.AllAccessoriesByMemberId(200), Throws.Exception.TypeOf<InvalidOperationException>());

        public async Task AllAccessoriesByCategoryAndMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberAccessoriesByCategoryViewModel>(await accessoriesService.AllAccessoriesByCategoryAndMemberId(10, "Hats"));

        [Test]
        public async Task AllAccessoriesByCategoryAndMemberIdShouldReturnCorrectCount() =>
            Assert.That((await accessoriesService.AllAccessoriesByCategoryAndMemberId(10, "Hats")).Accessories.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllAccessoriesByCategoryAndMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => accessoriesService.AllAccessoriesByCategoryAndMemberId(200, "Hats"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllAccessoriesByCategoryAndMemberIdShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => accessoriesService.AllAccessoriesByCategoryAndMemberId(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllAccessoriesByCategoryAndMemberIdShouldReturn0WhencategoryIsWrong() =>
           Assert.That((await accessoriesService.AllAccessoriesByCategoryAndMemberId(10, "wrongCategory")).Accessories.Count(), Is.EqualTo(0));

        [TearDown]
        public void TearDown() => dbContext.Dispose();

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var accessorie = new Accessories()
            {
                Id = 10,
                Name = "TestAccessorie",
                ImagePath = "TestPath",
                Category = "Hats",
                MemberId = 10,
                Member = new Member()
                {
                    Id = 10,
                    FirstName = "FirstNameTest",
                    LastName = "LastNameTest",
                    ImagePath = "testImagePath",
                    ClothesSize = "XL"
                },
                Storage = new Storage()
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
                    },
                },
                IsActive = true,
                SizeAge = 1,
                UserId = "1"

            };

            await repoTest.AddAsync(accessorie);
            await repoTest.SaveChangesAsync();

            accessorie = new Accessories()
            {
                Id = 11,
                Name = "TestAccessorie1",
                ImagePath = "TestPath1",
                Category = "Boots",
                Storage = new Storage()
                {
                    Id = 21,
                    HouseId = 21,
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
                    },
                },
                IsActive = true,
                SizeAge = 1,
                UserId = "1"
            };
            await repoTest.AddAsync(accessorie);
            await repoTest.SaveChangesAsync();
        }
    }
}
