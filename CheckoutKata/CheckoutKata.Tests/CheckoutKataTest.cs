using CheckoutKata.Models;
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
            var checkOutKata = new CheckoutKataService();

            //Act
            foreach (var item in itemList)
            {
                checkOutKata.Scan(item.ToString());
            }

            //Assert
            Assert.That(checkOutKata.GetTotalPrice(null, null), Is.EqualTo(expectedPrice));
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

        [TestCase("AABBB", 145)]
        public void CalculateTotalPriceUsingNewPricingRules(string itemList, int expectedPrice)
        {
            //Arrange
            var checkOutKata = new CheckoutKataService();
            var newPricing = new Dictionary<string, int>
            {
                { "A", 60 },
                { "B", 20 },
            };

            var newSpecialPricing = new Dictionary<string, SpecialPrice>
            {
                {"A", new SpecialPrice { MinItemsToDiscount = 2, ReducedPrice = 100 } },
                {"B", new SpecialPrice { MinItemsToDiscount = 3, ReducedPrice = 45 } },
            };

            //Act
            foreach (var item in itemList)
            {
                checkOutKata.Scan(item.ToString());
            }

            //Assert
            Assert.That(checkOutKata.GetTotalPrice(newPricing, newSpecialPricing), Is.EqualTo(expectedPrice));
        }
    }
}