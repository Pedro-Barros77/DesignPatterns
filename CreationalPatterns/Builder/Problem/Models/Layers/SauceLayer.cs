using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Problem.Models.Layers
{
    public enum Sauce
    {
        Chocolate,
        Strawberry,
        Caramel,
        BlueIce,
        DulceDeLeche,
        HotFudge,
        PeanutButter,
        CookieButter,
    }
    public class SauceLayer : IIceCreamExtra
    {
        public Sauce Flavor { get; set; }
        public SauceLayer(Sauce flavor)
        {
            Flavor = flavor;
        }

        public string GetName() => Flavor switch
        {
            Sauce.Chocolate => "Cobertura de Chocolate",
            Sauce.Strawberry => "Cobertura de Morango",
            Sauce.Caramel => "Cobertura de Caramelo",
            Sauce.BlueIce => "Cobertura de Azul Gelo",
            Sauce.DulceDeLeche => "Cobertura de Doce de Leite",
            Sauce.HotFudge => "Cobertura de Calda de chocolate quente",
            Sauce.PeanutButter => "Cobertura de pasta de amendoim",
            Sauce.CookieButter => "Cobertura de Pasta de Oreo",
            _ => throw new NotImplementedException(),
        };
    }
}
