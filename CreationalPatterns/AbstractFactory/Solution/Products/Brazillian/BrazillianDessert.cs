namespace AbstractFactory.Solution.Products.Brazillian
{
    public class BrazillianDessert : IDessert
    {
        public string Name => "Brigadeiro";
        public decimal Price => 5.00m;
        public Uri ImageURI => new("https://example.com/brigadeiro.jpg");
        public int WeightInGrams => 20;
        public string Nationality => "Brasileira";
    }
}
