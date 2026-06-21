using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Solution.Products
{
    //Concrete product
    public class WhatsappMessage: IMessage, IReadReceiptTrackable
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string To { get; private set; }
        public MessageStatus Status { get; private set; }
        public string? Response { get; private set; }

        public WhatsappMessage(string title, string message, string phone)
        {
            Title = title;
            Content = message;
            To = phone;
            Status = MessageStatus.Draft;
        }

        public async Task Send()
        {
            Status = MessageStatus.Sent;
            WriteColored(new("Enviando mensagem "), new("Whatsapp ", ConsoleColor.Green), new($"{Title}", ConsoleColor.White), new(" para "), new(To, ConsoleColor.White, 1));
            WriteColored("await _whatsappService.SendAsync(whatsappPayload)...", 2);
        }

        public void SetReceived()
        {
            Status = MessageStatus.Received;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" recebida por "), new(To, ConsoleColor.White, 1));
            WriteColored("event: WhatsappDeliveryConfirmationEvent...", 2);
        }

        public void SetSeen()
        {
            Status = MessageStatus.Seen;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" visualizada por "), new(To, ConsoleColor.White, 1));
            WriteColored("event: WhatsappReadReceiptEvent...", 2);
        }

        public void SetReplied(string response)
        {
            Status = MessageStatus.Replied;
            Response = response;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" respondida por "), new(To, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored("event: WhatsappReplyEvent...", 2);
        }

        public TextItem Name()
        {
            return new("Whatsapp", ConsoleColor.Green);
        }
    }
}
