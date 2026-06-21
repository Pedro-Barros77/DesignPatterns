using FactoryMethod.Solution.Products;

namespace DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators
{
    //Concrete creator
    public class SmsMessageFactory : MessageFactory
    {
        protected override IMessage Create(string title, string content, string to)
        {
            return new SMSMessage(title, content, to);
        }
    }
}
