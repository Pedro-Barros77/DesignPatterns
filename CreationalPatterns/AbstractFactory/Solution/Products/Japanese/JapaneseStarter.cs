using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Solution.Products.Japanese
{
    public class JapaneseStarter : IStarter
    {
        public string Name => "Edamame";
        public decimal Price => 6.00m;
        public Uri ImageURI => new("https://example.com/edamame.jpg");
        public int WeightInGrams => 45;
        public string Nationality => "Japonesa";

        public void AddSauce()
        {
            WriteColored("Adicionando molho aos edamames.", 1);
        }
    }
}
