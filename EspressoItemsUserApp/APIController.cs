using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Configuration;
using EspressoItemsUserApp.Models;


namespace EspressoItemsUserApp
{
    internal class APIController
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string APIURL =ConfigurationManager.AppSettings.Get("APIBaseURL");

        public async Task<List<EspressoItem>> GetItemsAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ApiUrl = APIURL + "EspressoItems";
            var streamTask = await client.GetStreamAsync(new Uri(ApiUrl));
            
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var categorieList = await JsonSerializer.DeserializeAsync<List<EspressoItem>>(streamTask, options);
            return categorieList;

        }

    }
}

