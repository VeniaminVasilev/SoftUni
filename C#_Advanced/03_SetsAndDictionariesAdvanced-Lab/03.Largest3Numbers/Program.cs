namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] sortedNumbers = numbers.OrderByDescending(n => n).ToArray();

            if (sortedNumbers.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sortedNumbers[i]} ");
                }
            }
            else
            {
                for (int i = 0; i < sortedNumbers.Length; i++)
                {
                    Console.Write($"{sortedNumbers[i]} ");
                }
            }
        }
    }
}