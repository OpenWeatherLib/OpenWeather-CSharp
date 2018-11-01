using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class CarbonMonoxideDto
    {
        public DateTime DateTime { get; set; }

        public CoordinatesDto Coordinates { get; set; }

        public IList<CarbonMonoxideDataDto> Data { get; set; }
    }
}
