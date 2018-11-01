using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using System;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// OzoneViewModel
    /// </summary>
    public class OzoneViewModel
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
        public double Data { get; set; }
    }
}
