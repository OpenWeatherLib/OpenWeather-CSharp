using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// NitrogenDioxideViewModel
    /// </summary>
    public class NitrogenDioxideViewModel
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
        public IList<NitrogenDioxideDataViewModel> Data { get; set; }
    }
}
