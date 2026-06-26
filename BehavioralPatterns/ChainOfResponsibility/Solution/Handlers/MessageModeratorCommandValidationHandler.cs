using ChainOfResponsibility.Solution.Models;
using ChainOfResponsibility.Solution.Services;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageModeratorCommandValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            User? user = await UserService.GetByIdAsync(request.UserId);
            if (user is null)
                return SendMessageResponse.Fail("Usuário não encontrado.");

            if (user.IsModerator && request.Message.StartsWith('/'))
            {
                if (await ModeratorCommandService.HandleCommand(request.Message))
                    return SendMessageResponse.Success();
            }

            return await base.Handle(request);
        }
    }
}
