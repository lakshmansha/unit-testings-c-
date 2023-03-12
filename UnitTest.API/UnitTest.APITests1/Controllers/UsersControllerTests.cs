using NUnit.Framework;
using UnitTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.API.Data;
using Moq;
using UnitTest.API.Models;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using UnitTest.API.Service;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UnitTest.API.Controllers.Tests
{
    [TestFixture()]
    public class UsersControllerTests
    {
        public readonly DbContextOptions<UnitTestAPIContext> dbContextOptions;

        public UsersControllerTests()
        {
            // Build DbContextOptions
            dbContextOptions = new DbContextOptionsBuilder<UnitTestAPIContext>()
                .UseInMemoryDatabase(databaseName: "MyUnitTestDb")
                .Options;
        }

        [Test()]
        public async Task Get_All_Users()
        {
            //Arrange
            var unitTestContext = new UnitTestAPIContext(dbContextOptions);
            var fakeUsers = GetFakeUsersList();
            fakeUsers.ForEach(async prod => await unitTestContext.User.AddAsync(prod));
            await unitTestContext.SaveChangesAsync();            
            var userService = new UserService(unitTestContext);

            //Act
            var users = await userService.GetUser();

            //Assert
            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count());
        }

        private static List<User> GetFakeUsersList()
        {
            return new List<User>()
            {
                new User { Id = 1, Name = "John" },
                new User { Id = 2, Name = "Jane" }
            };
        }
    }
}