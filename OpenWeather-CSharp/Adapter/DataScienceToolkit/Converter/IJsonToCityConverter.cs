using Domain.DataScienceToolkit.Model;

namespace Adapter.DataScienceToolkit.Converter
{
    public interface IJsonToCityConverter
    {
        City Convert(string response);
    }
}
