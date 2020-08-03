using Newtonsoft.Json;
using System.Collections.Generic;

namespace E_Commerce.InputModels
{
    public class Rates
    {
        [JsonProperty("Rates")]
        public Dictionary<string, decimal> Currency { get; set; }
    }
}
