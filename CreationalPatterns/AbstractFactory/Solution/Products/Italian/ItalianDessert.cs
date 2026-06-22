namespace AbstractFactory.Solution.Products.Italian
{
    public class ItalianDessert : IDessert
    {
        public string Name => "Tiramisu";
        public decimal Price => 12.00m;
        public Uri ImageURI => new("https://example.com/tiramisu.jpg");
        public int WeightInGrams => 150;
        public string Nationality => "Italiana";
    }
}
