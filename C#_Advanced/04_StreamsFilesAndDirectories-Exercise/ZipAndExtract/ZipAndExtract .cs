namespace ZipAndExtract
{
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            using (ZipArchive zip = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive zip = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry entry = zip.GetEntry(fileName);
                if (entry != null)
                {
                    entry.ExtractToFile(outputFilePath, true);
                }
            }
        }
    }
}