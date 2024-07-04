namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> bottles = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Queue<int> queueCups = new Queue<int>();
            for (int i = 0; i < cups.Count; i++)
            {
                queueCups.Enqueue(cups[i]);
            }

            Stack<int> stackBottles = new Stack<int>();
            for (int i = 0; i < bottles.Count; i++)
            {
                stackBottles.Push(bottles[i]);
            }

            int totalWastedWater = 0;

            while (true)
            {
                if (queueCups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
                    Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
                    break;
                }
                else if (stackBottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
                    Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
                    break;
                }

                int currentBottle = stackBottles.Peek();
                int currentCup = queueCups.Peek();
                int currentWastedWater = 0;

                currentCup -= currentBottle;
                stackBottles.Pop();

                if (currentCup < 0)
                {
                    currentWastedWater += currentCup * -1;
                    totalWastedWater += currentWastedWater;
                    queueCups.Dequeue();
                    continue;
                }
                else if (currentCup == 0)
                {
                    queueCups.Dequeue();
                    continue;
                }

                while (true)
                {
                    int newBottle = stackBottles.Peek();
                    currentCup -= newBottle;
                    stackBottles.Pop();

                    if (currentCup < 0)
                    {
                        currentWastedWater += currentCup * -1;
                        totalWastedWater += currentWastedWater;
                        queueCups.Dequeue();
                        break;
                    }
                    else if (currentCup == 0)
                    {
                        queueCups.Dequeue();
                        break;
                    }
                }
            }
        }
    }
}