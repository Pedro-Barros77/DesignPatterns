using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Problem.Models
{
    public enum EmailStatus
    {
        Draft = 0,
        Sent = 1,
        Received = 2,
        Seen = 3,
        Replied = 4
    }

    public class EmailMessage
    {
        public string Subject { get; private set; }
        public string Content { get; private set; }
        public string To { get; private set; }
        public EmailStatus Status { get; private set; }
        public string? Response { get; private set; }

        public EmailMessage(string subject, string content, string to)
        {
            Subject = subject;
            Content = content;
            To = to;
            Status = EmailStatus.Draft;
        }

        public async Task SendEmail()
        {
            Status = EmailStatus.Sent;
            WriteColored(new("Enviando "), new("email ", ConsoleColor.Yellow), new($"{Subject}", ConsoleColor.White), new(" para "), new(To, ConsoleColor.White, 1));
            WriteColored("await _emailService.SendAsync(emailPayload)...", 2);
        }

        public void SetEmailReceived()
        {
            Status = EmailStatus.Received;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" recebido por "), new(To, ConsoleColor.White, 1));
            WriteColored($"event: EmailDeliveryConfirmationEvent...", 2);
        }

        public void SetEmailSeen()
        {
            Status = EmailStatus.Seen;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" visualizado por "), new(To, ConsoleColor.White, 1));
            WriteColored($"event: EmailReadReceiptEvent...", 2);
        }

        public void SetEmailReplied(string response)
        {
            Status = EmailStatus.Replied;
            Response = response;
            WriteColored(new("Email", ConsoleColor.Yellow), new(" respondido por "), new(To, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored($"event: EmailReplyEvent...", 2);
        }
    }
}
