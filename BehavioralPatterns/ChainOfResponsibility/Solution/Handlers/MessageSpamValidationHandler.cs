using ChainOfResponsibility.Solution.Models;
using ChainOfResponsibility.Solution.Services;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageSpamValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        private const int MAX_REPEATED_MESSAGES = 3;

        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            var lastMessages = ChatService.MessagesCache
                .Where(x => x.UserId == request.UserId)
                .TakeLast(MAX_REPEATED_MESSAGES);

            bool isMessageSpam = lastMessages.Count() == MAX_REPEATED_MESSAGES &&
                lastMessages.All(x => x.Message.Equals(request.Message, StringComparison.InvariantCultureIgnoreCase));

            if (isMessageSpam)
                return SendMessageResponse.Fail("Muitas mensagens repetidas, aguarde alguns segundos. " + ChatService.BAN_WARNING);

            return await base.Handle(request);
        }
    }
}
