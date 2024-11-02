using FluentAssertions;
using Moq;

namespace OefeningMockingOpenWeather.UnitTests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IOpenWeatherMapApi> _openWeatherMapApi;
        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _openWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            _weatherService = new WeatherService(_openWeatherMapApi.Object);
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_Return_Freezing()
        {
            string expectedResult = "Brrrr, it's freezing";
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Returns(-1);

            var result = _weatherService.GetCurrentWeatherInAntwerp();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_When_Temperature_Between_0_And_15_Returns_Cold()
        {
            string expectedResult = "It's cold";
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Returns(10);

            var result = _weatherService.GetCurrentWeatherInAntwerp();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_When_Temperature_Between_15_And_24_Returns_Ok()
        {
            string expectedResult = "It's ok";
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Returns(20);

            var result = _weatherService.GetCurrentWeatherInAntwerp();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_When_Temperature_Above_24_Returns_Hot()
        {
            string expectedResult = "It's HOT!!!";
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Returns(30);

            var result = _weatherService.GetCurrentWeatherInAntwerp();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_When_Getting_Temperature_Fails()
        {
            //makes the method fail
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Throws<Exception>();

            //checks if exception was thrown
            Action act = () => _weatherService.GetCurrentWeatherInAntwerp();
            act.Should().Throw<Exception>();

            //Assert.Throws<Exception>(() => _weatherService.GetCurrentWeatherInAntwerp()); <-- dit is zonder fluentassertions
        }

        [Fact]
        public void GetCurrentWeatherInAntwerp_When_Getting_Temperature_Fails_Returns_ExceptionMessage()
        {
            string expectedResult = "Failed to get temperature";
            _openWeatherMapApi.Setup(t => t.GetCurrentTemperatureInAntwerp()).Throws<Exception>();

            string result = _weatherService.GetCurrentWeatherInAntwerp();

            result.Should().Be(expectedResult);

            //Assert.Equal(expectedResult, result); <-- dit is zonder fluentassertions
        }
    }
}