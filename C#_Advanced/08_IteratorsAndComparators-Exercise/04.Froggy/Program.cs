namespace _04.Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Lake newLake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", newLake));
        }
    }
}