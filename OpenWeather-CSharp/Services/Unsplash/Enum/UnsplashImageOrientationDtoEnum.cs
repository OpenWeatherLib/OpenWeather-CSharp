using System.Collections.Generic;

namespace Services.Unsplash.Enum
{
    public class UnsplashImageOrientationDtoEnum
    {
        public static readonly UnsplashImageOrientationDtoEnum Null = new UnsplashImageOrientationDtoEnum(0, "Null");

        public static readonly UnsplashImageOrientationDtoEnum Landscape = new UnsplashImageOrientationDtoEnum(1, "landscape");

        public static readonly UnsplashImageOrientationDtoEnum Portrait = new UnsplashImageOrientationDtoEnum(2, "portrait");

        public static readonly UnsplashImageOrientationDtoEnum Squarish = new UnsplashImageOrientationDtoEnum(3, "squarish");

        public static IEnumerable<UnsplashImageOrientationDtoEnum> Values
        {
            get
            {
                yield return Null;
                yield return Landscape;
                yield return Portrait;
                yield return Squarish;
            }
        }

        UnsplashImageOrientationDtoEnum(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }

        public string Description { get; }

        public static UnsplashImageOrientationDtoEnum GetById(int id)
        {
            foreach (UnsplashImageOrientationDtoEnum entry in Values)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return Null;
        }

        public static UnsplashImageOrientationDtoEnum GetByDescription(string description)
        {
            foreach (UnsplashImageOrientationDtoEnum entry in Values)
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
