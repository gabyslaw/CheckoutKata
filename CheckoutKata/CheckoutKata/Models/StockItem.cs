namespace CheckoutKata.Models
{
    public class StockItem
    {
        public Dictionary<string, int> newItemPrices { get; set; }
        public Dictionary<string, SpecialPrice> newSpecialPrice { get; set; }

    }
}
