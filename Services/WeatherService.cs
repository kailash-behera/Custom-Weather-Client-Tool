using CustomWeatherClientTool.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CustomWeatherClientTool.Services
{
    public class WeatherService
    {
        /// <summary>
        /// Find City By City Name
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public static City? FindCityByName(string cityName)
        {
            try
            {
                List<City>? CityList;

                using (StreamReader r = new StreamReader(@"./cities.json"))
                {
                    string json = r.ReadToEnd();
                    CityList = JsonSerializer.Deserialize<List<City>>(json);
                }

                return CityList?.FirstOrDefault<City>(c => c.CityName.Trim().ToLower() == cityName.ToLower());
            }
            catch (Exception)
            {
                return null;
            }   
        }

        /// <summary>
        /// Get Weather Information By City Latitude & Longitude
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public static async Task<Weather?> GetWeather(City city)
        {
            try
            {
                Weather? weather = null;

                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri("https://api.open-meteo.com/v1/")
                };

                var httpResponse = await httpClient.GetAsync($"forecast?latitude={city.Latitude}&longitude={city.Longitude}&current_weather=true");

                if (httpResponse.IsSuccessStatusCode)
                {
                    weather = await httpResponse.Content.ReadFromJsonAsync<Weather>();
                }

                return weather;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
