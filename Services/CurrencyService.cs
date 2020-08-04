using E_Commerce.InputModels;
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
            RestClient client = new RestClient($" https://api.exchangeratesapi.io/latest?base=BGN&symbols={currency}");
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Rates content = JsonConvert.DeserializeObject<Rates>(response.Content);

                return content.Currency[currency];
            }

            return 0;
        }
       
    }
}
