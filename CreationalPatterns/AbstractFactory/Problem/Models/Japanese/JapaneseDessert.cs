namespace AbstractFactory.Problem.Models.Japanese
{
    public class JapaneseDessert : IDessert
    {
        public string Name => "Mochi";
        public decimal Price => 8.00m;
        public Uri ImageURI => new("https://example.com/mochi.jpg");
        public int WeightInGrams => 30;
        public string Nationality => "Japonesa";
    }
}
