namespace Web.Models.DataScienceToolkit
{
    public class CityViewModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public uint Population { get; set; }

        public CoordinatesViewModel Coordinates { get; set; }
    }
}
