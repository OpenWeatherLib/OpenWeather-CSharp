using System.IO;
using System.Net;

namespace GuepardoApps.OpenWeatherLib.Adapter
{
    public class BaseAdapter
    {
        protected string GetRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var stringResponse = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);

                stringResponse = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
            }
            return stringResponse;
        }

        protected string CleanResponse(string response)
        {
            return response.Replace("\n", string.Empty);
        }
    }
}
