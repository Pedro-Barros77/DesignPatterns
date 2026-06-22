using Builder.Problem.Models;
using Builder.Problem.Models.Layers;
using static DesignPatterns.ConsoleUtils;

namespace Builder.Problem
{
    public static class IceCreamService
    {
        public static async Task<List<IceCream>> GetOrder()
        {
            List<IceCream> order;

            var iceCream1 = new IceCream
            (
                Container.Cup,
                Size.Large,
                [
                    new SauceLayer(Sauce.PeanutButter),
                    new ScoopLayer(Flavor.Coconut),
                    new ScoopLayer(Flavor.CookiesAndCream),
                    new ScoopLayer(Flavor.Vanilla),
                    new FruitLayer(Fruit.Banana),
                    new FruitLayer(Fruit.Strawberry),
                    new ToppingLayer(Topping.CrushedCookies),
                    new ToppingLayer(Topping.ChocolateChips),
                    new SauceLayer(Sauce.Caramel),
                    new SauceLayer(Sauce.Chocolate)
                ],
                [
                    new SauceLayer(Sauce.HotFudge)
                ],
                new SauceLayer(Sauce.PeanutButter),
                true,
                true,
                false
            );

            var iceCream2 = new IceCream
            (
                Container.Cone,
                Size.Small,
                [
                    new SauceLayer(Sauce.PeanutButter),
                    new ScoopLayer(Flavor.BubbleGum),
                    new ScoopLayer(Flavor.Chocolate),
                    new ScoopLayer(Flavor.Strawberry),
                    new FruitLayer(Fruit.Banana),
                    new FruitLayer(Fruit.Strawberry),
                    new ToppingLayer(Topping.Sprinkles),
                    new ToppingLayer(Topping.MnM),
                    new ToppingLayer(Topping.WhippedCream),
                    new ToppingLayer(Topping.Peanut),
                    new SauceLayer(Sauce.BlueIce),
                ],
                [
                    new SauceLayer(Sauce.HotFudge)
                ],
                new SauceLayer(Sauce.PeanutButter),
                true,
                true,
                false
            );

            var iceCream3 = new IceCream
            (
                Container.Cup,
                Size.Medium,
                [
                    new ScoopLayer(Flavor.Pistachio),
                    new ScoopLayer(Flavor.Lemon),
                    new ScoopLayer(Flavor.Coffee),
                    new ToppingLayer(Topping.WhippedCream),
                    new SauceLayer(Sauce.DulceDeLeche),
                ],
                [],
                null,
                false,
                false,
                true
            );

            order = [iceCream1, iceCream2, iceCream3];

            foreach (var iceCream in order)
            {
                WriteSeparator();
                iceCream.PrintDetails();
                await Task.Delay(1000);
            }

            return order;
        }
    }
}
