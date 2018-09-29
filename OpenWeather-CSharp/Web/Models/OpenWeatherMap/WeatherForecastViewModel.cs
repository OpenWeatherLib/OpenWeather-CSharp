using System.Collections.Generic;
using Web.Models.DataScienceToolkit;

namespace Web.Models.OpenWeatherMap
{
    public class WeatherForecastViewModel
    {
        public string Cod { get; set; }

        public int Message { get; set; }

        public uint Count { get; set; }

        public IList<WeatherForecastPartViewModel> List { get; set; }

        public CityViewModel City { get; set; }
    }
}
