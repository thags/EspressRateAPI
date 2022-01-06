using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public List<EspressoItem> GetItems()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ApiUrl = APIURL + "EspressoItems";
            var streamTask = client.GetStreamAsync(new Uri(ApiUrl)).Result;
            
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            List<EspressoItem> categorieList = JsonSerializer.DeserializeAsync<List<EspressoItem>>(streamTask, options).Result;
            return categorieList;
        }
        public void AddItem(EspressoItem item)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ApiUrl = APIURL + "EspressoItems";
            client.PostAsJsonAsync(new Uri(ApiUrl), item);
        }
        public void DeleteItem(int Id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ApiUrl = $"{APIURL}EspressoItems/{Id}";
            client.DeleteAsync(new Uri(ApiUrl));
        }
        public void UpdateItem(int Id, EspressoItem espressoUpdate)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string ApiUrl = $"{APIURL}EspressoItems/{Id}";
            client.PutAsJsonAsync(new Uri(ApiUrl), espressoUpdate);
        }
    }
}

