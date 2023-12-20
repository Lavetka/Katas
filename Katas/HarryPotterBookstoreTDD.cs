namespace Katas
{
    public class HarryPotterBookstoreTDD
    {
        private static readonly double BookPrice = 8.0;

        public static double CalculateTotalPrice(Dictionary<int, int> basket)
        {
            if (basket == null)
            {
                throw new ArgumentException("Basket cannot be null");
            }

            double totalPrice = 0;

            while (basket.Values.Sum() > 0)
            {
                int distinctBooksCount = basket.Count(kv => kv.Value > 0);
                double discount = GetDiscount(distinctBooksCount);

                for (int i = 1; i <= 5; i++)
                {
                    if (basket.ContainsKey(i) && basket[i] > 0)
                    {
                        totalPrice += (1 - discount) * BookPrice;
                        basket[i]--;
                    }
                }
            }
            return totalPrice;
        }

        private static double GetDiscount(int distinctBooksCount)
        {
            switch (distinctBooksCount)
            {
                case 2:
                    return 0.05;
                case 3:
                    return 0.1;
                case 4:
                    return 0.2;
                default:
                    return 0.0;
            }
        }
    }
}

