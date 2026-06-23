using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Problem.Models
{
    public interface IComplexObject
    {
        public string PublicText { get; set; }
        public int PublicNumber { get; set; }

        void PrintObject();
    }
}
