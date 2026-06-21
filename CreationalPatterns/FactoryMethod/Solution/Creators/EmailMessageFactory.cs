using FactoryMethod.Solution.Products;

namespace DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators
{
    //Concrete creator
    public class EmailMessageFactory : MessageFactory
    {
        protected override IMessage Create(string title, string content, string to)
        {
            return new EmailMessage(title, content, to);
        }
    }
}
