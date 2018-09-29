using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using System;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class UvIndexDto
    {
        public CoordinatesDto Coordinates { get; set; }

        public string DateTimeIso { get; set; }

        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
