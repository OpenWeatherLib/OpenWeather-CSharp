using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap.Enum
{
    /// <summary>
    /// WeatherConditionViewModelEnum
    /// </summary>
    public class WeatherConditionViewModelEnum
    {
        /// <summary>
        /// Null
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Null = new WeatherConditionViewModelEnum(0, "Null");

        /// <summary>
        /// Clear
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Clear = new WeatherConditionViewModelEnum(1, "Clear");

        /// <summary>
        /// Cloud
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Cloud = new WeatherConditionViewModelEnum(2, "Cloud");

        /// <summary>
        /// Drizzle
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Drizzle = new WeatherConditionViewModelEnum(3, "Drizzle");

        /// <summary>
        /// Fog
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Fog = new WeatherConditionViewModelEnum(4, "Fog");

        /// <summary>
        /// Haze
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Haze = new WeatherConditionViewModelEnum(5, "Haze");

        /// <summary>
        /// Mist
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Mist = new WeatherConditionViewModelEnum(6, "Mist");

        /// <summary>
        /// Rain
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Rain = new WeatherConditionViewModelEnum(7, "Rain");

        /// <summary>
        /// Sleet
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Sleet = new WeatherConditionViewModelEnum(8, "Sleet");

        /// <summary>
        /// Snow
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Snow = new WeatherConditionViewModelEnum(9, "Snow");

        /// <summary>
        /// Squalls
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Squalls = new WeatherConditionViewModelEnum(10, "Squalls");

        /// <summary>
        /// Sun
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Sun = new WeatherConditionViewModelEnum(11, "Sun");

        /// <summary>
        /// Thunderstorm
        /// </summary>
        public static readonly WeatherConditionViewModelEnum Thunderstorm = new WeatherConditionViewModelEnum(12, "Thunderstorm");

        /// <summary>
        /// Values
        /// </summary>
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

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WeatherConditionViewModelEnum</returns>
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

        /// <summary>
        /// Get by description
        /// </summary>
        /// <param name="description"></param>
        /// <returns>WeatherConditionViewModelEnum</returns>
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
    }
}
