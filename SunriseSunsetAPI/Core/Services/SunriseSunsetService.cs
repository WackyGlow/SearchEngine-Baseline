using SunriseSunsetAPI.Core.Interfaces;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using SunriseSunsetAPI.Core.Models;

namespace SunriseSunsetAPI.Core.Services
{
    public class SunriseSunsetService : ISunriseSunsetAPI
    {
        public string BASE_URL => "https://api.sunrise-sunset.org/";

        public SunriseSunsetDTO GetSunriseSunsetAsync(string latitude, string longitude, string date)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BASE_URL}json?lat={latitude}&lng={longitude}&date={date}&formatted=0";
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<SunriseSunSetResult>(content);
                return new SunriseSunsetDTO 
                { 
                    DayLength = int.Parse( result.results.day_length), 
                    SolarNoon = result.results.solar_noon, 
                    Status = result.status, 
                    Sunrise = result.results.sunrise, 
                    Sunset = result.results.sunset
                };
            }
        }

 
    }
}