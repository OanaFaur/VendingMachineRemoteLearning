namespace iQuest.VendingMachine.Serialization
{
    internal interface IFileService
    {
        void Save(string textToWrite, string fileFormat, string folderName, string fileName);
    }
}