using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem.Models.Brazillian
{
    public class BrazillianDrink : IDrink
    {
        public string Name => "Caipirinha";
        public decimal Price => 15.00m;
        public Uri ImageURI => new("https://example.com/caipirinha.jpg");
        public int SizeInMl => 300;
        public string Nationality => "Brasileira";

        public void AddStraw()
        {
            WriteColored("Adicionando canudo ao drink Caipirinha", 1);
        }
    }
}
