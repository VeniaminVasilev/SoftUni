namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            Console.WriteLine($"{numbers.Count}\n{numbers.Sum()}");
        }
    }
}