using AbstractFactory.Solution.Products;
using AbstractFactory.Solution.Products.Brazillian;

namespace AbstractFactory.Solution.Creators
{
    // Concrete factory
    public class BrazillianMenuFactory : IMenuFactory
    {
        public IStarter CreateStarter()
        {
            return new BrazillianStarter();
        }
        public IDrink CreateDrink()
        {
            return new BrazillianDrink();
        }
        public IMainDish CreateMainDish()
        {
            return new BrazillianMainDish();
        }
        public IDessert CreateDessert()
        {
            return new BrazillianDessert();
        }
    }
}
