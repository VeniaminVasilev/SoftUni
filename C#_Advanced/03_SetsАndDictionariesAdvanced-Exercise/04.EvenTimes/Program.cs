namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers[currentNumber] = 1;
                }
            }

            var evenPair = numbers.FirstOrDefault(n => n.Value % 2 == 0);
            Console.WriteLine(evenPair.Key);
        }
    }
}