namespace Services.DataScienceToolkit.Dto
{
    public class CityDto
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public uint Population { get; set; }

        public CoordinatesDto Coordinates { get; set; }
    }
}
