using E_Commerce.Services.Contracts;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class CurrencyService : ICurrencyService
    {
        public decimal GetCurrency(string currency) 
        {
            var client = new RestClient($" https://api.exchangeratesapi.io/latest?base=BGN&symbols={currency}");
            var req = new RestRequest(Method.GET);
            IRestResponse res = client.Execute(req);

            if (res.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<Rates>(res.Content);

                return content.Currency[currency];
            }

            return 0;
        }

        public class Rates
        {
        [JsonProperty("Rates")]
            public Dictionary<string, decimal> Currency{ get; set; }
        }
    }
}
