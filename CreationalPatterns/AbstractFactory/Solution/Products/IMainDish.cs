using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Solution.Products
{
    public interface IMainDish
    {
        public string Name { get; }
        public decimal Price { get; }
        public Uri ImageURI { get; }
        public int WeightInGrams { get; }
        public string Nationality { get; }

        void Prepare();
    }
}
