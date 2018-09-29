namespace Domain.OpenWeatherMap.Model
{
    public class WeatherPart
    {
        public uint Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}
