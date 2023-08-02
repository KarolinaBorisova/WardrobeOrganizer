using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class ClothesServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IClothesService clothesService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IFileService,FileService>()
                .AddSingleton<IClothesService, ClothesService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            clothesService = serviceProvider.GetService<IClothesService>()!;
        }

        [Test]
        public async Task AddClothesShouldThrowExceptionIfImageOrModelAreNull()
        {
          var model = new AddClothesViewModel
          {
              Name = "Foo",
              Description = "Bar",
              Category = "Category",
              Color = "pink",
              Size = "XLTest",
              StorageId = 20,
          
          };
            var roothpath = "testRooth";
         
            Assert.That(() => clothesService.AddClothes(model,roothpath), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task AllClothesShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllClothesViewModel>(await clothesService.AllClothes(20));

        [Test]
        public async Task AllClothesShouldReturnCorrectCount() =>
            Assert.That((await clothesService.AllClothes(20)).Clothes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllClothesShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => clothesService.AllClothes(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllClothesByCategoryShouldReturnCorrectType() =>
       Assert.IsInstanceOf<AllClothesByCategoryViewModel>(await clothesService.AllClothesByCategory(20, "Tshirts"));

        [Test]
        public async Task AllClothesByCategoryShouldReturnCorrectCount() =>
            Assert.That((await clothesService.AllClothesByCategory(20, "Tshirts")).Clothes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllClothesByCategoryShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => clothesService.AllClothesByCategory(200, "Tshirts"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllClothesByCategoryShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => clothesService.AllClothesByCategory(200, null ), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllClothesByCategoryShouldReturn0WhenCategoryIsWrong() =>
           Assert.That((await clothesService.AllClothesByCategory(20, "WrongCatwgory")).Clothes.Count(), Is.EqualTo(0));

        [Test]
        public async Task GetClothesDetailsModelByIdShouldReturnCorrectType() =>
      Assert.IsInstanceOf<DetailsClothesViewModel>(await clothesService.GetClothesDetailsModelById(10));

        [Test]
        public async Task GetClothesDetailsModelByIdShouldThrowExceptionWhenIdIsWrong() =>
          Assert.That(() => clothesService.GetClothesDetailsModelById(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task GetClothesDetailsModelByIdShouldWorkCorrect() =>
         Assert.That((await clothesService.GetClothesDetailsModelById(10)).Name  , Is.EqualTo("TestClothes"));

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() =>
          Assert.IsInstanceOf<bool>(await clothesService.ExistsById(10));


        [Test]
        [TestCase(10)]
        [TestCase(11)]
        public async Task ExistsByIdShouldReturnTrueWhenClothesExists(int clothesId) =>
            Assert.That(await clothesService.ExistsById(clothesId), Is.True);



        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenClothesDoesntExisits(int clothesId) =>
           Assert.That(await clothesService.ExistsById(clothesId), Is.False);



        [Test]
        [TestCase("10")]
        [TestCase("11")]
        public async Task DeleteShouldWorkCorrect(int clothesId)
        {
            await clothesService.DeleteById(clothesId);

            Assert.That(await clothesService.ExistsById(clothesId), Is.False);
        }

        [Test]
        public async Task AllClothesByMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberClothesViewModel>(await clothesService.AllClothesByMemberId(10));

        [Test]
        public async Task AllClothesByMemberIdShouldReturnCorrectCount() =>
            Assert.That((await clothesService.AllClothesByMemberId(10)).Clothes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllClothesByMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => clothesService.AllClothesByMemberId(200), Throws.Exception.TypeOf<InvalidOperationException>());

        public async Task AllClothesByCategoryAndMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberClothesByCategoryViewModel>(await clothesService.AllClothesByCategoryAndMemberId(10, "Tshirts"));

        [Test]
        public async Task AllClothesByCategoryAndMemberIdShouldReturnCorrectCount() =>
            Assert.That((await clothesService.AllClothesByCategoryAndMemberId(10, "Tshirts")).Clothes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllClothesByCategoryAndMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => clothesService.AllClothesByCategoryAndMemberId(200, "Tshirts"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllClothesByCategoryAndMemberIdShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => clothesService.AllClothesByCategoryAndMemberId(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllClothesByCategoryAndMemberIdShouldReturn0WhencategoryIsWrong() =>
           Assert.That((await clothesService.AllClothesByCategoryAndMemberId(10, "wrongCategory")).Clothes.Count(), Is.EqualTo(0));

        [TearDown]
        public void TearDown() => dbContext.Dispose();

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var clothes = new Clothes()
            {
                Id = 10,
                Name = "TestClothes",
                ImagePath = "TestPath",
                Category = "Tshirts",
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
                Size = "TestSize"

            };

            await repoTest.AddAsync(clothes);
            await repoTest.SaveChangesAsync();

            clothes = new Clothes()
            {
                Id = 11,
                Name = "TestClothes1",
                ImagePath = "TestPath1",
                Category = "testCategory1",
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
                Size = "TestSize1"
            };
            await repoTest.AddAsync(clothes);
            await repoTest.SaveChangesAsync();
        }
    }
}
