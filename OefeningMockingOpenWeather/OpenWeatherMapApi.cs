﻿using Newtonsoft.Json;
using System.Net.Http;

namespace OefeningMockingOpenWeather
{
    public class OpenWeatherMapApi : IOpenWeatherMapApi
    {
        private string url = "http://api.openweathermap.org/data/2.5/weather?q=Antwerp,BE&appid=b1a90ec4d94d84ecf2a3f2bb634b970d&units=metric";

        public float GetCurrentTemperatureInAntwerp()
        {
            using (var httpClient = new HttpClient())
            {
                var httpRespone = httpClient.GetAsync(url).GetAwaiter().GetResult();
                var response = httpRespone.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<OpenWeather>(response).main.temp;
            }
        }
    }
}
