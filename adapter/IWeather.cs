using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adapter
{
    interface IWeather
    {
        Task<string> GetWeatherAsync();
    }
    class Weather : IWeather
    {
        public async Task<string> GetHtmlWeatherAsync()
        {
            string html = null;
            using (HttpClient client = new())
            {
                var resp = await client.GetAsync(@"https://world-weather.ru/pogoda/russia/surgut_1/");
                if ((int)resp.StatusCode == 200)
                    html = await resp.Content.ReadAsStringAsync();
            }
            return html;
        }
        public async Task<string> GetWeatherAsync()
        {
            var html = await GetHtmlWeatherAsync();
            html = Regex.Replace(html, "[ \n\r]", "");
            var i = Regex.Match(html, "weather-now-number");
            return html.Substring(i.Index + 20, 3);
        }
    }
}
