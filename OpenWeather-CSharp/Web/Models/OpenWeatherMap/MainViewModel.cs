namespace Web.Models.OpenWeatherMap
{
    public class MainViewModel
    {
        public double Temperature { get; set; }

        public double TemperatureMin { get; set; }

        public double TemperatureMax { get; set; }

        public double TemperatureKf { get; set; }

        public double Pressure { get; set; }

        public double PressureSeaLevel { get; set; }

        public double PressureGroundLevel { get; set; }

        public double Humidity { get; set; }
    }
}
