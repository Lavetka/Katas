using Katas;

namespace Tests
{
	public class HarryPotterBookstoreTDDTests
	{
        private static IEnumerable<TestCaseData> TestDataWithoutDiscounts()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 } }, 8.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 5, 1 } }, 8.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 3, 2 } }, 16.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 5, 5 } }, 40.0);
        }

        [TestCaseSource(nameof(TestDataWithoutDiscounts))]
        public void CalculateTotalPrice_withoutDiscount(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstoreTDD.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [Test]
        public void CalculateTotalPrice_WithNullInput()
        {
            Assert.Throws<ArgumentException>(() => HarryPotterBookstoreTDD.CalculateTotalPrice(null));
        }
    }
}

