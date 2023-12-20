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

        private static IEnumerable<TestCaseData> TestDataWith5percentDiscount()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 } }, 15.20);
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 5, 5 } }, 47.2);
        }

        [TestCaseSource(nameof(TestDataWith5percentDiscount))]
        public void CalculateTotalPrice_with5percentDiscount(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstoreTDD.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        private static IEnumerable<TestCaseData> TestDataWith10percentDiscount()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 } }, 21.60);
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 1 } }, 29.60);
        }

        [TestCaseSource(nameof(TestDataWith10percentDiscount))]
        public void CalculateTotalPrice_with10percentDiscount(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstoreTDD.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        private static IEnumerable<TestCaseData> TestDataWith20percentDiscount()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } }, 25.60);
        }

        [TestCaseSource(nameof(TestDataWith20percentDiscount))]
        public void CalculateTotalPrice_with20percentDiscount(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstoreTDD.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        private static IEnumerable<TestCaseData> TestDataWith25percentDiscount()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 } }, 30.00);
        }

        [TestCaseSource(nameof(TestDataWith25percentDiscount))]
        public void CalculateTotalPrice_with25percentDiscount(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstoreTDD.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }
    }
}

