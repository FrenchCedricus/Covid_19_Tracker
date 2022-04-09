using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_19_Tracker
{
    class API
    {
        private static HttpClient client = new HttpClient();
        private const string URL_GLOBALE = "https://coronavirusapifr.herokuapp.com/data/live/france";

        public async Task<string> GetCovidData(string departement)
        {
            string URL_DEPART = "https://coronavirusapifr.herokuapp.com/data/live/departement/" + departement;
            string data = string.Empty;

            if (departement == null)
            { 
                var response = await client.GetAsync(URL_GLOBALE);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }

            }else
            {
                var response = await client.GetAsync(URL_DEPART);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }
            }
            return data;
        }



    }
}
