using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class CarbonMonoxide
    {
        public DateTime DateTime { get; set; }

        public Coordinates Coordinates { get; set; }

        public IList<CarbonMonoxideData> Data { get; set; }
    }
}
