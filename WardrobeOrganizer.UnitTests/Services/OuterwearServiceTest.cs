using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data.Common;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class OuterwearServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IOuterwearService outerwearService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IOuterwearService, OuterwearService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            outerwearService = serviceProvider.GetService<IOuterwearService>()!;
        }

        [Test]
        public async Task AddOuterwearShouldThrowExceptionIfImageOrModelAreNull()
        {
            var model = new AddOuterwearViewModel
            {
                Name = "Foo",
                Description = "Bar",
                Category = "Category",
                Color = "pink",
                Size = "XLTest",
                StorageId = 20,

            };
            var roothpath = "testRooth";

            Assert.That(() => outerwearService.AddOuterWear(model, roothpath), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task AllOuterwearShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllOuterwearViewModel>(await outerwearService.AllOutwear(20));

        [Test]
        public async Task AllOuterwearShouldReturnCorrectCount() =>
            Assert.That((await outerwearService.AllOutwear(20)).Outerwear.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllOuterwearShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => outerwearService.AllOutwear(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllOuterwearByCategoryShouldReturnCorrectType() =>
       Assert.IsInstanceOf<AllOuterwearByCategoryViewModel>(await outerwearService.AllOuterwearByCategory(20, "Vests"));

        [Test]
        public async Task AllOuterwearByCategoryShouldReturnCorrectCount() =>
            Assert.That((await outerwearService.AllOuterwearByCategory(20, "Vests")).Outerwear.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllOuterwearByCategoryShouldThrowExceptionWhenStorageIdIsWrong() =>
          Assert.That(() => outerwearService.AllOuterwearByCategory(200, "Vests"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllOuterwearByCategoryShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => outerwearService.AllOuterwearByCategory(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllOuterwearByCategoryShouldReturn0WhenCategoryIsWrong() =>
           Assert.That((await outerwearService.AllOuterwearByCategory(20, "WrongCatwgory")).Outerwear.Count(), Is.EqualTo(0));

        [Test]
        public async Task GetOuterwearDetailsModelByIdShouldReturnCorrectType() =>
      Assert.IsInstanceOf<DetailsOuterwearViewModel>(await outerwearService.GetOuterwearDetailsModelById(10));

        [Test]
        public async Task GetOuterwearDetailsModelByIdShouldThrowExceptionWhenIdIsWrong() =>
          Assert.That(() => outerwearService.GetOuterwearDetailsModelById(200), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task GetOuterwearDetailsModelByIdShouldWorkCorrect() =>
         Assert.That((await outerwearService.GetOuterwearDetailsModelById(10)).Name, Is.EqualTo("TestOuterwear"));

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType() =>
          Assert.IsInstanceOf<bool>(await outerwearService.ExistsById(10));


        [Test]
        [TestCase(10)]
        [TestCase(11)]
        public async Task ExistsByIdShouldReturnTrueWhenOuterwearExists(int outerwerId) =>
            Assert.That(await outerwearService.ExistsById(outerwerId), Is.True);



        [Test]
        [TestCase(500)]
        public async Task ExistsByIdShouldReturnFalseWhenOuterwearDoesntExisits(int outerwearId) =>
           Assert.That(await outerwearService.ExistsById(outerwearId), Is.False);



        [Test]
        [TestCase("10")]
        [TestCase("11")]
        public async Task DeleteShouldWorkCorrect(int outerwearId)
        {
            await outerwearService.DeleteById(outerwearId);

            Assert.That(await outerwearService.ExistsById(outerwearId), Is.False);
        }

        [Test]
        public async Task AllOuterwearByMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberOuterwearViewModel>(await outerwearService.AllOuterwearByMemberId(10));

        [Test]
        public async Task AllOuterwearByMemberIdShouldReturnCorrectCount() =>
            Assert.That((await outerwearService.AllOuterwearByMemberId(10)).Outerwear.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllOuterwearByMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => outerwearService.AllOuterwearByMemberId(200), Throws.Exception.TypeOf<InvalidOperationException>());

        public async Task AllOuterwearByCategoryAndMemberIdShouldReturnCorrectType() =>
        Assert.IsInstanceOf<AllMemberOutwearByCategoryViewModel>(await outerwearService.AllOuterwearByCategoryAndMemberId(10, "Vests"));

        [Test]
        public async Task AllOuterwearByCategoryAndMemberIdShouldReturnCorrectCount() =>
            Assert.That((await outerwearService.AllOuterwearByCategoryAndMemberId(10, "Vests")).Outerwear.Count(), Is.EqualTo(1));

        [Test]
        public async Task AllOuterwearByCategoryAndMemberIdShouldThrowExceptionWhenMemberIdIsWrong() =>
          Assert.That(() => outerwearService.AllOuterwearByCategoryAndMemberId(200, "Vests"), Throws.Exception.TypeOf<InvalidOperationException>());

        [Test]
        public async Task AllOuterwearByCategoryAndMemberIdShouldThrowExceptionWhenCategoryIsNull() =>
          Assert.That(() => outerwearService.AllOuterwearByCategoryAndMemberId(200, null), Throws.Exception.TypeOf<ArgumentNullException>());

        [Test]
        public async Task AllOuterwearByCategoryAndMemberIdShouldReturn0WhencategoryIsWrong() =>
           Assert.That((await outerwearService.AllOuterwearByCategoryAndMemberId(10, "wrongCategory")).Outerwear.Count(), Is.EqualTo(0));

        [TearDown]
        public void TearDown() => dbContext.Dispose();

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var outerwear = new Outerwear()
            {
                Id = 10,
                Name = "TestOuterwear",
                ImagePath = "TestPath",
                Category = "Vests",
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

            await repoTest.AddAsync(outerwear);
            await repoTest.SaveChangesAsync();

            outerwear = new Outerwear()
            {
                Id = 11,
                Name = "TestClothes1",
                ImagePath = "TestPath1",
                Category = "Vests",
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
            await repoTest.AddAsync(outerwear);
            await repoTest.SaveChangesAsync();
        }
    }
}
