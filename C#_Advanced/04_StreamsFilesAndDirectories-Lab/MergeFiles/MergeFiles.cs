namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> linesFromFile1 = new List<string>();
            List<string> linesFromFile2 = new List<string>();

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    linesFromFile1.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader (secondInputFilePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    linesFromFile2.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int length1 = linesFromFile1.Count;
                int length2 = linesFromFile2.Count;
                int minLength = Math.Min(length1, length2);

                for (int i = 0; i < minLength; i++)
                {
                    writer.WriteLine(linesFromFile1[i]);
                    writer.WriteLine(linesFromFile2[i]);
                }

                if (length1 > length2)
                {
                    int difference = length1 - length2;

                    for (int i = 0; i < difference; i++)
                    {
                        writer.WriteLine(linesFromFile1[minLength + i]);
                    }
                }
                else if (length2 > length1)
                {
                    int difference = length2 - length1;

                    for (int i = 0; i < difference; i++)
                    {
                        writer.WriteLine(linesFromFile2[minLength + i]);
                    }
                }
            }
        }
    }
}