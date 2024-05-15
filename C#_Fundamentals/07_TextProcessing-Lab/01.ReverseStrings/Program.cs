namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                string reversedLine = string.Empty;

                if (line == "end") { break; }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversedLine += line[i];
                }

                Console.WriteLine($"{line} = {reversedLine}");
            }
        }
    }
}