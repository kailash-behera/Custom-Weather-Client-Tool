using CustomWeatherClientTool.Models;
using CustomWeatherClientTool.Services;

Start:
Console.WriteLine("Enter Your City Name: ");
var cityName = Console.ReadLine()?.Trim();

//Console.WriteLine("Your city name is {0} \n\n", cityName);

if (cityName == null || cityName == "")
{
    Console.WriteLine("Please Type Your City Name...\n\n");
    goto Start;
}
else
{
    var _city = WeatherService.FindCityByName(cityName);

    if(_city == null)
    {
        Console.WriteLine("City Not Found !");
    }
    else
    {
        var CityWeather = await WeatherService.GetWeather(_city);

        if (CityWeather != null)
        {
            Console.WriteLine("Temperature: {0}°C", CityWeather?.CurrentWeather.Temperature);
            Console.WriteLine("Wind Speed: {0} KM/h", CityWeather?.CurrentWeather.WindSpeed);
            Console.WriteLine("Wind Direction: {0} degrees", CityWeather?.CurrentWeather.WindDirection);

            Console.WriteLine("Latitude: {0}", CityWeather?.Latitude.ToString());
            Console.WriteLine("Longitude: {0}", CityWeather?.Longitude.ToString());
        }
    }
}