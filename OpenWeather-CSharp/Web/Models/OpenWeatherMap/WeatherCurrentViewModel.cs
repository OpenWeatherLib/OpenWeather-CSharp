using System;
using System.Collections.Generic;
using Web.Models.DataScienceToolkit;
using Web.Models.OpenWeatherMap.Enum;

namespace Web.Models.OpenWeatherMap
{
    public class WeatherCurrentViewModel
    {
        public CoordinatesViewModel Coordinates { get; set; }

        public IList<WeatherPartViewModel> Weather { get; set; }

        public string Base { get; set; }

        public MainViewModel Main { get; set; }

        public uint Visibility { get; set; }

        public WindViewModel Wind { get; set; }

        public CloudsViewModel Clouds { get; set; }

        public DateTime Datetime { get; set; }

        public SysViewModel Sys { get; set; }

        public uint Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }

        public WeatherConditionViewModelEnum WeatherCondition { get; set; }
    }
}
