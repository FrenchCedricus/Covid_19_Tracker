using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CovidApp_Console
{
    class API
    {
        private static HttpClient client = new HttpClient();
        private const string URL = "https://coronavirusapifr.herokuapp.com/data/live/france";


        public async Task<string> GetCovidData()
        {

            string data = string.Empty;
            var response = await client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }



    }
}
