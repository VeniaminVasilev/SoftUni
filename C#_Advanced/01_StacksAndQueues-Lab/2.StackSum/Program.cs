namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>();

            foreach (int number in list)
            {
                stack.Push(number);
            }

            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "end")
                {
                    Console.WriteLine($"Sum: {stack.Sum()}");
                    break;
                }

                string[] tokens = command.Split(" ");
                string action = tokens[0].ToLower();

                if (action == "add")
                {
                    int number1 = int.Parse(tokens[1]);
                    int number2 = int.Parse(tokens[2]);

                    stack.Push(number1);
                    stack.Push(number2);
                }
                else if (action == "remove")
                {
                    int count = int.Parse(tokens[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
        }
    }
}