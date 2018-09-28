using Services.DataScienceToolkit.Dto;
using System.Collections.Generic;

namespace Services.OpenWeatherMap.Dto
{
    public class WeatherForecastDto
    {
        public string Cod { get; set; }

        public int Message { get; set; }

        public uint Count { get; set; }

        public IList<WeatherForecastPartDto> List { get; set; }

        public CityDto City { get; set; }
    }
}
