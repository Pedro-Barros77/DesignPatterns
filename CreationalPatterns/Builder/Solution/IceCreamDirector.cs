using Builder.Solution.Models;
using Builder.Solution.Models.Layers;

namespace Builder.Solution
{
    public class IceCreamDirector
    {
        private readonly IBuilder _builder;

        public IceCreamDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public IceCream BuildEmptyCup()
        {
            _builder.Reset();
            _builder
                .OnCup()
                .WithSize(Size.Small)
                .WithCutlery(false)
                .WithNapkins(false)
                .ForTakeoutOrder(false);

            return _builder.Build();
        }

        public IceCream BuildKidsCone()
        {
            _builder.Reset();
            _builder
                .OnCone()
                .WithSize(Size.Small)
                .WithCutlery()
                .WithNapkins()
                .ForTakeoutOrder(false)
                .AddScoopLayer(Flavor.Strawberry)
                .AddScoopLayer(Flavor.Chocolate)
                .AddToppingLayer(Topping.Sprinkles)
                .AddSauceLayer(Sauce.Strawberry);

            return _builder.Build();
        }

        public IceCream BuildLargeNeapolitanPot()
        {
            _builder.Reset();
            _builder
                .OnCup()
                .WithSize(Size.Large)
                .WithCutlery(false)
                .WithNapkins(false)
                .ForTakeoutOrder()
                .AddScoopLayer(Flavor.Neapolitan);

            return _builder.Build();
        }
    }
}
