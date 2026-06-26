using ChainOfResponsibility.Solution.Models;
using ChainOfResponsibility.Solution.Services;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageSentHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            User? user = await UserService.GetByIdAsync(request.UserId);
            if (user is null)
                return SendMessageResponse.Fail("Usuário não encontrado.");

            if(!await ChatService.SendMessage(user, request.Message))
                return SendMessageResponse.Fail();

            ChatService.MessagesCache.Add((user.Id, request.Message));

            return SendMessageResponse.Success();
        }
    }
}
