using NUnit.Framework;
using UnitTest.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTest.API.Controllers.Tests
{
    [TestFixture()]
    public class WeatherForecastControllerTests
    {
        [Test()]
        public void GetTest()
        {
            //Arrange
            ILogger<WeatherForecastController> logger = Mock.Of<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(logger);

            //Act
            var response = controller.Get();

            //Assert
            Assert.IsTrue(response.Count() > 0);
        }
    }
}