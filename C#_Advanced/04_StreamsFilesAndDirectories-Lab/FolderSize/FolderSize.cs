namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long totalSize = CalculateFolderSize(folderPath);
            double sizeInKilobytes = totalSize / 1024.0;
            string formattedSize = sizeInKilobytes.ToString("F10") + " KB";

            File.WriteAllText(outputFilePath, formattedSize);
        }

        public static long CalculateFolderSize(string folderPath)
        {
            long folderSize = 0;

            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                folderSize += fileInfo.Length;
            }

            string[] directories = Directory.GetDirectories(folderPath);
            foreach (string directory in directories)
            {
                folderSize += CalculateFolderSize(directory);
            }

            return folderSize;
        }
    }
}
