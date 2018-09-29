using Newtonsoft.Json.Linq;
using Serilog;
using System;

namespace GuepardoApps.OpenWeatherLib.Adapter.Unsplash.Converter
{
    public class JsonToUrlConverter : IJsonToUrlConverter
    {
        private readonly ILogger _logger;

        public JsonToUrlConverter(ILogger logger)
        {
            _logger = logger;
        }

        public string Convert(string response)
        {
            var url = string.Empty;

            try
            {
                JObject jsonObject = JObject.Parse(response);
                JToken resultJObject = jsonObject.GetValue("results")[0];
                JToken urlsJObject = resultJObject["urls"];
                url = urlsJObject["small"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return url;
        }
    }
}
