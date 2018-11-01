using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model
{
    public class SulfurDioxide
    {
        public DateTime DateTime { get; set; }

        public Coordinates Coordinates { get; set; }

        public IList<SulfurDioxideData> Data { get; set; }
    }
}
