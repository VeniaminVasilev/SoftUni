namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int elementsToPush = list[0];
            int elementsToPop = list[1];
            int elementToBeFound = list[2];

            Stack<int> stack = new Stack<int>();

            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToBeFound))
            {
                Console.WriteLine($"true");
            }
            else if (!stack.Contains(elementToBeFound) && stack.Count != 0)
            {
                int min = stack.Min();
                Console.WriteLine(min);
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}