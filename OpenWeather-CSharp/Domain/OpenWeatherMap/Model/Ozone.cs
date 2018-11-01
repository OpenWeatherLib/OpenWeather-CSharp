using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class Ozone
    {
        public DateTime DateTime { get; set; }

        public Coordinates Coordinates { get; set; }

        public double Data { get; set; }
    }
}
