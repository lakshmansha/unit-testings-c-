using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingDemoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestingDemoAPI.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        [TestMethod()]
        public void Get_AnyFive_Weather_Details()
        {
            //Arrange 
            ILogger<WeatherForecastController> logger = Mock.Of<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(logger);

            //Act
            var result = controller.GetAnyFive();

            //Assert
            Assert.IsTrue(result.Count() == 5);
        }

        [TestMethod()]
        public void Get_OnlyOne_Weather_Details()
        {
            //Arrange 
            ILogger<WeatherForecastController> logger = Mock.Of<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(logger);

            //Act
            var result = controller.GetOne();

            //Assert
            Assert.IsTrue(result != null);
        }
    }
}