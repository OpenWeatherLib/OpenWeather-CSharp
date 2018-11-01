using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// SulfurDioxideViewModel
    /// </summary>
    public class SulfurDioxideViewModel
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
        public IList<SulfurDioxideDataViewModel> Data { get; set; }
    }
}
