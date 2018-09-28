using System.Collections.Generic;

namespace Domain.Unsplash.Enum
{
    public class UnsplashImageOrientationEnum
    {
        public static readonly UnsplashImageOrientationEnum Null = new UnsplashImageOrientationEnum(0, "Null");

        public static readonly UnsplashImageOrientationEnum Landscape = new UnsplashImageOrientationEnum(1, "landscape");

        public static readonly UnsplashImageOrientationEnum Portrait = new UnsplashImageOrientationEnum(2, "portrait");

        public static readonly UnsplashImageOrientationEnum Squarish = new UnsplashImageOrientationEnum(3, "squarish");

        public static IEnumerable<UnsplashImageOrientationEnum> Values
        {
            get
            {
                yield return Null;
                yield return Landscape;
                yield return Portrait;
                yield return Squarish;
            }
        }

        UnsplashImageOrientationEnum(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }

        public string Description { get; }

        public static UnsplashImageOrientationEnum GetById(int id)
        {
            foreach (UnsplashImageOrientationEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

        public static UnsplashImageOrientationEnum GetByDescription(string description)
        {
            foreach (UnsplashImageOrientationEnum entry in Values)
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
