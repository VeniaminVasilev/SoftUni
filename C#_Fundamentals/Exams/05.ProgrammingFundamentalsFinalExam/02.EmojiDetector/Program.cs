using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger coolThreshold = new BigInteger(1);

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    coolThreshold *= int.Parse(input[i].ToString());
                }
            }

            string pattern = @"((::|\*\*)[A-Z][a-z]{2,}(\2))";
            MatchCollection matches = Regex.Matches(input, pattern);
            int emojisFound = matches.Count;
            List<string> coolEmojis = new List<string>();

            foreach (Match emoji in matches)
            {
                string currentEmoji = emoji.Value;
                string substring = currentEmoji.Substring(2, currentEmoji.Length - 4);
                int coolness = 0;

                for (int i = 0; i < substring.Length; i++)
                {
                    coolness += (char)substring[i];
                }

                if (coolness >= coolThreshold)
                {
                    coolEmojis.Add(currentEmoji);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojisFound} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}