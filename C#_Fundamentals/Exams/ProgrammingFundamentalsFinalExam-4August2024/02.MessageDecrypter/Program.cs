using System.Text.RegularExpressions;

namespace _02.MessageDecrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string myPattern = @"^(?<tag>\$[A-Z][a-z]{2,}\$|%[A-Z][a-z]{2,}%): \[(?<num1>\d+)\]\|\[(?<num2>\d+)\]\|\[(?<num3>\d+)\]\|$";
            // Example valid message: $Request$: [73]|[115]|[32]|

            Regex regexForValidMessage = new Regex(myPattern);

            for (int i = 0; i < n; i++)
            {
                string currentMessage = Console.ReadLine();
                Match match = regexForValidMessage.Match(currentMessage);

                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    string number1 = match.Groups["num1"].Value;
                    string number2 = match.Groups["num2"].Value;
                    string number3 = match.Groups["num3"].Value;

                    char character1 = Convert.ToChar(Convert.ToInt32(number1));
                    char character2 = Convert.ToChar(Convert.ToInt32(number2));
                    char character3 = Convert.ToChar(Convert.ToInt32(number3));

                    tag = tag.Remove(0, 1);
                    tag = tag.Remove(tag.Length - 1, 1);

                    Console.WriteLine($"{tag}: {character1}{character2}{character3}");
                }
                else
                {
                    Console.WriteLine($"Valid message not found!");
                }
            }
        }
    }
}