using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Solution.Products.Brazillian
{
    public class BrazillianStarter : IStarter
    {
        public string Name => "Mini Pastel Frito";
        public decimal Price => 12.00m;
        public Uri ImageURI => new("https://example.com/mini_pastel_frito.jpg");
        public int WeightInGrams => 50;
        public string Nationality => "Brasileira";

        public void AddSauce()
        {
            WriteColored("Adicionando molho aos mini pastéis.", 1);
        }
    }
}
