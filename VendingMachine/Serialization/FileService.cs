using System.IO;
using System.IO.Compression;

namespace iQuest.VendingMachine.Serialization
{
    internal class FileService : IFileService
    {
        public void Save(string textToWrite, string fileFormat, string folderName, string fileName)
        {
            string fullPath = $@"C:\Users\OANA\source\repos\oanafaur_rl1\Vending Machine\VendingMachine\Serialization\{fileFormat}\{folderName}\{fileName}.zip";

            using (var zipToOpen = new MemoryStream())
            {
                using (var reportsArchive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    var newReportFile = reportsArchive.CreateEntry($"{fileName}.{fileFormat.ToLower()}");

                    using (var writingStream = newReportFile.Open())

                    using (var writer = new StreamWriter(writingStream))
                    {
                        writer.Write(textToWrite);
                    }
                }

                ZippedReportFileStream zipped = new ZippedReportFileStream(fullPath);

                var bytes = zipToOpen.GetBuffer();
                zipped.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
