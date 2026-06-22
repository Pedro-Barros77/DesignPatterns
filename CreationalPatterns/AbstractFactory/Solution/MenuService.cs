using AbstractFactory.Solution.Products;
using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Solution
{
    public static class MenuService
    {
        public static async Task PrepareNationalityMeal(IMenuFactory menuFactory)
        {
            WriteSeparator();

            // Every product comes from the same factory, preserving the menu family.
            var starter = menuFactory.CreateStarter();
            var drink = menuFactory.CreateDrink();
            var mainDish = menuFactory.CreateMainDish();
            var dessert = menuFactory.CreateDessert();

            await ServeStarters(starter, drink);
            await PrepareMainDish(mainDish);
            await ServeDessert(dessert);
        }

        private static async Task ServeStarters(IStarter starter, IDrink drink)
        {
            WriteColored("Preparando entradas...", 1);
            starter.AddSauce();
            drink.AddStraw();

            await Task.Delay(1000);
            WriteColored("Servindo entradas...", 1);
            await Task.Delay(2000);
            WriteColored("Pronto.", 2);
            await Task.Delay(2000);
        }

        private static async Task PrepareMainDish(IMainDish mainDish)
        {
            WriteColored("Preparando o prato principal...", 1);
            mainDish.Prepare();

            await Task.Delay(2000);
            WriteColored(new TextItem("Servindo prato principal "), new(mainDish.Name, ConsoleColor.White, 1));
            await Task.Delay(1000);
            WriteColored("Pronto.", 2);
        }

        private static async Task ServeDessert(IDessert dessert)
        {
            WriteColored(new TextItem("Servindo sobremesa "), new(dessert.Name, ConsoleColor.White, 1));
            await Task.Delay(1000);
            WriteColored("Pronto.", 2);
        }
    }
}
