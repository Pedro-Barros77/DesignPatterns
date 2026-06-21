using FactoryMethod.Solution.Products;

namespace DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators
{
    //Concrete creator
    public class WhatsappMessageFactory : MessageFactory
    {
        protected override IMessage Create(string title, string content, string to)
        {
            return new WhatsappMessage(title, content, to);
        }
    }
}
