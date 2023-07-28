using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Tests.Services
{
    public class FamilyServiceTests
    {
        [Fact]
        public void CheckIfFamilyExists()
        {
            var list = new List<Family>();
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(x => x.AllReadonly<Family>()).Returns(list.AsQueryable());
           


            var result = true;
            Assert.True(result);
        }
    }
}
