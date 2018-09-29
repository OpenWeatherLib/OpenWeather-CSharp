using System.Collections.Generic;

namespace Web.Models.OpenWeatherMap.Enum
{
    public class WeatherConditionViewModelEnum
    {
        public static readonly WeatherConditionViewModelEnum Null = new WeatherConditionViewModelEnum(0, "Null");

        public static readonly WeatherConditionViewModelEnum Clear = new WeatherConditionViewModelEnum(1, "Clear");

        public static readonly WeatherConditionViewModelEnum Cloud = new WeatherConditionViewModelEnum(2, "Cloud");

        public static readonly WeatherConditionViewModelEnum Drizzle = new WeatherConditionViewModelEnum(3, "Drizzle");

        public static readonly WeatherConditionViewModelEnum Fog = new WeatherConditionViewModelEnum(4, "Fog");

        public static readonly WeatherConditionViewModelEnum Haze = new WeatherConditionViewModelEnum(5, "Haze");

        public static readonly WeatherConditionViewModelEnum Mist = new WeatherConditionViewModelEnum(6, "Mist");

        public static readonly WeatherConditionViewModelEnum Rain = new WeatherConditionViewModelEnum(7, "Rain");

        public static readonly WeatherConditionViewModelEnum Sleet = new WeatherConditionViewModelEnum(8, "Sleet");

        public static readonly WeatherConditionViewModelEnum Snow = new WeatherConditionViewModelEnum(9, "Snow");

        public static readonly WeatherConditionViewModelEnum Squalls = new WeatherConditionViewModelEnum(10, "Squalls");

        public static readonly WeatherConditionViewModelEnum Sun = new WeatherConditionViewModelEnum(11, "Sun");

        public static readonly WeatherConditionViewModelEnum Thunderstorm = new WeatherConditionViewModelEnum(12, "Thunderstorm");

        public static IEnumerable<WeatherConditionViewModelEnum> Values
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

        WeatherConditionViewModelEnum(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }

        public string Description { get; }

        public static WeatherConditionViewModelEnum GetById(int id)
        {
            foreach (WeatherConditionViewModelEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

        public static WeatherConditionViewModelEnum GetByDescription(string description)
        {
            foreach (WeatherConditionViewModelEnum entry in Values)
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
