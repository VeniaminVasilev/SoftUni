using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";

            List<string> validPairs = new List<string>();
            List<string> mirrorWords = new List<string>();
            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                validPairs.Add(match.Value);

                string currentMatch = match.Value;
                if (currentMatch.Length % 2 != 0)
                {
                    continue;
                }
                else
                {
                    string wordOne = currentMatch.Substring(1, (currentMatch.Length / 2) - 2);
                    string wordTwo = currentMatch.Substring((currentMatch.Length / 2) + 1, wordOne.Length);
                    string reversedWordTwo = new string(wordTwo.Reverse().ToArray());

                    if (wordOne == reversedWordTwo)
                    {
                        mirrorWords.Add($"{wordOne} <=> {wordTwo}");
                    }
                }
            }

            if (validPairs.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else if (validPairs.Count > 0)
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else if (mirrorWords.Count > 0)
            {
                Console.WriteLine($"The mirror words are:\n{string.Join(", ", mirrorWords)}");
            }
        }
    }
}