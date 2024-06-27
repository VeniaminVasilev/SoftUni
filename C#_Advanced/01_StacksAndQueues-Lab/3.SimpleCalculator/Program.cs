namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ")
                .Reverse()
                .ToList();
            Stack<string> stack = new Stack<string>();
            int result = 0;

            for (int i = 0; i < input.Count; i++)
            {
                stack.Push(input[i]);
            }

            result += int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                char operation = char.Parse(stack.Pop());
                int number = int.Parse(stack.Pop());

                if (operation == '+')
                {
                    result += number;
                }
                else if (operation == '-')
                {
                    result -= number;
                }
            }

            Console.WriteLine(result);
        }
    }
}