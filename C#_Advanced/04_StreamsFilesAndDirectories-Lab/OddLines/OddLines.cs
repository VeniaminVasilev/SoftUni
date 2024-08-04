namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line;
                    int lineNumber = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        lineNumber++;
                    }
                }
            }
        }
    }
}
