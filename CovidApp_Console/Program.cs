using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            API api = new API();

            string json = api.GetCovidData().GetAwaiter().GetResult();
            var listDataCovid = JsonConvert.DeserializeObject<List<Covid_Modele>>(json);
            //
            foreach( var model in listDataCovid )
            {
                Console.WriteLine("Date : {0} - Hospitalisation : {1}", model.Date, model.Hosp);
            }
            //
            Console.WriteLine("Pressez RETURN pour fermer;");
            Console.ReadLine();

        }
    }
}
