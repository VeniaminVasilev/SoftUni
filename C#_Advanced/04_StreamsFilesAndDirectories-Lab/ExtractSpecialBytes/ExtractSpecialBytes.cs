namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> targetBytes = new HashSet<byte>();
            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    byte currentByte = Byte.Parse(line);
                    targetBytes.Add(currentByte);
                }
            }

            using (FileStream inputFile = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                int byteValue;

                while ((byteValue = inputFile.ReadByte()) != -1)
                {
                    byte currentByte = (byte)byteValue;

                    if (targetBytes.Contains(currentByte))
                    {
                        outputFile.WriteByte(currentByte);
                    }
                }
            }
        }
    }
}