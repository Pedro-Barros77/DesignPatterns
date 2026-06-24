using static DesignPatterns.ConsoleUtils;

namespace Composite.Solution.Entities
{
    public class FolderNode : INode, IFolder
    {
        public string FolderName { get; private set; }
        public bool IsExpanded { get; private set; }
        public List<INode> Nodes { get; private set; }

        public FolderNode(string folderName, bool isExpanded, List<INode> nodes)
        {
            FolderName = folderName;
            IsExpanded = isExpanded;
            Nodes = nodes;
        }

        public long CalculateSize()
        {
            long result = 0;

            foreach (var node in Nodes)
                result += node.CalculateSize();

            return result;
        }

        public void Render(int tabNumber = 0)
        {
            WriteColored(new TextItem(new string(' ', tabNumber * 2)), new(IsExpanded ? "+ " : "> "), new(FolderName, ConsoleColor.Yellow), new($" ({FileUtils.FormatFileSize(CalculateSize())})", ConsoleColor.DarkGray, 1));

            if (!IsExpanded)
                return;

            foreach (var node in Nodes)
                node.Render(tabNumber + 1);
        }

        public void Expand(List<int>? indexAddress = null)
        {
            IsExpanded = true;
            if (indexAddress is null || indexAddress.Count == 0)
                return;

            int childIndex = indexAddress[0];

            if (Nodes.Count > childIndex && Nodes[childIndex] is IFolder folder)
                folder.Expand(indexAddress[1..]);
        }

        public void Collapse(List<int>? indexAddress = null)
        {
            IsExpanded = false;
            if (indexAddress is null || indexAddress.Count == 0)
                return;

            int childIndex = indexAddress[0];

            if (Nodes.Count > childIndex && Nodes[childIndex] is IFolder folder)
                folder.Collapse(indexAddress[1..]);
        }

        public void ExpandAll()
        {
            Expand();
            foreach (var node in Nodes)
            {
                if (node is IFolder folder)
                    folder.ExpandAll();
            }
        }

        public void CollapseAll()
        {
            Collapse();
            foreach (var node in Nodes)
            {
                if (node is IFolder folder)
                    folder.CollapseAll();
            }
        }
    }
}
