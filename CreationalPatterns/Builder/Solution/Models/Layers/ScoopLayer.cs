using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Solution.Models.Layers
{
    public enum Flavor
    {
        Vanilla,
        Chocolate,
        Strawberry,
        MintChocolateChip,
        CookiesAndCream,
        Caramel,
        Pistachio,
        Coconut,
        Coffee,
        Lemon,
        DulceDeLeche,
        Neapolitan,
        BubbleGum
    }
    public class ScoopLayer : IIceCreamLayer
    {
        public Flavor Flavor { get; set; }
        public ScoopLayer(Flavor flavor)
        {
            Flavor = flavor;
        }

        public string GetName() => Flavor switch
        {
            Flavor.Vanilla => "Sorvete de Baunilha",
            Flavor.Chocolate => "Sorvete de Chocolate",
            Flavor.Strawberry => "Sorvete de Morango",
            Flavor.MintChocolateChip => "Sorvete de Menta com chocolate",
            Flavor.CookiesAndCream => "Sorvete de Cookies and Cream",
            Flavor.Caramel => "Sorvete de Caramelo",
            Flavor.Pistachio => "Sorvete de Pistache",
            Flavor.Coconut => "Sorvete de Coco",
            Flavor.Coffee => "Sorvete de Café",
            Flavor.Lemon => "Sorvete de Limão",
            Flavor.DulceDeLeche => "Sorvete de Doce de Leite",
            Flavor.Neapolitan => "Sorvete de Napolitano",
            Flavor.BubbleGum => "Sorvete de Chiclete",
            _ => throw new NotImplementedException(),
        };
    }
}
