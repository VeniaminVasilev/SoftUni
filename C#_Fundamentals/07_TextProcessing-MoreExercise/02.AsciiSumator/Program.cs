namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startCharacter = char.Parse(Console.ReadLine());
            char endCharacter = char.Parse(Console.ReadLine());
            string line = Console.ReadLine();

            int startNumber = (int)startCharacter;
            int endNumber = (int)endCharacter;

            int sum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                int currentNumber = (int)line[i];

                if (currentNumber > startNumber && currentNumber < endNumber)
                {
                    sum += currentNumber;
                }
            }
            Console.WriteLine(sum);
        }
    }
}