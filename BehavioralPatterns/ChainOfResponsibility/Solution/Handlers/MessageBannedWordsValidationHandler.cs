using ChainOfResponsibility.Solution.Models;
using ChainOfResponsibility.Solution.Services;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageBannedWordsValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            if (await BannedWordsService.ContainsBannedWord(request.Message))
                return SendMessageResponse.Fail("Mensagem com conteúdo ofensivo. " + ChatService.BAN_WARNING);

            return await base.Handle(request);
        }
    }
}
