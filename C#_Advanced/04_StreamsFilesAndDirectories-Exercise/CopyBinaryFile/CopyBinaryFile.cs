using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            const int bufferSize = 4096;

            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0;

                while ((bytesRead = inputFileStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    outputFileStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}