using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class UvIndex
    {
        public Coordinates Coordinates { get; set; }

        public string DateTimeIso { get; set; }

        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
