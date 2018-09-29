using System;
using System.Collections.Generic;
using Web.Models.OpenWeatherMap.Enum;

namespace Web.Models.OpenWeatherMap
{
    public class WeatherForecastPartViewModel
    {
        public DateTime DateTime { get; set; }

        public MainViewModel Main { get; set; }

        public IList<WeatherPartViewModel> Weather { get; set; }

        public CloudsViewModel Clouds { get; set; }

        public WindViewModel Wind { get; set; }

        public RainViewModel Rain { get; set; }

        public string DateTimeTxt { get; set; }

        public WeatherConditionViewModelEnum WeatherCondition { get; set; }
    }
}
