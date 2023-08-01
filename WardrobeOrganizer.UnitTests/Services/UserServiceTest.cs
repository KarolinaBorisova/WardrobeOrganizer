using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.UnitTests.Services
{
    public class UserServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private IUserService userService;

        [SetUp]
        public async Task Setup()
        {

            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo!);

            userService = serviceProvider.GetService<IUserService>()!;
        }

        [Test]
        public async Task AllUsersShouldReturnCorrectType() =>
           Assert.IsInstanceOf<AllUsersViewModel>(await userService.AllUsers());

        [Test]
        public async Task AllUsersShouldReturnCorrectCount() =>
            Assert.That((await userService.AllUsers()).Users.Count(), Is.EqualTo(4));

        [Test]
        public async Task InActiveShoudBlockTheUser()
        {
            await userService.InActive("userTestId");
            var user = await userService.GetUserById("userTestId");
            Assert.That(user.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task InActiveShoudThrowExceptionIfUserIdIsNull()
        {
            Assert.That(() => userService.InActive(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task ActiveShoudUnBlockTheUser()
        {
            await userService.Active("userTestId2");
            var user = await userService.GetUserById("userTestId2");
            Assert.That(user.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task ActiveShoudThrowExceptionIfUserIdIsNull()
        {
            Assert.That(() => userService.Active(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task ExistsByIdShouldReturnCorrectType()
        {
            Assert.IsInstanceOf<bool>(await userService.ExistsById("userTestId2"));
        }

        [Test]
        [TestCase("userTestId2")]
        [TestCase("userTestId")]
        public async Task ExistsByIdShouldReturnTrueWhenUserExists(string userId)
        {
            Assert.That(await userService.ExistsById(userId), Is.True);
        }


        [Test]
        [TestCase("notValidUser")]
        public async Task ExistsByIdShouldReturnFalseWhenUserDoesntExisits(string userId) =>
           Assert.That(await userService.ExistsById(userId), Is.False);


        [Test]
        public async Task GetUserByIdShouldReturnCorrectType() =>
            Assert.IsInstanceOf<UserViewModel>(await userService.GetUserById("userTestId2"));


        [Test]
        public async Task GetUserByIdShouldReturnCorrectUser()
        {
            var user = await userService.GetUserById("userTestId2");
            Assert.That(user.FullName, Is.EqualTo("TestFirstName2 TestLastName2"));
        }

        [Test]
        public async Task GetUserByIdShouldThrowExceptionIfUserIdIsWrong()
        {
            Assert.That(() => userService.Active("dawrawsfa"), Throws.Exception.TypeOf<ArgumentNullException>());
        }


        [TearDown]
        public void TearDown() => dbContext.Dispose();

        private async Task SeedDbAsync(IRepository repoTest)
        {
            var user = new User()
            {
                Id = "userTestId",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                IsActive = true,
            };

            await repoTest.AddAsync(user);
            await repoTest.SaveChangesAsync();

            user = new User()
            {
                Id = "userTestId2",
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                IsActive= false,
            };
            await repoTest.AddAsync(user);
            await repoTest.SaveChangesAsync();
        }
    }
}
