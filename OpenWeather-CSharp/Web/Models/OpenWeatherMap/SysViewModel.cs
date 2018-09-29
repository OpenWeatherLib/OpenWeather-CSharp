using System;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// SysViewModel
    /// </summary>
    public class SysViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public double Message { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Sunrise
        /// </summary>
        public DateTime Sunrise { get; set; }

        /// <summary>
        /// Sunset
        /// </summary>
        public DateTime Sunset { get; set; }
    }
}
