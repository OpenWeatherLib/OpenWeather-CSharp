using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Enum;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class WeatherForecastPart
    {
        public DateTime DateTime { get; set; }

        public Main Main { get; set; }

        public IList<WeatherPart> Weather { get; set; }

        public Clouds Clouds { get; set; }

        public Wind Wind { get; set; }

        public Rain Rain { get; set; }

        public string DateTimeTxt { get; set; }

        public WeatherConditionEnum WeatherCondition { get; set; }
    }
}
