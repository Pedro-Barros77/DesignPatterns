using static DesignPatterns.ConsoleUtils;

namespace Composite.Solution.Entities
{
    public class FileNode: INode
    {
        public string FileName { get; private set; }
        public long FileSizeInBytes { get; private set; }

        public FileNode(string fileName, long fileSizeInBytes)
        {
            FileName = fileName;
            FileSizeInBytes = fileSizeInBytes;
        }

        public void Render(int tabNumber = 0)
        {
            WriteColored(new TextItem(new string(' ', tabNumber * 2)), new("- "), new(FileName, ConsoleColor.White), new($" ({FileUtils.FormatFileSize(FileSizeInBytes)})", ConsoleColor.DarkGray, 1));
        }

        public long CalculateSize() => FileSizeInBytes;
    }
}
