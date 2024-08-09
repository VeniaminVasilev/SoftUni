namespace LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line;
                    int countLines = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        int countLetters = 0;
                        int countPunctuation = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                countLetters++;
                            }
                            else if (char.IsPunctuation(line[i]))
                            {
                                countPunctuation++;
                            }
                        }

                        string editedLine = $"Line {countLines}: {line} ({countLetters})({countPunctuation})";

                        writer.WriteLine(editedLine);
                        countLines++;
                    }
                }
            }
        }
    }
}