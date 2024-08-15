namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, string, List<int>> manipulationOfList = (numbers, command) =>
            {
                if (command == "add")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] += 1;
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] *= 2;
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                return numbers;
            };

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") { break; }

                numbers = manipulationOfList(numbers, command);
            }
        }
    }
}