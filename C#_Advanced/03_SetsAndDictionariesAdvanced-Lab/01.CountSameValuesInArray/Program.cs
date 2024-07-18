namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();

            foreach (double value in values)
            {
                if (counts.ContainsKey(value))
                {
                    counts[value]++;
                }
                else
                {
                    counts[value] = 1;
                }
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}