using System.Collections.Generic;

namespace GuepardoApps.OpenWeatherLib.Web.Models.Unsplash.Enum
{
    /// <summary>
    /// UnsplashImageOrientationViewModelEnum
    /// </summary>
    public class UnsplashImageOrientationViewModelEnum
    {
        /// <summary>
        /// Null
        /// </summary>
        public static readonly UnsplashImageOrientationViewModelEnum Default = new UnsplashImageOrientationViewModelEnum(0, "landscape");

        /// <summary>
        /// Landscape
        /// </summary>
        public static readonly UnsplashImageOrientationViewModelEnum Landscape = new UnsplashImageOrientationViewModelEnum(1, "landscape");

        /// <summary>
        /// Portrait
        /// </summary>
        public static readonly UnsplashImageOrientationViewModelEnum Portrait = new UnsplashImageOrientationViewModelEnum(2, "portrait");

        /// <summary>
        /// Squarish
        /// </summary>
        public static readonly UnsplashImageOrientationViewModelEnum Squarish = new UnsplashImageOrientationViewModelEnum(3, "squarish");

        /// <summary>
        /// Values
        /// </summary>
        public static IEnumerable<UnsplashImageOrientationViewModelEnum> Values
        {
            get
            {
                yield return Default;
                yield return Landscape;
                yield return Portrait;
                yield return Squarish;
            }
        }

        UnsplashImageOrientationViewModelEnum(int id, string description)
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
        /// <returns>UnsplashImageOrientationViewModelEnum</returns>
        public static UnsplashImageOrientationViewModelEnum GetById(int id)
        {
            foreach (UnsplashImageOrientationViewModelEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Default;
        }

        /// <summary>
        /// Get by description
        /// </summary>
        /// <param name="description"></param>
        /// <returns>UnsplashImageOrientationViewModelEnum</returns>
        public static UnsplashImageOrientationViewModelEnum GetByDescription(string description)
        {
            foreach (UnsplashImageOrientationViewModelEnum entry in Values)
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

            return Default;
        }
    }
}
