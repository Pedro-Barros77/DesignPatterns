using Builder.Solution.Models;
using Builder.Solution.Models.Layers;

namespace Builder.Solution
{
    public class IceCreamBuilder : IBuilder
    {
        private IceCream _iceCream;

        public IceCreamBuilder()
        {
            _iceCream = new IceCream(Container.Cup, Size.Medium);
        }

        public void Reset()
        {
            _iceCream = new IceCream(Container.Cup, Size.Medium);
        }

        public IceCream Build()
        {
            var result = _iceCream;
            Reset();
            return result;
        }

        public IBuilder OnCone()
        {
            _iceCream.SetContainer(Container.Cone);
            return this;
        }

        public IBuilder OnCup()
        {
            _iceCream.SetContainer(Container.Cup);
            return this;
        }

        public IBuilder WithSize(Size size)
        {
            _iceCream.SetSize(size);
            return this;
        }

        public IBuilder WithCoating(Sauce flavor)
        {
            _iceCream.SetCoating(new SauceLayer(flavor));
            return this;
        }

        public IBuilder WithCutlery(bool includeCutlery = true)
        {
            _iceCream.SetCutlery(includeCutlery);
            return this;
        }

        public IBuilder WithNapkins(bool includeNapkins = true)
        {
            _iceCream.SetNapkins(includeNapkins);
            return this;
        }

        public IBuilder ForTakeoutOrder(bool isTakeoutOrder = true)
        {
            _iceCream.SetTakeoutOrder(isTakeoutOrder);
            return this;
        }

        public IBuilder AddLayer(IIceCreamLayer layer)
        {
            _iceCream.AddLayer(layer);
            return this;
        }

        public IBuilder AddScoopLayer(Flavor flavor)
        {
            _iceCream.AddLayer(new ScoopLayer(flavor));
            return this;
        }

        public IBuilder AddSauceLayer(Sauce flavor)
        {
            _iceCream.AddLayer(new SauceLayer(flavor));
            return this;
        }

        public IBuilder AddToppingLayer(Topping type)
        {
            _iceCream.AddLayer(new ToppingLayer(type));
            return this;
        }

        public IBuilder AddFruitLayer(Fruit fruit)
        {
            _iceCream.AddLayer(new FruitLayer(fruit));
            return this;
        }

        public IBuilder WithLayers(IEnumerable<IIceCreamLayer> layers)
        {
            _iceCream.SetLayers(layers);
            return this;
        }

        public IBuilder AddExtra(IIceCreamExtra extra)
        {
            _iceCream.AddExtra(extra);
            return this;
        }

        public IBuilder AddExtraSauce(Sauce flavor)
        {
            _iceCream.AddExtra(new SauceLayer(flavor));
            return this;
        }

        public IBuilder AddExtraTopping(Topping type)
        {
            _iceCream.AddExtra(new ToppingLayer(type));
            return this;
        }

        public IBuilder AddExtraFruit(Fruit fruit)
        {
            _iceCream.AddExtra(new FruitLayer(fruit));
            return this;
        }

        public IBuilder WithExtras(IEnumerable<IIceCreamExtra> extras)
        {
            _iceCream.SetExtras(extras);
            return this;
        }
    }
}
