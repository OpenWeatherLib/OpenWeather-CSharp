using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class WeatherForecast
    {
        public string Cod { get; set; }

        public double Message { get; set; }

        public uint Count { get; set; }

        public IList<WeatherForecastPart> List { get; set; }

        public City City { get; set; }
    }
}
