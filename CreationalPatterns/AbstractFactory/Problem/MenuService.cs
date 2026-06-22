using AbstractFactory.Problem.Models;
using AbstractFactory.Problem.Models.Brazillian;
using AbstractFactory.Problem.Models.Italian;
using AbstractFactory.Problem.Models.Japanese;
using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem
{
    public enum Nationality
    {
        Brazillian = 1,
        Italian = 2,
        Japanese = 3
    }

    public static class MenuService
    {
        public static async Task PrepareNationalityMeal(Nationality nationality)
        {
            WriteSeparator();

            switch (nationality)
            {
                case Nationality.Brazillian:
                    WriteColored(new TextItem("Iniciando preparação da refeição "), new TextItem("Brasileira", ConsoleColor.Green, 2));

                    var brazillianStarter = new BrazillianStarter();
                    var brazillianDrink = new BrazillianDrink();
                    var brazillianMainDish = new BrazillianMainDish();
                    var brazillianDessert = new BrazillianDessert();

                    await ServeStarters(brazillianStarter, brazillianDrink);
                    await PrepareMainDish(brazillianMainDish);
                    await ServeDessert(brazillianDessert);

                    break;
                case Nationality.Italian:
                    WriteColored(new TextItem("Iniciando preparação da refeição "), new TextItem("Italiana", ConsoleColor.Magenta, 2));

                    var italianStarter = new ItalianStarter();
                    var italianDrink = new ItalianDrink();
                    var italianMainDish = new ItalianMainDish();
                    var italianDessert = new ItalianDessert();

                    await ServeStarters(italianStarter, italianDrink);
                    await PrepareMainDish(italianMainDish);
                    await ServeDessert(italianDessert);
                    break;
                case Nationality.Japanese:
                    WriteColored(new TextItem("Iniciando preparação da refeição "), new TextItem("Japonesa", ConsoleColor.Cyan, 2));

                    var japaneseStarter = new JapaneseStarter();
                    var japaneseDrink = new JapaneseDrink();
                    var japaneseMainDish = new JapaneseMainDish();
                    var japaneseDessert = new JapaneseDessert();

                    await ServeStarters(japaneseStarter, japaneseDrink);
                    await PrepareMainDish(japaneseMainDish);
                    await ServeDessert(japaneseDessert);
                    break;
                default:
                    Console.WriteLine("Nacionalidade inválida.");
                    break;
            }
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
