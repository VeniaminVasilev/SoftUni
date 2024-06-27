namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexesOfBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexesOfBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int indexOfOpeningBracket = indexesOfBrackets.Pop();
                    int indexOfClosingBracket = i;
                    string subString = input.Substring(indexOfOpeningBracket, indexOfClosingBracket - indexOfOpeningBracket + 1);

                    Console.WriteLine(subString);
                }
            }
        }
    }
}