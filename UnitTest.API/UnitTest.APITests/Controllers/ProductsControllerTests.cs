using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.EntityFrameworkCore;
using UnitTest.API.Data;
using UnitTest.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq.EntityFrameworkCore;

namespace UnitTest.API.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        public readonly DbContextOptions<UnitTestAPIContext> dbContextOptions;

        public ProductsControllerTests()
        {
            // Build DbContextOptions
            dbContextOptions = new DbContextOptionsBuilder<UnitTestAPIContext>()
                .UseInMemoryDatabase(databaseName: "MyUnitTestDb")
                .Options;
        }

        [TestMethod()]
        public async Task Get_All_Products()
        {
            //Arrange
            var unitTestContext = new UnitTestAPIContext(dbContextOptions);
            var fakeProducts = GetFakeProductList();
            fakeProducts.ForEach(async prod => await unitTestContext.Product.AddAsync(prod));
            await unitTestContext.SaveChangesAsync();
            var controller = new ProductsController(unitTestContext);

            //Act
            var products = (await controller.GetProduct()).Value;

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());
        }


        private static List<Product> GetFakeProductList()
        {
            return new List<Product>()
            {
                new Product { Id = 1, Name = "BBB", Price = 1800 },
                new Product { Id = 2, Name = "ZZZ", Price = 1800 },
                new Product { Id = 3, Name = "AAA", Price = 1800 },
            };
        }
    }
}