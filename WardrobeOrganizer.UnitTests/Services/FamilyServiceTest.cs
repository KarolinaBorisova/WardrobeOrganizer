using Microsoft.Extensions.DependencyInjection;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    [TestFixture]
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
                .BuildServiceProvider();

            var repoTest = serviceProvider.GetService<IRepository>();

            await SeedDbAsync(repoTest!);

            familyService = serviceProvider.GetService<IFamilyService>()!;
        }

        [Test]
        public async Task ExistsShouldReturnCorrectType() =>
           Assert.IsInstanceOf<bool>(await familyService.ExistsById(5000));

        [Test]
        public void CheckIfFamilyWithIdExists()
        {
            var family = new Family()
            {
                Id = 1,
                Name = "Test"
            };

           

           

        //   
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private static async Task SeedDbAsync(IRepository repoTest)
        {
            var family = new Family()
            {
                Name = "TestFamily"
            };

            await repoTest.AddAsync(family);
            await repoTest.SaveChangesAsync();
        }
    }
}
