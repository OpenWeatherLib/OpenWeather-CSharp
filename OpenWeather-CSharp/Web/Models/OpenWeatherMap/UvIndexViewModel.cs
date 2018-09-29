using System;
using Web.Models.DataScienceToolkit;

namespace Web.Models.OpenWeatherMap
{
    public class UvIndexViewModel
    {
        public CoordinatesViewModel Coordinates { get; set; }

        public string DateTimeIso { get; set; }

        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
