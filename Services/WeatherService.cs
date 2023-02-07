using CustomWeatherClientTool.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CustomWeatherClientTool.Services
{
    public class WeatherService
    {
        public static City? FindCityByName(string cityName)
        {
            List<City>? CityList;

            using (StreamReader r = new StreamReader(@"../../../in.json"))
            {
                string json = r.ReadToEnd();
                CityList = JsonSerializer.Deserialize<List<City>>(json);
            }

            return CityList?.FirstOrDefault<City>(c => c.CityName.Trim().ToLower() == cityName.ToLower());
        }

        public static async Task<Weather?> GetWeather(City city)
        {
            Weather? weather = null;

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.open-meteo.com/v1/")
            };

            var httpResponse = await httpClient.GetAsync($"forecast?latitude={city.Latitude}&longitude={city.Longitude}&current_weather=true");

            if(httpResponse.IsSuccessStatusCode)
            {
                weather = await httpResponse.Content.ReadFromJsonAsync<Weather>();
            }

            return weather;
        }
    }
}
