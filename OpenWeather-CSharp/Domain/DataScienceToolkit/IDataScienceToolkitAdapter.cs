using Domain.DataScienceToolkit.Model;

namespace Domain.DataScienceToolkit
{
    public interface IDataScienceToolkitAdapter
    {
        City LoadCityData(string cityName);
    }
}
