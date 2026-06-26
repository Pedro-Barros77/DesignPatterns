using ChainOfResponsibility.Solution.Models;
using ChainOfResponsibility.Solution.Services;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageAccessValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        private const int MIN_AGE = 14;

        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            User? user = await UserService.GetByIdAsync(request.UserId);
            if (user is null)
                return SendMessageResponse.Fail("Usuário não encontrado.");

            if (user.Age < MIN_AGE)
                return SendMessageResponse.Fail("Usuário não possui idade adequada para enviar mensagens.");

            if (!user.IsActive)
                return SendMessageResponse.Fail("Usuário bloqueado.");

            return await base.Handle(request);
        }
    }
}
