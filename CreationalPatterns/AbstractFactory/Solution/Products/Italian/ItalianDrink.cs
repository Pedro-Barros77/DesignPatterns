using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Solution.Products.Italian
{
    public class ItalianDrink : IDrink
    {
        public string Name => "Limoncello";
        public decimal Price => 65.00m;
        public Uri ImageURI => new("https://example.com/limoncello.jpg");
        public int SizeInMl => 500;
        public string Nationality => "Italiana";

        public void AddStraw()
        {
            WriteColored("Adicionando canudo ao drink Limoncello", 1);
        }
    }
}
