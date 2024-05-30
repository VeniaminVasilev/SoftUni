namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example Input: C:\Internal\training-internal\Template.pptx

            string pathToFile = Console.ReadLine();
            int lastIndexOfDot = pathToFile.LastIndexOf('.');
            int fileNameStartIndex = pathToFile.LastIndexOf('\\') + 1;
            int extensionLength = pathToFile.Length - lastIndexOfDot - 1;
            int fileNameLength = pathToFile.Length - fileNameStartIndex - (pathToFile.Length - lastIndexOfDot);
            string fileName = pathToFile.Substring(fileNameStartIndex, fileNameLength);
            string extension = pathToFile.Substring(lastIndexOfDot + 1, extensionLength);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}