namespace CheckoutKata.Services
{
    public interface ICheckoutKataService
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
