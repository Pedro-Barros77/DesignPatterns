using Builder.Solution.Models;
using Builder.Solution.Models.Layers;

namespace Builder.Solution
{
    public interface IBuilder
    {
        void Reset();
        IceCream Build();
        IBuilder WithSize(Size size);
        IBuilder OnCone();
        IBuilder OnCup();
        IBuilder WithCoating(Sauce flavor);
        IBuilder WithCutlery(bool includeCutlery = true);
        IBuilder WithNapkins(bool includeNapkins = true);
        IBuilder ForTakeoutOrder(bool isTakeoutOrder = true);
        IBuilder AddLayer(IIceCreamLayer layer);
        IBuilder AddScoopLayer(Flavor flavor);
        IBuilder AddSauceLayer(Sauce flavor);
        IBuilder AddToppingLayer(Topping type);
        IBuilder AddFruitLayer(Fruit fruit);
        IBuilder WithLayers(IEnumerable<IIceCreamLayer> layers);
        IBuilder AddExtra(IIceCreamExtra extra);
        IBuilder AddExtraSauce(Sauce flavor);
        IBuilder AddExtraTopping(Topping type);
        IBuilder AddExtraFruit(Fruit fruit);
        IBuilder WithExtras(IEnumerable<IIceCreamExtra> extras);
    }
}
