using Crosscutting.Attributes;

namespace Domain.DataScienceToolkit.Model
{
    public class City
    {
        public uint Id { get; set; }

        [Required(typeof(string))]
        public string Name { get; set; }

        public string Country { get; set; }

        public uint Population { get; set; }

        [Required(typeof(object))]
        public Coordinates Coordinates { get; set; }
    }
}
