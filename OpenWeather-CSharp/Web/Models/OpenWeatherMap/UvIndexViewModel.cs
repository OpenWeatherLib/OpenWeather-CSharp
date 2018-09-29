using System;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// UvIndexViewModel
    /// </summary>
    public class UvIndexViewModel
    {
        /// <summary>
        /// Coordinates
        /// </summary>
        public CoordinatesViewModel Coordinates { get; set; }

        /// <summary>
        /// DateTimeIso
        /// </summary>
        public string DateTimeIso { get; set; }

        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; set; }
    }
}
