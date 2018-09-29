using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class WeatherForecastDto
    {
        public string Cod { get; set; }

        public double Message { get; set; }

        public uint Count { get; set; }

        public IList<WeatherForecastPartDto> List { get; set; }

        public CityDto City { get; set; }
    }
}
