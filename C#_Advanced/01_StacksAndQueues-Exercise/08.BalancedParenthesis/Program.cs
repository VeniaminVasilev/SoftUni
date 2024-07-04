namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stackParenthesis = new Stack<char>();
            bool balanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stackParenthesis.Push(input[i]);
                    continue;
                }

                if (stackParenthesis.Count == 0)
                {
                    balanced = false;
                    break;
                }

                if (input[i] == ')' && stackParenthesis.Peek() == '('
                    || input[i] == '}' && stackParenthesis.Peek() == '{'
                    || input[i] == ']' && stackParenthesis.Peek() == '[')
                {
                    stackParenthesis.Pop();
                }
                else
                {
                    balanced = false;
                    break;
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}