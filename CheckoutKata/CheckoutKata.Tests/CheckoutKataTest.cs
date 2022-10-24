using CheckoutKata.Services;

namespace CheckoutKata.Tests
{
    public class CheckoutKataTest
    {
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScanItem_ShouldReturnTotalPrice(string item, int expectedPrice)
        {
            //Arrange
            var checkoutKata = new CheckoutKataService();

            //Act
            //checkoutKata.Scan(item);

            //Assert
            Assert.That(checkoutKata.GetTotalPrice(null, null), Is.EqualTo(expectedPrice));
        }


        [TestCase("AB", 80)]
        [TestCase("CCC", 60)]
        [TestCase("DDD", 45)]
        [TestCase("CBDA", 115)]
        [TestCase("ABCD", 115)]
        [TestCase("DCBA", 115)]
        public void ScanMultipleItems_ShouldReturnExpectedTotalPrice(string itemList, int expectedPrice)
        {
            //Arrange
            var checkout = new Checkout();

            //Act
            foreach (var item in itemList)
            {
                checkout.Scan(item.ToString());
            }

            //Assert
            Assert.That(checkout.GetTotalPrice(null, null), Is.EqualTo(expectedPrice));
        }

        [TestCase("AAA", 130)]
        [TestCase("BB", 45)]
        [TestCase("AAAAAA", 260)]
        [TestCase("AAAA", 180)]
        [TestCase("BBB", 75)]
        [TestCase("BAB", 95)]
        [TestCase("ABCABACCDAB", 330)] 
        public void ScanMultipleItems_WhenItemHasSpecialPrice_ThenReturnSpecialPrice(string itemList, int expectedPrice)
        {
            //Arrange
            var checkoutKata = new CheckoutKataService();

            //Act
            foreach (var item in itemList)
            {
                checkoutKata.Scan(item.ToString());
            }

            //Assert
            Assert.That(checkoutKata.GetTotalPrice(null, null), Is.EqualTo(expectedPrice));
        }
    }
}