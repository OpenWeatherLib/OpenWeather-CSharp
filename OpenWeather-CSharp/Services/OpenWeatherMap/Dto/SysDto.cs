﻿using System;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class SysDto
    {
        public uint Id { get; set; }

        public int Type { get; set; }

        public double Message { get; set; }

        public string Country { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }
    }
}
