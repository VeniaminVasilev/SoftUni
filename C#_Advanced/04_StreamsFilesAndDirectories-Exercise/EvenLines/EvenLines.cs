namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            string result = "";

            for (int i = 0; i < lines.Length; i += 2)
            {
                string currentLine = lines[i]
                    .Replace("-", "@")
                    .Replace(",", "@")
                    .Replace(".", "@")
                    .Replace("!", "@")
                    .Replace("?", "@");

                string[] reversedWords = currentLine.Split(' ').Reverse().ToArray();

                string reversedLine = string.Join(" ", reversedWords);

                result += reversedLine + "\n";
            }

            return result;
        }
    }
}