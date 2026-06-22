using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem.Models.Italian
{
    public class ItalianStarter : IStarter
    {
        public string Name => "Bruschetta";
        public decimal Price => 15.00m;
        public Uri ImageURI => new("https://example.com/bruschetta.jpg");
        public int WeightInGrams => 150;
        public string Nationality => "Italiana";

        public void AddSauce()
        {
            WriteColored("Adicionando molho à bruschetta.", 1);
        }
    }
}
