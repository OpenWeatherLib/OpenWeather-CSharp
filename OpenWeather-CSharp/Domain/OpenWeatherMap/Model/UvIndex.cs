using Domain.DataScienceToolkit.Model;
using System;

namespace Domain.OpenWeatherMap.Model
{
    public class UvIndex
    {
        public Coordinates Coordinates { get; set; }

        public string DateTimeIso { get; set; }

        public DateTime DateTime { get; set; }

        public int Value { get; set; }
    }
}
