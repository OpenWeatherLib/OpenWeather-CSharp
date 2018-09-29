using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Enum;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class WeatherForecastPartDto
    {
        public DateTime DateTime { get; set; }

        public MainDto Main { get; set; }

        public IList<WeatherPartDto> Weather { get; set; }

        public CloudsDto Clouds { get; set; }

        public WindDto Wind { get; set; }

        public RainDto Rain { get; set; }

        public string DateTimeTxt { get; set; }

        public WeatherConditionDtoEnum WeatherCondition { get; set; }
    }
}
