namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            List<int> orders = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Queue<int> ordersQueue = new Queue<int>();

            for (int i = 0; i < orders.Count; i++)
            {
                ordersQueue.Enqueue(orders[i]);
            }

            int biggestOrder = ordersQueue.Max();
            Console.WriteLine(biggestOrder);

            for (int i = 0; i < orders.Count; i++)
            {
                int currentOrder = orders[i];

                if (foodQuantity >= currentOrder)
                {
                    foodQuantity -= currentOrder;
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}