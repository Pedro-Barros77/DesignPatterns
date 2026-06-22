using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem.Models.Japanese
{
    public class JapaneseMainDish : IMainDish
    {
        public string Name => "Sushi";
        public decimal Price => 45.00m;
        public Uri ImageURI => new("https://example.com/sushi.jpg");
        public int WeightInGrams => 350;
        public string Nationality => "Japonesa";

        public void Prepare()
        {
            WriteColored("Preparando sushi e servindo com molho de soja e wasabi.", 1);
        }
    }
}
