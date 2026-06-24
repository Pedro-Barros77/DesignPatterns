using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Solution.Entities
{
    public interface INode
    {
        long CalculateSize();
        void Render(int tabNumber = 0);
    }
}
