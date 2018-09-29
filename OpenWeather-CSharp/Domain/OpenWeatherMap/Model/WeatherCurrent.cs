using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap.Enum;
using System;
using System.Collections.Generic;

namespace Domain.OpenWeatherMap.Model
{
    public class WeatherCurrent
    {
        public Coordinates Coordinates { get; set; }

        public IList<WeatherPart> Weather { get; set; }

        public string Base { get; set; }

        public Main Main { get; set; }

        public uint Visibility { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public DateTime Datetime { get; set; }

        public Sys Sys { get; set; }

        public uint Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }

        public WeatherConditionEnum WeatherCondition { get; set; }
    }
}
