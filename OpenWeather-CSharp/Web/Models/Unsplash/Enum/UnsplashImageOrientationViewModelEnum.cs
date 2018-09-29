using System.Collections.Generic;

namespace Web.Models.Unsplash.Enum
{
    public class UnsplashImageOrientationViewModelEnum
    {
        public static readonly UnsplashImageOrientationViewModelEnum Null = new UnsplashImageOrientationViewModelEnum(0, "Null");

        public static readonly UnsplashImageOrientationViewModelEnum Landscape = new UnsplashImageOrientationViewModelEnum(1, "landscape");

        public static readonly UnsplashImageOrientationViewModelEnum Portrait = new UnsplashImageOrientationViewModelEnum(2, "portrait");

        public static readonly UnsplashImageOrientationViewModelEnum Squarish = new UnsplashImageOrientationViewModelEnum(3, "squarish");

        public static IEnumerable<UnsplashImageOrientationViewModelEnum> Values
        {
            get
            {
                yield return Null;
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

        public int Id { get; }

        public string Description { get; }

        public static UnsplashImageOrientationViewModelEnum GetById(int id)
        {
            foreach (UnsplashImageOrientationViewModelEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

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

            return Null;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
