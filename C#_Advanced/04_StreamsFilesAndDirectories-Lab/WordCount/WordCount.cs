namespace WordCount
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = File.ReadAllText(wordsFilePath)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Trim().ToLower())
                .Distinct()
                .ToList();

            Dictionary<string, int> wordsAppearance = new Dictionary<string, int>();
            foreach (string word in words)
            {
                wordsAppearance[word] = 0;
            }

            string text = File.ReadAllText(textFilePath).ToLower();
            List<string> textWords = Regex.Matches(text, @"\b\w+\b")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();

            foreach (string word in textWords)
            {
                if (wordsAppearance.ContainsKey(word))
                {
                    wordsAppearance[word] += 1;
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var pair in wordsAppearance.OrderByDescending(p => p.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}