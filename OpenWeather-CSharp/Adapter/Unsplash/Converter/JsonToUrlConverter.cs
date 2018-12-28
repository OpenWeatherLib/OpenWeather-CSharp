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
                var jsonObject = JObject.Parse(response);
                var resultJObject = jsonObject["results"][0];
                var urlsJObject = resultJObject["urls"];

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
