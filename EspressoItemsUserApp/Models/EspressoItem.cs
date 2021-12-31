using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EspressoItemsUserApp.Models
{
    internal class EspressoItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("rating")]
        public int Rating { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("roaster")]
        public string Roaster { get; set; }
    }
}
