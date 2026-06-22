using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Solution.Products.Brazillian
{
    public class BrazillianMainDish : IMainDish
    {
        public string Name => "Feijoada";
        public decimal Price => 38.00m;
        public Uri ImageURI => new("https://example.com/feijoada.jpg");
        public int WeightInGrams => 500;
        public string Nationality => "Brasileira";

        public void Prepare()
        {
            WriteColored("Cozinhando feijoada e servindo acompanhada de arroz branco, couve, farofa e laranja.", 1);
        }
    }
}
