using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory.Problem.Models.Japanese
{
    public class JapaneseDrink : IDrink
    {
        public string Name => "Sake";
        public decimal Price => 15.00m;
        public Uri ImageURI => new("https://example.com/sake.jpg");
        public int SizeInMl => 300;
        public string Nationality => "Japonesa";

        public void AddStraw()
        {
            WriteColored("Adicionando canudo ao drink Sake", 1);
        }
    }
}
