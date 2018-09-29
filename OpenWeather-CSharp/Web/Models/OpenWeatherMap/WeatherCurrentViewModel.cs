using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap.Enum;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// WeatherCurrentViewModel
    /// </summary>
    public class WeatherCurrentViewModel
    {
        /// <summary>
        /// Coordinates
        /// </summary>
        public CoordinatesViewModel Coordinates { get; set; }

        /// <summary>
        /// Weather
        /// </summary>
        public IList<WeatherPartViewModel> Weather { get; set; }

        /// <summary>
        /// Base
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// Main
        /// </summary>
        public MainViewModel Main { get; set; }

        /// <summary>
        /// Visibility
        /// </summary>
        public uint Visibility { get; set; }

        /// <summary>
        /// Wind
        /// </summary>
        public WindViewModel Wind { get; set; }

        /// <summary>
        /// Clouds
        /// </summary>
        public CloudsViewModel Clouds { get; set; }

        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime Datetime { get; set; }

        /// <summary>
        /// Sys
        /// </summary>
        public SysViewModel Sys { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cod
        /// </summary>
        public int Cod { get; set; }

        /// <summary>
        /// WeatherCondition
        /// </summary>
        public WeatherConditionViewModelEnum WeatherCondition { get; set; }
    }
}
