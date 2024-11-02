using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningMockingOpenWeather
{
    public interface IOpenWeatherMapApi
    {
        public float GetCurrentTemperatureInAntwerp();
    }
}
