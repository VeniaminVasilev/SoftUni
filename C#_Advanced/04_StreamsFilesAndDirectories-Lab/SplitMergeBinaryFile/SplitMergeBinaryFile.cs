namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            int length = sourceFilePath.Length;
            List<byte> bytes = new List<byte>();

            using (FileStream inputFile = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputPart1 = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
            using (FileStream outputPart2 = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
            {
                if (length % 2 == 0)
                {
                    for (int i = 0; i < length / 2; i++)
                    {
                        int b = inputFile.ReadByte();
                        outputPart1.WriteByte((byte)b);
                    }
                    for (int i = length / 2; i < length; i++)
                    {
                        int b = inputFile.ReadByte();
                        outputPart2.WriteByte((byte)b);
                    }
                }
                else
                {
                    for (int i = 0; i < (length / 2) + 1; i++)
                    {
                        int b = inputFile.ReadByte();
                        outputPart1.WriteByte((byte)b);
                    }
                    for (int i = (length / 2) + 1; i < length; i++)
                    {
                        int b = inputFile.ReadByte();
                        outputPart2.WriteByte((byte)b);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream inputPart1 = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream inputPart2 = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                int b;
                while ((b = inputPart1.ReadByte()) != -1)
                {
                    joinedFile.WriteByte((byte)b);
                }

                while ((b = inputPart2.ReadByte()) != -1)
                {
                    joinedFile.WriteByte((byte)b);
                }
            }
        }
    }
}