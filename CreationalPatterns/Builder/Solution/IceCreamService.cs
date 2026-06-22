
using Builder.Solution.Models;
using Builder.Solution.Models.Layers;
using static DesignPatterns.ConsoleUtils;

namespace Builder.Solution
{
    public static class IceCreamService
    {
        public async static Task<List<IceCream>> GetOrder()
        {
            List<IceCream> order;

            var builder = new Solution.IceCreamBuilder();

            var iceCream1 = builder
                .OnCup()
                .WithSize(Size.Large)
                .AddSauceLayer(Sauce.PeanutButter)
                .AddScoopLayer(Flavor.Coconut)
                .AddScoopLayer(Flavor.CookiesAndCream)
                .AddScoopLayer(Flavor.Vanilla)
                .AddFruitLayer(Fruit.Banana)
                .AddFruitLayer(Fruit.Strawberry)
                .AddToppingLayer(Topping.CrushedCookies)
                .AddToppingLayer(Topping.ChocolateChips)
                .AddSauceLayer(Sauce.Caramel)
                .AddSauceLayer(Sauce.Chocolate)
                .WithCoating(Sauce.PeanutButter)
                .AddExtraSauce(Sauce.HotFudge)
                .WithCutlery()
                .WithNapkins()
                .ForTakeoutOrder(false)
                .Build();

            var iceCream2 = builder
                .OnCone()
                .WithSize(Size.Small)
                .AddSauceLayer(Sauce.PeanutButter)
                .AddScoopLayer(Flavor.BubbleGum)
                .AddScoopLayer(Flavor.Chocolate)
                .AddScoopLayer(Flavor.Strawberry)
                .AddFruitLayer(Fruit.Banana)
                .AddFruitLayer(Fruit.Strawberry)
                .AddToppingLayer(Topping.Sprinkles)
                .AddToppingLayer(Topping.MnM)
                .AddToppingLayer(Topping.WhippedCream)
                .AddToppingLayer(Topping.Peanut)
                .AddSauceLayer(Sauce.BlueIce)
                .WithCoating(Sauce.PeanutButter)
                .AddExtraSauce(Sauce.HotFudge)
                .WithCutlery()
                .WithNapkins()
                .ForTakeoutOrder(false)
                .Build();


            var iceCream3 = builder
                .OnCup()
                .WithSize(Size.Medium)
                .AddScoopLayer(Flavor.Pistachio)
                .AddScoopLayer(Flavor.Lemon)
                .AddScoopLayer(Flavor.Coffee)
                .AddToppingLayer(Topping.WhippedCream)
                .AddSauceLayer(Sauce.DulceDeLeche)
                .WithCutlery(false)
                .WithNapkins(false)
                .ForTakeoutOrder()
                .Build();

            var director = new IceCreamDirector(builder);
            var iceCream4 = director.BuildLargeNeapolitanPot();

            order = [iceCream1, iceCream2, iceCream3, iceCream4];

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
