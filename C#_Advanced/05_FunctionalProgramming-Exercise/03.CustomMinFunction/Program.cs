namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> findAndPrintTheSmallestNumber = numbers =>
            {
                int smallestNumber = numbers.Min();

                Console.WriteLine(smallestNumber);

                return smallestNumber;
            };

            int smallestNumber = findAndPrintTheSmallestNumber(numbers);
        }
    }
}