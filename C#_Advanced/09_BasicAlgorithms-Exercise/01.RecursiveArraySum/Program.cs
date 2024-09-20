namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(numbers, 0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}