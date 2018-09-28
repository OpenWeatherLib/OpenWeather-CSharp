namespace Services.OpenWeatherMap.Dto
{
    public class MainDto
    {
        public float Temperature { get; set; }

        public float TemperatureMin { get; set; }

        public float TemperatureMax { get; set; }

        public float TemperatureKf { get; set; }

        public float Pressure { get; set; }

        public float PressureSeaLevel { get; set; }

        public float PressureGroundLevel { get; set; }

        public float Humidity { get; set; }
    }
}
