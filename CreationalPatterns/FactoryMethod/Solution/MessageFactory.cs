using FactoryMethod;
using FactoryMethod.Solution.Products;
using static DesignPatterns.ConsoleUtils;

namespace DesignPatterns.CreationalPatterns.FactoryMethod.Solution
{
    //Creator
    public abstract class MessageFactory
    {
        //Factory Method
        protected abstract IMessage Create(string title, string content, string to);
        public async Task SendSatisfactionSurvey(string title, string content, string to)
        {
            var message = Create(title, content, to);

            WriteColored(new("Iniciando pesquisa de satisfação via "), message.Name(), new("", 2));

            //Observe que a fábrica pai não conhece o tipo específico de mensagem, mas ainda é capaz de enviar a pesquisa de satisfação usando a interface IMessage.
            await message.Send();

            await Task.Delay(1000);
            message.SetReceived();

            if (message is IReadReceiptTrackable readTrackable)
            {
                await Task.Delay(2000);
                readTrackable.SetSeen();
            }

            await Task.Delay(2000);
            message.SetReplied("1");
        }
    }
}
