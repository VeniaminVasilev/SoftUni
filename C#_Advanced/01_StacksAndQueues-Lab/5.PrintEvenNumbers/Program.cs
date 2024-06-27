namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Queue<int> queueWithAllNumbers = new Queue<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                queueWithAllNumbers.Enqueue(numbers[i]);
            }

            int counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = queueWithAllNumbers.Dequeue();

                if (number % 2 == 0 && counter == 0)
                {
                    Console.Write($"{number}");
                    counter++;
                }
                else if (number % 2 == 0 && counter != 0)
                {
                    Console.Write($", {number}");
                }
            }
        }
    }
}