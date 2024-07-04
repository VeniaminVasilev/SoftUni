namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> tokens = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int elementsToEnqueue = tokens[0];
            int elementsToDequeue = tokens[1];
            int elementToFind = tokens[2];

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToFind))
            {
                Console.WriteLine($"true");
            }
            else if (!queue.Contains(elementToFind) && queue.Count != 0)
            {
                Console.WriteLine(queue.Min());
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}