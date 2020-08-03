using System.Threading.Tasks;

namespace E_Commerce.Services.Contracts
{
    public interface ICurrencyService
    {
        decimal GetCurrency(string currency);
    }
}