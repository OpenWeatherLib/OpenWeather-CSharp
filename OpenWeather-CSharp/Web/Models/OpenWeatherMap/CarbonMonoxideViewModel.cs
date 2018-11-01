using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// CarbonMonoxideViewModel
    /// </summary>
    public class CarbonMonoxideViewModel
    {
        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Coordinates
        /// </summary>
        public CoordinatesViewModel Coordinates { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public IList<CarbonMonoxideDataViewModel> Data { get; set; }
    }
}
