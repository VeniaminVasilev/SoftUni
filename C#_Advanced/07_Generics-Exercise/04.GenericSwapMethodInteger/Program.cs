namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Collection<int> integers = new Collection<int>(new List<int>());

            for (int i = 0; i < n; i++)
            {
                int currentInt = int.Parse(Console.ReadLine());
                integers.Elements.Add(currentInt);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            integers.SwapElementsAndPrint(indexes[0], indexes[1]);
        }
    }
}