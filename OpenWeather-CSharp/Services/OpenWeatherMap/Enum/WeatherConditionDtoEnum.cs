using System.Collections.Generic;

namespace Services.OpenWeatherMap.Enum
{
    public class WeatherConditionDtoEnum
    {
        public static readonly WeatherConditionDtoEnum Null = new WeatherConditionDtoEnum(0, "Null");

        public static readonly WeatherConditionDtoEnum Clear = new WeatherConditionDtoEnum(1, "Clear");

        public static readonly WeatherConditionDtoEnum Cloud = new WeatherConditionDtoEnum(2, "Cloud");

        public static readonly WeatherConditionDtoEnum Drizzle = new WeatherConditionDtoEnum(3, "Drizzle");

        public static readonly WeatherConditionDtoEnum Fog = new WeatherConditionDtoEnum(4, "Fog");

        public static readonly WeatherConditionDtoEnum Haze = new WeatherConditionDtoEnum(5, "Haze");

        public static readonly WeatherConditionDtoEnum Mist = new WeatherConditionDtoEnum(6, "Mist");

        public static readonly WeatherConditionDtoEnum Rain = new WeatherConditionDtoEnum(7, "Rain");

        public static readonly WeatherConditionDtoEnum Sleet = new WeatherConditionDtoEnum(8, "Sleet");

        public static readonly WeatherConditionDtoEnum Snow = new WeatherConditionDtoEnum(9, "Snow");

        public static readonly WeatherConditionDtoEnum Squalls = new WeatherConditionDtoEnum(10, "Squalls");

        public static readonly WeatherConditionDtoEnum Sun = new WeatherConditionDtoEnum(11, "Sun");

        public static readonly WeatherConditionDtoEnum Thunderstorm = new WeatherConditionDtoEnum(12, "Thunderstorm");

        public static IEnumerable<WeatherConditionDtoEnum> Values
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

        WeatherConditionDtoEnum(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }

        public string Description { get; }

        public static WeatherConditionDtoEnum GetById(int id)
        {
            foreach (WeatherConditionDtoEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

        public static WeatherConditionDtoEnum GetByDescription(string description)
        {
            foreach (WeatherConditionDtoEnum entry in Values)
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
