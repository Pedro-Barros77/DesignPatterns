using static DesignPatterns.ConsoleUtils;

namespace Composite.Problem.Entities
{
    public class FolderNode
    {
        public string FolderName { get; private set; }
        public bool IsExpanded { get; private set; }
        public List<FolderNode> Folders { get; private set; }
        public List<FileNode> Files { get; private set; }

        public FolderNode(string folderName, bool isExpanded, List<FolderNode> folders, List<FileNode> files)
        {
            FolderName = folderName;
            IsExpanded = isExpanded;
            Folders = folders;
            Files = files;
        }

        public long CalculateFolderSize()
        {
            long result = 0;

            foreach (var file in Files)
                result += file.FileSizeInBytes;

            foreach (var folder in Folders)
                result += folder.CalculateFolderSize();

            return result;
        }

        public void Render(int tabNumber = 0)
        {
            WriteColored(new TextItem(new string(' ', tabNumber * 2)), new(IsExpanded ? "+ " : "> "), new(FolderName, ConsoleColor.Yellow), new($" ({FileUtils.FormatFileSize(CalculateFolderSize())})", ConsoleColor.DarkGray, 1));

            if (IsExpanded)
            {
                foreach (var folder in Folders)
                    folder.Render(tabNumber + 1);

                foreach (var file in Files)
                    file.Render(tabNumber + 1);
            }
        }

        public void Expand()
        {
            IsExpanded = true;
        }

        public void Collapse()
        {
            IsExpanded = false;
        }

        public void ExpandAll()
        {
            IsExpanded = true;
            foreach (var folder in Folders)
                folder.ExpandAll();
        }

        public void CollapseAll()
        {
            IsExpanded = false;
            foreach (var folder in Folders)
                folder.CollapseAll();
        }
    }
}
