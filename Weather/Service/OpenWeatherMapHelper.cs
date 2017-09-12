using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather.Service
{
    public interface IOpenWeatherMapHelper
    {
        WeatherModel GetResult(string keyword = "11776");
    }

    public class OpenWeatherMapHelper : IOpenWeatherMapHelper
    {
        public WeatherModel GetResult(string keyword = "11776")
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={keyword}&appid={Configuration.OpenWeatherMapId}&units=metric";

            var request = (HttpWebRequest)WebRequest.Create(url);

            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                var json = sr.ReadToEnd();

                var result = JsonConvert.DeserializeObject<WeatherModel>(json);

                return result;
            }
        }
    }
}
