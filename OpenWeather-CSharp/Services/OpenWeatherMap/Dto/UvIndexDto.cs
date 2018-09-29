using Services.DataScienceToolkit.Dto;
using System;

namespace Services.OpenWeatherMap.Dto
{
    public class UvIndexDto
    {
        public CoordinatesDto Coordinates { get; set; }

        public string DateTimeIso { get; set; }

        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
