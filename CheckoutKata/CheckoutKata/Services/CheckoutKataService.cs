using CheckoutKata.Models;

namespace CheckoutKata.Services
{
    public class CheckoutKataService : ICheckoutKataService
    {

        private int _totalPrice = 0;
        private List<string> _scannedItems = new List<string>();
        private Dictionary<string, int> _itemsPriceDictionary = new Dictionary<string, int>
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };

        public int GetTotalPrice(Dictionary<string, int>? itemPricesDict, Dictionary<string, SpecialPrice>? specialPriceDict)
        {
            foreach (var item in _scannedItems)
            {
                //get the value with the key specified
                _itemsPriceDictionary.TryGetValue(item, out int itemPrice);
                _totalPrice += itemPrice;
            }
            return _totalPrice;
        }

        public void Scan(string item)
        {
            //add items to the dictionary
            _scannedItems.Add(item);
        }
    }
}
