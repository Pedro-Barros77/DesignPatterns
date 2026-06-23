using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Solution.Models
{
    public interface IComplexObject : IPrototype<IComplexObject>
    {
        public string PublicText { get; set; }
        public int PublicNumber { get; set; }

        void PrintObject();
    }
}
