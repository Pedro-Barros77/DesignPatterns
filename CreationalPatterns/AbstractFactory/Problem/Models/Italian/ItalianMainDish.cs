using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem.Models.Italian
{
    public class ItalianMainDish : IMainDish
    {
        public string Name => "Lasagna";
        public decimal Price => 48.00m;
        public Uri ImageURI => new("https://example.com/lasagna.jpg");
        public int WeightInGrams => 500;
        public string Nationality => "Italiana";

        public void Prepare()
        {
            WriteColored("Cozinhando lasanha e servindo com molho de tomate e queijo derretido.", 1);
        }
    }
}
