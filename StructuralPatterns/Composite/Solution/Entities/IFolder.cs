using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Solution.Entities
{
    public interface IFolder
    {
        List<INode> Nodes { get; }
        void Expand(List<int>? indexAddress = null);
        void Collapse(List<int>? indexAddress = null);
        void ExpandAll();
        void CollapseAll();
    }
}
