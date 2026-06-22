using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Solution.Models.Layers
{
    public enum Fruit
    {
        Banana,
        Strawberry,
        Kiwi,
        Cherry,
        Mango,
        Papaya,
    }
    public class FruitLayer : IIceCreamExtra
    {
        public Fruit Type { get; set; }
        public FruitLayer(Fruit type)
        {
            Type = type;
        }

        public string GetName() => Type switch
        {
            Fruit.Banana => "Fruta: Banana",
            Fruit.Strawberry => "Fruta: Morango",
            Fruit.Kiwi => "Fruta: Kiwi",
            Fruit.Cherry => "Fruta: Cereja",
            Fruit.Mango => "Fruta: Manga",
            Fruit.Papaya => "Fruta: Mamão",
            _ => throw new NotImplementedException(),
        };
    }
}
