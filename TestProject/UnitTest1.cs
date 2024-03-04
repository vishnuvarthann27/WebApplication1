using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using WebApplication1.Controllers;

namespace TestProject
{
    public class UnitTest1
    {
        private WeatherForecastController weatherForecastController;
        private readonly ILogger<WeatherForecastController> _logger;

        public UnitTest1()
        {
            _logger = Substitute.For<ILogger<WeatherForecastController>>();
            weatherForecastController = new WeatherForecastController(_logger);
        }

        public ILogger<WeatherForecastController> Get_logger()
        {
            return _logger;
        }

        [Fact]
        public void GetNotNull()
        {

            var value = weatherForecastController.Get();
            _logger.LogInformation(value.ToString());
            var result = value as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void GetOkResult()
        {
            var value = weatherForecastController.Get();
            var result = value as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}