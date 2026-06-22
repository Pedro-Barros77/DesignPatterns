using AbstractFactory.Solution.Products;
using AbstractFactory.Solution.Products.Japanese;

namespace AbstractFactory.Solution.Creators
{
    // Concrete factory
    public class JapaneseMenuFactory : IMenuFactory
    {
        public IStarter CreateStarter()
        {
            return new JapaneseStarter();
        }
        public IDrink CreateDrink()
        {
            return new JapaneseDrink();
        }
        public IMainDish CreateMainDish()
        {
            return new JapaneseMainDish();
        }
        public IDessert CreateDessert()
        {
            return new JapaneseDessert();
        }
    }
}
