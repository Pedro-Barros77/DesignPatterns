using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Problem.Models
{
    public interface IDrink
    {
        public string Name { get; }
        public decimal Price { get; }
        public Uri ImageURI { get; }
        public int SizeInMl { get; }
        public string Nationality { get; }

        void AddStraw();
    }
}
