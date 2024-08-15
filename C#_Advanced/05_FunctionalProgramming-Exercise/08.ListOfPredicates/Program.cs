namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Predicate<int> devisibleNumber = number => dividers.All(divider => number % divider == 0);

            for (int number = 1; number <= n; number++)
            {
                if (devisibleNumber(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}