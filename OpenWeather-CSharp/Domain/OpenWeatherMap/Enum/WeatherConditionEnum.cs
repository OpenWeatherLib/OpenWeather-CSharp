using System.Collections.Generic;

namespace Domain.OpenWeatherMap.Enum
{
    public class WeatherConditionEnum
    {
        public static readonly WeatherConditionEnum Null = new WeatherConditionEnum(0, "Null");

        public static readonly WeatherConditionEnum Clear = new WeatherConditionEnum(1, "Clear");

        public static readonly WeatherConditionEnum Cloud = new WeatherConditionEnum(2, "Cloud");

        public static readonly WeatherConditionEnum Drizzle = new WeatherConditionEnum(3, "Drizzle");

        public static readonly WeatherConditionEnum Fog = new WeatherConditionEnum(4, "Fog");

        public static readonly WeatherConditionEnum Haze = new WeatherConditionEnum(5, "Haze");

        public static readonly WeatherConditionEnum Mist = new WeatherConditionEnum(6, "Mist");

        public static readonly WeatherConditionEnum Rain = new WeatherConditionEnum(7, "Rain");

        public static readonly WeatherConditionEnum Sleet = new WeatherConditionEnum(8, "Sleet");

        public static readonly WeatherConditionEnum Snow = new WeatherConditionEnum(9, "Snow");

        public static readonly WeatherConditionEnum Squalls = new WeatherConditionEnum(10, "Squalls");

        public static readonly WeatherConditionEnum Sun = new WeatherConditionEnum(11, "Sun");

        public static readonly WeatherConditionEnum Thunderstorm = new WeatherConditionEnum(12, "Thunderstorm");

        public static IEnumerable<WeatherConditionEnum> Values
        {
            get
            {
                yield return Null;
                yield return Clear;
                yield return Cloud;
                yield return Drizzle;
                yield return Fog;
                yield return Haze;
                yield return Mist;
                yield return Rain;
                yield return Sleet;
                yield return Snow;
                yield return Squalls;
                yield return Sun;
                yield return Thunderstorm;
            }
        }

        WeatherConditionEnum(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }

        public string Description { get; }

        public static WeatherConditionEnum GetById(int id)
        {
            foreach (WeatherConditionEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

        public static WeatherConditionEnum GetByDescription(string description)
        {
            foreach (WeatherConditionEnum entry in Values)
            {
                if (entry.Description.ToLower().Equals(description.ToLower())
                    || entry.Description.ToLower().Contains(description.ToLower())
                    || description.ToLower().Equals(entry.Description.ToLower())
                    || description.ToLower().Contains(entry.Description.ToLower())
                    || entry.Description.ToUpper().Equals(description.ToUpper())
                    || entry.Description.ToUpper().Contains(description.ToUpper())
                    || description.ToUpper().Equals(entry.Description.ToUpper())
                    || description.ToUpper().Contains(entry.Description.ToUpper()))
                {
                    return entry;
                }
            }

            return Null;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
