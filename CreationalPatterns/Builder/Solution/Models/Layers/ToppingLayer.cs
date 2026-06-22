using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Solution.Models.Layers
{
    public enum Topping
    {
        Sprinkles,
        ChocolateChips,
        CrushedCookies,
        WhippedCream,
        Cherry,
        MnM,
        Peanut,
    }
    public class ToppingLayer : IIceCreamExtra
    {
        public Topping Type { get; set; }
        public ToppingLayer(Topping type) 
        {
            Type = type;
        }

        public string GetName() => Type switch
        {
            Topping.Sprinkles => "Topping: Granulado",
            Topping.ChocolateChips => "Topping: Gotas de Chocolate",
            Topping.CrushedCookies => "Topping: Farelo de Oreo",
            Topping.WhippedCream => "Topping: Chantilly",
            Topping.Cherry => "Topping: Cereja",
            Topping.MnM => "Topping: M&M's",
            Topping.Peanut => "Topping: Amendoim",
            _ => throw new NotImplementedException(),
        };
    }
}
