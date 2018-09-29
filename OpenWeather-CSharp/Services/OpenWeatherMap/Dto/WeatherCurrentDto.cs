using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Enum;
using System;
using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto
{
    public class WeatherCurrentDto
    {
        public CoordinatesDto Coordinates { get; set; }

        public IList<WeatherPartDto> Weather { get; set; }

        public string Base { get; set; }

        public MainDto Main { get; set; }

        public uint Visibility { get; set; }

        public WindDto Wind { get; set; }

        public CloudsDto Clouds { get; set; }

        public DateTime Datetime { get; set; }

        public SysDto Sys { get; set; }

        public uint Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }

        public WeatherConditionDtoEnum WeatherCondition { get; set; }
    }
}
