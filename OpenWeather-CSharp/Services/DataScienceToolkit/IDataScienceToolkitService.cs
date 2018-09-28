using Services.DataScienceToolkit.Dto;

namespace Services.DataScienceToolkit
{
    public interface IDataScienceToolkitService
    {
        CityDto LoadCityData(string cityName);
    }
}
