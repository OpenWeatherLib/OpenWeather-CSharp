using System;

namespace Web.Models.OpenWeatherMap
{
    public class SysViewModel
    {
        public uint Id { get; set; }

        public int Type { get; set; }

        public int Message { get; set; }

        public string Country { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }
    }
}
