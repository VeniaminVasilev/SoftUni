namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string digits = string.Empty;
            string letters = string.Empty;
            string otherCharacters = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    digits += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    letters += currentChar;
                }
                else if (!char.IsLetterOrDigit(currentChar))
                {
                    otherCharacters += currentChar;
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherCharacters);
        }
    }
}