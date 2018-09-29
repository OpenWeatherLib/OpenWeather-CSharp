namespace GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit
{
    /// <summary>
    /// CityViewModel
    /// </summary>
    public class CityViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Population
        /// </summary>
        public uint Population { get; set; }

        /// <summary>
        /// Coordinates
        /// </summary>
        public CoordinatesViewModel Coordinates { get; set; }
    }
}
