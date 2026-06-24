using static DesignPatterns.ConsoleUtils;

namespace Composite.Problem.Entities
{
    public class FileNode
    {
        public string FileName { get; private set; }
        public long FileSizeInBytes { get; private set; }

        public FileNode(string fileName, long fileSizeInBytes)
        {
            FileName = fileName;
            FileSizeInBytes = fileSizeInBytes;
        }

        public void Render(int tabNumber)
        {
            WriteColored(new TextItem(new string(' ', tabNumber * 2)), new("- "), new(FileName, ConsoleColor.White), new($" ({FileUtils.FormatFileSize(FileSizeInBytes)})", ConsoleColor.DarkGray, 1));
        }
    }
}
