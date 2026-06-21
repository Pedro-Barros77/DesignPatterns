using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Solution.Products
{
    //Concrete product
    public class SMSMessage : IMessage
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string To { get; private set; }
        public MessageStatus Status { get; private set; }
        public string? Response { get; private set; }

        public SMSMessage(string title, string message, string phone)
        {
            Title = title;
            Content = message;
            To = phone;
            Status = MessageStatus.Draft;
        }

        public async Task Send()
        {
            Status = MessageStatus.Sent;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" para "), new(To, ConsoleColor.White, 1));
            WriteColored($"await _smsService.SendAsync(smsPayload)...", 2);
        }

        public void SetReceived()
        {
            Status = MessageStatus.Received;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" recebida por "), new(To, ConsoleColor.White, 1));
            WriteColored($"event: SMSDeliveryConfirmationEvent...", 2);
        }

        // Note: Mensagens SMS não possuem confirmação de visualização.

        public void SetReplied(string response)
        {
            Status = MessageStatus.Replied;
            Response = response;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" respondida por "), new(To, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored($"event: SMSReplyEvent...", 2);
        }

        public TextItem Name()
        {
            return new("SMS", ConsoleColor.Cyan);
        }
    }
}
