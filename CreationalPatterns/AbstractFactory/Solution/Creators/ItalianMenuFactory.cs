using AbstractFactory.Solution.Products;
using AbstractFactory.Solution.Products.Italian;

namespace AbstractFactory.Solution.Creators
{
    // Concrete factory
    public class ItalianMenuFactory : IMenuFactory
    {
        public IStarter CreateStarter()
        {
            return new ItalianStarter();
        }
        public IDrink CreateDrink()
        {
            return new ItalianDrink();
        }
        public IMainDish CreateMainDish()
        {
            return new ItalianMainDish();
        }
        public IDessert CreateDessert()
        {
            return new ItalianDessert();
        }
    }
}
