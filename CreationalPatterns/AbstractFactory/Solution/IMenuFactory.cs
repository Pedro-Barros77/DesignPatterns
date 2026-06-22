using AbstractFactory.Solution.Products;

namespace AbstractFactory.Solution
{
    // Abstract factory: creates a complete family of related products.
    public interface IMenuFactory
    {
        IStarter CreateStarter();
        IDrink CreateDrink();
        IMainDish CreateMainDish();
        IDessert CreateDessert();
    }
}
