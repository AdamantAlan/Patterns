using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adapter
{
    interface IWind
    {
        Task<string> GetWindAsync();
    }
    class Wind : IWind
    {
        public async Task<string> GetHtmlWindAsync()
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
        public async Task<string> GetWindAsync()
        {
            var html = await GetHtmlWindAsync();
            html = Regex.Replace(html, "[ \n\r]", "");
            var i = Regex.Match(html, "км/ч");
            return html.Substring(i.Index - 4, 4);
        }
    }
}
