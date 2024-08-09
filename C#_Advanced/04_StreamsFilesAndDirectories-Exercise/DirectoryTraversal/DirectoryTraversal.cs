namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var fileGroups = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!fileGroups.ContainsKey(extension))
                {
                    fileGroups[extension] = new List<FileInfo>();
                }

                fileGroups[extension].Add(fileInfo);
            }

            var sortedFileGroups = fileGroups
                .OrderByDescending(g => g.Value.Count)
                .ThenBy(g => g.Key)
                .ToList();

            var reportContent = new List<string>();

            foreach (var group in sortedFileGroups)
            {
                reportContent.Add(group.Key);

                var sortedFiles = group.Value.OrderBy(f => f.Length).ToList();

                foreach (var fileInfo in sortedFiles)
                {
                    double fileSizeInKb = fileInfo.Length / 1024.0;
                    reportContent.Add($"--{fileInfo.Name} - {fileSizeInKb:F3}kb");
                }
            }

            return string.Join(Environment.NewLine, reportContent);
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var reportFilePath = Path.Combine(desktopPath, reportFileName);

            File.WriteAllText(reportFilePath, textContent);
        }
    }
}