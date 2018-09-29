using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap.Enum;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// WeatherForecastPartViewModel
    /// </summary>
    public class WeatherForecastPartViewModel
    {
        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Main
        /// </summary>
        public MainViewModel Main { get; set; }

        /// <summary>
        /// Weather
        /// </summary>
        public IList<WeatherPartViewModel> Weather { get; set; }

        /// <summary>
        /// Clouds
        /// </summary>
        public CloudsViewModel Clouds { get; set; }

        /// <summary>
        /// Wind
        /// </summary>
        public WindViewModel Wind { get; set; }

        /// <summary>
        /// Rain
        /// </summary>
        public RainViewModel Rain { get; set; }

        /// <summary>
        /// DateTimeTxt
        /// </summary>
        public string DateTimeTxt { get; set; }

        /// <summary>
        /// WeatherCondition
        /// </summary>
        public WeatherConditionViewModelEnum WeatherCondition { get; set; }
    }
}
