using System;
namespace Tests
{
    public class HarryPotterBookstoreTests
    {
        private static IEnumerable<TestCaseData> TestDataWithoutDiscounts()
        {
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 } }, 8.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 5, 1 } }, 8.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 3, 2 } }, 16.0);
            yield return new TestCaseData(new Dictionary<int, int> { { 5, 5 } }, 40.0);
        }

        private static IEnumerable<TestCaseData> TestDataWith5percentDiscount()
        {
             yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 } }, 15.20);
             yield return new TestCaseData(new Dictionary<int, int> { {1,1 },{ 5, 5 } },47.2);
            // Cases with 3 different items
            yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 } }, 21.60);
// Cases with 3 items (Not all are different)
yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 } }, 21.60);
yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } }, 25.60);
yield return new TestCaseData(new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 } }, 30.00);
yield return new TestCaseData(new Dictionary<int, int> { { 1, 3 } }, 24.0);
yield return new TestCaseData(new Dictionary<int, int> { { 1, 2 }, { 2, 2 }, { 3, 2 }, { 4, 1 }, { 5, 1 } }, 51.60);
        }

    

        [TestCaseSource(nameof(TestDataWithoutDiscounts))]
        public void CalculateTotalPrice_MultipleScenarios(Dictionary<int, int> basket, double expectedTotalPrice)
        {
            double totalPrice = HarryPotterBookstore.CalculateTotalPrice(basket);
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }


    }
}

