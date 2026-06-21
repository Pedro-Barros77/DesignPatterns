using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Problem.Models
{
    public enum SMSStatus
    {
        Draft = 0,
        Sent = 1,
        Received = 2,
        Replied = 4
    }

    public class SMSMessage
    {
        public string Title { get; private set; }
        public string Message { get; private set; }
        public string Phone { get; private set; }
        public SMSStatus Status { get; private set; }
        public string? Response { get; private set; }

        public SMSMessage(string title, string message, string phone)
        {
            Title = title;
            Message = message;
            Phone = phone;
            Status = SMSStatus.Draft;
        }

        public async Task SendSMSMessage()
        {
            Status = SMSStatus.Sent;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" para "), new(Phone, ConsoleColor.White, 1));
            WriteColored($"await _smsService.SendAsync(smsPayload)...", 2);
        }

        public void SetSMSMessageReceived()
        {
            Status = SMSStatus.Received;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" recebida por "), new(Phone, ConsoleColor.White, 1));
            WriteColored($"event: SMSDeliveryConfirmationEvent...", 2);
        }

        public void SetSMSMessageReplied(string response)
        {
            Status = SMSStatus.Replied;
            Response = response;
            WriteColored(new("Enviando mensagem "), new("SMS", ConsoleColor.Cyan), new(" respondida por "), new(Phone, ConsoleColor.White, 1));
            WriteColored([new("Resposta: "), new(Response, ConsoleColor.White, 1)]);
            WriteColored($"event: SMSReplyEvent...", 2);
        }
    }
}
