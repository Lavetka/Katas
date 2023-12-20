using System;
namespace Katas
{
    public class HarryPotterBookstoreTDD
    {
        private static readonly double BookPrice = 8.0;

        public static double CalculateTotalPrice(Dictionary<int, int> basket)
        {
            double totalPrice = 0;

            while (basket.Values.Sum() > 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (basket.ContainsKey(i) && basket[i] > 0)
                    {
                        totalPrice +=  BookPrice;
                        basket[i]--;
                    }
                }
            }
            return totalPrice;
        }
    }
}

