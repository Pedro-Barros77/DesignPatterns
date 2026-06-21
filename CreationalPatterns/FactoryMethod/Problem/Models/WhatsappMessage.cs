using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Problem.Models
{
    public enum WhatsappStatus
    {
        Draft = 0,
        Sent = 1,
        Received = 2,
        Seen = 3,
        Replied = 4
    }

    public class WhatsappMessage
    {
        public string Title { get; private set; }
        public string Message { get; private set; }
        public string Phone { get; private set; }
        public WhatsappStatus Status { get; private set; }
        public string? Response { get; private set; }

        public WhatsappMessage(string title, string message, string phone)
        {
            Title = title;
            Message = message;
            Phone = phone;
            Status = WhatsappStatus.Draft;
        }

        public async Task SendWhatsappMessage()
        {
            Status = WhatsappStatus.Sent;
            WriteColored(new("Enviando mensagem "), new("Whatsapp ", ConsoleColor.Green), new($"{Title}", ConsoleColor.White), new(" para "), new(Phone, ConsoleColor.White, 1));
            WriteColored("await _whatsappService.SendAsync(whatsappPayload)...", 2);
        }

        public void SetWhatsappMessageReceived()
        {
            Status = WhatsappStatus.Received;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" recebida por "), new(Phone, ConsoleColor.White, 1));
            WriteColored("event: WhatsappDeliveryConfirmationEvent...", 2);
        }

        public void SetWhatsappMessageSeen()
        {
            Status = WhatsappStatus.Seen;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" visualizada por "), new(Phone, ConsoleColor.White, 1));
            WriteColored("event: WhatsappReadReceiptEvent...", 2);
        }

        public void SetWhatsappMessageReplied(string response)
        {
            Status = WhatsappStatus.Replied;
            Response = response;
            WriteColored(new("Mensagem "), new("Whatsapp", ConsoleColor.Green), new(" respondida por "), new(Phone, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored("event: WhatsappReplyEvent...", 2);
        }
    }
}
