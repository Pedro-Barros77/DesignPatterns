using ChainOfResponsibility.Solution.Models;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageFormValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        private const int MAX_MESSAGE_LENGTH = 200;

        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Message))
                return SendMessageResponse.Fail("O campo \"Mensagem\" é obrigatório.");

            if (request.Message.Length > MAX_MESSAGE_LENGTH)
                return SendMessageResponse.Fail($"O campo \"Mensagem\" não pode ter mais que {MAX_MESSAGE_LENGTH} caracteres.");

            if (request.UserId == Guid.Empty)
                return SendMessageResponse.Fail("O campo \"Id do Usuário\" é obrigatório.");

            return await base.Handle(request);
        }
    }
}
