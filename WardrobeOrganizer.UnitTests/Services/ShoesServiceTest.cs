using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class ShoesServiceTest
    {

        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IShoesService shoesService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IShoesService, ShoesService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            shoesService = serviceProvider.GetService<IShoesService>()!;
        }

        [Test]
        public async Task AddShoesShouldThrowExceptionIfImageOrModelAreNull()
        {
            var model = new AddShoesViewModel
            {
                Name = "Foo",
                Description = "Bar",
                Category = "Category",
                Color = "pink",
                SizeEu = 40,
                StorageId = 20,

            };
            var roothpath = "testRooth";

            Assert.That(() => shoesService.AddShoes(model, roothpath), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task AllShoesShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllShoesViewModel>(await shoesService.AllShoes(20));

        [Test]
        public async Task AllShoesShouldReturnCorrectCount() =>
            Assert.That((await shoesService.AllShoes(20)).Shoes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllShoesShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => shoesService.AllShoes(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllShoesByCategoryShouldReturnCorrectType() =>
       Assert.IsInstanceOf<AllShoesByCategoryViewModel>(await shoesService.AllShoesByCategory(20, "Boots"));

        [Test]
        public async Task AllShoesByCategoryShouldReturnCorrectCount() =>
            Assert.That((await shoesService.AllShoesByCategory(20, "Boots")).Shoes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllShoesByCategoryShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => shoesService.AllShoesByCategory(200, "Boots"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllShoesByCategoryShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => shoesService.AllShoesByCategory(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllShoesByCategoryShouldReturn0WhenCategoryIsWrong() =>
           Assert.That((await shoesService.AllShoesByCategory(20, "WrongCatwgory")).Shoes.Count(), Is.EqualTo(0));

        [Test]
        public async Task GetShoesDetailsModelByIdShouldReturnCorrectType() =>
      Assert.IsInstanceOf<DetailsShoesViewModel>(await shoesService.GetShoesDetailsModelById(10));

        [Test]
        public async Task GetShoesDetailsModelByIdShouldThrowExceptionWhenIdIsWrong() =>
          Assert.That(() => shoesService.GetShoesDetailsModelById(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task GetShoesDetailsModelByIdShouldWorkCorrect() =>
         Assert.That((await shoesService.GetShoesDetailsModelById(10)).Name, Is.EqualTo("TestShoes"));

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() =>
          Assert.IsInstanceOf<bool>(await shoesService.ExistsById(10));


        [Test]
        [TestCase(10)]
        [TestCase(11)]
        public async Task ExistsByIdShouldReturnTrueWhenShoesExists(int shoesId) =>
            Assert.That(await shoesService.ExistsById(shoesId), Is.True);



        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenShoesDoesntExisits(int shoesId) =>
           Assert.That(await shoesService.ExistsById(shoesId), Is.False);



        [Test]
        [TestCase("10")]
        [TestCase("11")]
        public async Task DeleteShouldWorkCorrect(int shoesId)
        {
            await shoesService.DeleteById(shoesId);

            Assert.That(await shoesService.ExistsById(shoesId), Is.False);
        }

        [Test]
        public async Task AllShoesByMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberShoesViewModel>(await shoesService.AllShoesByMemberId(10));

        [Test]
        public async Task AllShoesByMemberIdShouldReturnCorrectCount() =>
            Assert.That((await shoesService.AllShoesByMemberId(10)).Shoes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllShoesByMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => shoesService.AllShoesByMemberId(200), Throws.Exception.TypeOf<InvalidOperationException>());

        public async Task AllShoesByCategoryAndMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberShoesByCategoryViewModel>(await shoesService.AllShoesByCategoryAndMemberId(10, "Boots"));

        [Test]
        public async Task AllShoesByCategoryAndMemberIdShouldReturnCorrectCount() =>
            Assert.That((await shoesService.AllShoesByCategoryAndMemberId(10, "Boots")).Shoes.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllShoesByCategoryAndMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => shoesService.AllShoesByCategoryAndMemberId(200, "Boots"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllShoesByCategoryAndMemberIdShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => shoesService.AllShoesByCategoryAndMemberId(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllShoesByCategoryAndMemberIdShouldReturn0WhencategoryIsWrong() =>
           Assert.That((await shoesService.AllShoesByCategoryAndMemberId(10, "wrongCategory")).Shoes.Count(), Is.EqualTo(0));

        [TearDown]
        public void TearDown() => dbContext.Dispose();

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var shoes = new Shoes()
            {
                Id = 10,
                Name = "TestShoes",
                ImagePath = "TestPath",
                Category = "Boots",
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
                SizeEu = 42

            };

            await repoTest.AddAsync(shoes);
            await repoTest.SaveChangesAsync();

            shoes = new Shoes()
            {
                Id = 11,
                Name = "TestShoes1",
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
                SizeEu = 42
            };
            await repoTest.AddAsync(shoes);
            await repoTest.SaveChangesAsync();
        }
    }
}
