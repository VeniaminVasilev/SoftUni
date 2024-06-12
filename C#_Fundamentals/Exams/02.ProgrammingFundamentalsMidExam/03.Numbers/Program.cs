namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbersAboveAverageValue = new List<int>();
            double averageValue = numbers.Average();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageValue)
                {
                    numbersAboveAverageValue.Add(numbers[i]);
                }
            }

            numbersAboveAverageValue = numbersAboveAverageValue.OrderByDescending(x => x).ToList();

            if (numbersAboveAverageValue.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (numbersAboveAverageValue.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{numbersAboveAverageValue[i]} ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbersAboveAverageValue));
            }
        }
    }
}