using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class FamilyServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

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
            await SeedDbAsync(repoTest);
          
        }

        [Test]
        public void CheckIfFamilyWithIdExists()
        {
            var family = new Family()
            {
                Id = 1,
                Name = "Test"
            };

            var service = serviceProvider.GetService<IFamilyService>();

            var result = service.ExistsById(3);
            Assert.AreEqual(true,result.Result);
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
                Name = "TestFamily"
            };

            await repoTest.AddAsync(family);
            await repoTest.SaveChangesAsync();
        }
    }
}
