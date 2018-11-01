using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using System;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class OzoneDto
    {
        public DateTime DateTime { get; set; }

        public CoordinatesDto Coordinates { get; set; }

        public double Data { get; set; }
    }
}
