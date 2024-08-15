namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int divisibleNumber = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> reverseAndRemoveFromList = (numbers, divisibleNumber) =>
            {
                numbers.Reverse();

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % divisibleNumber == 0)
                    {
                        numbers.RemoveAt(i);
                        i--;
                    }
                }

                return numbers;
            };

            Action<List<int>> printer = numbers => Console.WriteLine(string.Join(" ", numbers));

            numbers = reverseAndRemoveFromList(numbers, divisibleNumber);
            printer(numbers);
        }
    }
}