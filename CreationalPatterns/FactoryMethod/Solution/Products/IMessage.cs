using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Solution.Products
{
    public enum MessageStatus
    {
        Draft = 0,
        Sent = 1,
        Received = 2,
        Seen = 3,
        Replied = 4
    }

    //Product
    public interface IMessage
    {
        public string Title { get; }
        public string Content { get; }
        public string To { get; }
        public MessageStatus Status { get; }
        public string? Response { get; }

        public Task Send();
        public void SetReceived();
        public void SetReplied(string response);
        public TextItem Name();
    }
}
