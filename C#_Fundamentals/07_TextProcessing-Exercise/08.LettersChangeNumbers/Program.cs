namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            decimal totalSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                string currentString = array[i];

                char firstLetter = currentString[0];
                char lastLetter = currentString[currentString.Length - 1];
                decimal number = decimal.Parse(currentString.Substring(1, currentString.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    number = number / ((int)firstLetter - 64);
                }
                else if (char.IsLower(firstLetter))
                {
                    number = number * ((int)firstLetter - 96);
                }

                if (char.IsUpper(lastLetter))
                {
                    number = number - ((int)lastLetter - 64);
                }
                else if (char.IsLower(lastLetter))
                {
                    number = number + ((int)lastLetter - 96);
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}