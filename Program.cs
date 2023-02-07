using CustomWeatherClientTool.Models;
using CustomWeatherClientTool.Services;

Start:
Console.WriteLine("Enter Your City Name: ");
var cityName = Console.ReadLine()?.Trim();

// CHECK FOR CITY NAME IS ENTERED OR NOT
if (cityName == null || cityName == "")
{
    Console.WriteLine("Please Type Your City Name...\n\n");
    goto Start;
}
else
{
    // GET CITY INFO FROM CITY NAME
    var _city = WeatherService.FindCityByName(cityName);

    if (_city == null)
    {
        Console.WriteLine("City Not Found !");
    }
    else
    {
        //GET WEATHER INFO BY CITY
        var CityWeather = await WeatherService.GetWeather(_city);

        // PRINT WEATHER INFO
        if (CityWeather != null)
        {
            Console.WriteLine("\n\nSEARCHED CITY INFO\n******************************");
            Console.WriteLine("City Name: {0}, {1} ({2})", _city.CityName, _city.Country, _city.CountryCode);

            Console.WriteLine("\nWEATHER INFO\n******************************");
            Console.WriteLine("Temperature: {0}°C", CityWeather?.CurrentWeather.Temperature);
            Console.WriteLine("Wind Speed: {0} KM/h", CityWeather?.CurrentWeather.WindSpeed);
            Console.WriteLine("Wind Direction: {0} degrees", CityWeather?.CurrentWeather.WindDirection);

            Console.WriteLine("\nGEO LOCATION\n******************************");
            Console.WriteLine("Latitude: {0}", CityWeather?.Latitude.ToString());
            Console.WriteLine("Longitude: {0}", CityWeather?.Longitude.ToString());
        }
        else
        {
            Console.WriteLine("Sorry !!!, Weather Information not found.");
        }
    }
}