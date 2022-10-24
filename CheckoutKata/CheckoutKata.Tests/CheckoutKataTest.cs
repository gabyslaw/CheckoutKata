using CheckoutKata.Services;

namespace CheckoutKata.Tests
{
    public class CheckoutKataTest
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 10)]
        public void ScanItem_ShouldReturnTotalPrice(string item, int expectedPrice)
        {
            //Arrange
            var checkoutKata = new CheckoutKataService();

            //Act
            checkoutKata.Scan(item);

            //Assert
            Assert.That(checkoutKata.GetTotalPrice(), Is.EqualTo(expectedPrice));
        }
    }
}