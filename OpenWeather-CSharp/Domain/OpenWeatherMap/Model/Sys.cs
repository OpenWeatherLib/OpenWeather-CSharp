using System;

namespace Domain.OpenWeatherMap.Model
{
    public class Sys
    {
        public uint Id { get; set; }

        public int Type { get; set; }

        public double Message { get; set; }

        public string Country { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }
    }
}
