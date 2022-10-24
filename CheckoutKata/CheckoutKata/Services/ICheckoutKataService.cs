using CheckoutKata.Models;

namespace CheckoutKata.Services
{
    public interface ICheckoutKataService
    {
        void Scan(string item);
        int GetTotalPrice(Dictionary<string, int> itemPricesDict, Dictionary<string, SpecialPrice> specialPriceDict);
    }
}
