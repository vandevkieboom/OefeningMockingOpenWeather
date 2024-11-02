using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningMockingOpenWeather
{
    public class WeatherService
    {
        private readonly IOpenWeatherMapApi _openWeatherMapApi;

        public WeatherService(IOpenWeatherMapApi openWeatherMapApi)
        {
            _openWeatherMapApi = openWeatherMapApi;
        }

        public string GetCurrentWeatherInAntwerp()
        {
            try
            {
                var temp = _openWeatherMapApi.GetCurrentTemperatureInAntwerp();
                if (temp < 0)
                {
                    return "Brrrr, it's freezing";
                }
                if (temp < 15)
                {
                    return "It's cold";
                }
                if (temp < 24)
                {
                    return "It's ok";
                }
                return "It's HOT!!!";
            }
            catch (Exception)
            {
                return "Failed to get temperature";
            }
        }
    }
}
