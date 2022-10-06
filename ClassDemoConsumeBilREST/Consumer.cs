using BilModelLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoConsumeBilREST
{
    public class Consumer
    {
        private static string URL = "http://localhost:5191/api/Biler/";

        public async Task<List<Bil>> GetAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(URL);
                if (resp.IsSuccessStatusCode)
                {
                    List<Bil> cList = await resp.Content.ReadFromJsonAsync<List<Bil>>();
                    return cList;
                }
                return new List<Bil>(); // evt. en exception
            }
        }


        public async Task<Bil> PutAsync(string stelnummer, Bil ændretBil)
        {

            using (HttpClient client = new HttpClient())
            {
                JsonContent content = JsonContent.Create(ændretBil);

                HttpResponseMessage resp = await client.PutAsync(URL + stelnummer, content);
                if (resp.IsSuccessStatusCode)
                {
                    Bil rBil = await resp.Content.ReadFromJsonAsync<Bil>();
                    return rBil;
                }

                return new Bil();

            }
        }



    }
}
