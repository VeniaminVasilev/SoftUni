namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Queue<int> prices = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            int eatenFood = 0;

            while (true)
            {
                if (money.Count == 0 || prices.Count == 0) break;

                int currentMoney = money.Peek();
                int currentPrice = prices.Peek();

                if (currentMoney == currentPrice)
                {
                    eatenFood++;
                    money.Pop();
                    prices.Dequeue();
                }
                else if (currentMoney > currentPrice)
                {
                    eatenFood++;
                    int difference = currentMoney - currentPrice;

                    money.Pop();

                    if (money.Count > 0)
                    {
                        int newMoney = money.Peek() + difference;
                        money.Pop();
                        money.Push(newMoney);
                    }
                    else
                    {
                        money.Push(difference);
                    }

                    prices.Dequeue();
                }
                else if (currentPrice > currentMoney)
                {
                    money.Pop();
                    prices.Dequeue();
                }
            }

            if (eatenFood >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatenFood} foods.");
            }
            else if (eatenFood > 1)
            {
                Console.WriteLine($"Henry ate: {eatenFood} foods.");
            }
            else if (eatenFood == 1)
            {
                Console.WriteLine($"Henry ate: {eatenFood} food.");
            }
            else if (eatenFood == 0)
            {
                Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}