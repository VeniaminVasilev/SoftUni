namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            int[] sortedCoins = coins.OrderByDescending(coin => coin).ToArray();

            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();

            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Length)
            {
                int currentCoinValue = sortedCoins[coinIndex];

                int remainder = targetSum - currentSum;

                int numberOfCoins = remainder / currentCoinValue;

                if (currentSum + currentCoinValue <= targetSum)
                {
                    chosenCoins[currentCoinValue] = numberOfCoins;
                    currentSum += currentCoinValue * numberOfCoins;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }

            return chosenCoins;
        }
    }
}