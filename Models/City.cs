using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomWeatherClientTool.Models
{
    public class City
    {
        [JsonPropertyName("city")]
        public string CityName { get; set; } = string.Empty;

        [JsonPropertyName("lat")]
        public string Latitude { get; set; } = string.Empty;

        [JsonPropertyName("lng")]
        public string Longitude { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("iso2")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonPropertyName("admin_name")]
        public string StateName { get; set; } = string.Empty;

        [JsonPropertyName("capital")]
        public string Capital { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public string Population { get; set; } = string.Empty;

        [JsonPropertyName("population_proper")]
        public string ProperPopulation { get; set; } = string.Empty;
    }
}
