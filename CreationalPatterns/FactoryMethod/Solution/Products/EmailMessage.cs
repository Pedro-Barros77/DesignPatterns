using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Solution.Products
{
    //Concrete product
    public class EmailMessage : IMessage, IReadReceiptTrackable
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string To { get; private set; }
        public MessageStatus Status { get; private set; }
        public string? Response { get; private set; }

        public EmailMessage(string title, string content, string to)
        {
            Title = title;
            Content = content;
            To = to;
            Status = MessageStatus.Draft;
        }

        public async Task Send()
        {
            Status = MessageStatus.Sent;
            WriteColored(new("Enviando "), new("email ", ConsoleColor.Yellow), new($"{Title}", ConsoleColor.White), new(" para "), new(To, ConsoleColor.White, 1));
            WriteColored("await _emailService.SendAsync(emailPayload)...", 2);
        }

        public void SetReceived()
        {
            Status = MessageStatus.Received;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" recebido por "), new(To, ConsoleColor.White, 1));
            WriteColored($"event: EmailDeliveryConfirmationEvent...", 2);
        }

        public void SetSeen()
        {
            Status = MessageStatus.Seen;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" visualizado por "), new(To, ConsoleColor.White, 1));
            WriteColored($"event: EmailReadReceiptEvent...", 2);
        }

        public void SetReplied(string response)
        {
            Status = MessageStatus.Replied;
            Response = response;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" respondido por "), new(To, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored($"event: EmailReplyEvent...", 2);
        }

        public TextItem Name()
        {
            return new("Email", ConsoleColor.Yellow);
        }
    }
}
