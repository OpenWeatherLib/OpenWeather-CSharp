using Crosscutting.Attributes;

namespace Domain.DataScienceToolkit.Model
{
    public class Coordinates
    {
        [IsNotDefault(typeof(float), 720.0)]
        public float Lat { get; set; }

        [IsNotDefault(typeof(float), 720.0)]
        public float Lon { get; set; }
    }
}
