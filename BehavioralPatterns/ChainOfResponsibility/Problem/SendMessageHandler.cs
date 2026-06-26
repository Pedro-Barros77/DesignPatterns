using ChainOfResponsibility.Problem.Models;
using ChainOfResponsibility.Problem.Services;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Problem
{
    public class SendMessageHandler
    {
        private const int MAX_MESSAGE_LENGTH = 200;
        private const int MIN_AGE = 14;
        private const int MAX_REPEATED_MESSAGES = 3;
        private const string BAN_WARNING = "Se esse comportamento continuar, você poderá ser banido do chat.";

        private List<(Guid UserId, string Message)> MessagesCache = [];

        public async Task<SendMessageResponse> Execute(SendMessageRequest request)
        {
            //Validação de Formulário

            if (request == null || string.IsNullOrEmpty(request.Message))
                return SendMessageResponse.Fail("O campo \"Mensagem\" é obrigatório.");

            if (request.Message.Length > MAX_MESSAGE_LENGTH)
                return SendMessageResponse.Fail($"O campo \"Mensagem\" não pode ter mais que {MAX_MESSAGE_LENGTH} caracteres.");

            if (request.UserId == Guid.Empty)
                return SendMessageResponse.Fail("O campo \"Id do Usuário\" é obrigatório.");

            //Validação de acesso

            User? user = await UserService.GetByIdAsync(request.UserId);
            if (user is null)
                return SendMessageResponse.Fail("Usuário não encontrado.");

            if (user.Age < MIN_AGE)
                return SendMessageResponse.Fail("Usuário não possui idade adequada para enviar mensagens.");

            if (!user.IsActive)
                return SendMessageResponse.Fail("Usuário bloqueado.");

            //Validação de SPAM

            var lastMessages = MessagesCache
                .Where(x => x.UserId == request.UserId)
                .TakeLast(MAX_REPEATED_MESSAGES);

            bool isMessageSpam = lastMessages.Count() == MAX_REPEATED_MESSAGES &&
                lastMessages.All(x => x.Message.Equals(request.Message, StringComparison.InvariantCultureIgnoreCase));

            if (isMessageSpam)
                return SendMessageResponse.Fail("Muitas mensagens repetidas, aguarde alguns segundos. " + BAN_WARNING);

            //Validação de palavrões

            if (await BannedWordsService.ContainsBannedWord(request.Message))
                return SendMessageResponse.Fail("Mensagem com conteúdo ofensivo. " + BAN_WARNING);

            //Validação de contato

            //Email
            request.Message = Regex.Replace(request.Message, @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b", "***");
            //Link
            request.Message = Regex.Replace(request.Message, @"\b(?:https?:\/\/|www\.)\S+\b", "***");
            //Telefone
            request.Message = Regex.Replace(request.Message, @"\b(?:\+55\s?)?(?:\(?\d{2}\)?\s?)?(?:9\s?)?\d{4}[-\s]?\d{4}\b", "***");

            //Tratamento de comandos de moderador

            if (user.IsModerator && request.Message.StartsWith('/'))
            {
                if (await ModeratorCommandService.HandleCommand(request.Message))
                    return SendMessageResponse.Success();
            }

            //Envio de mensagem final

            await ChatService.SendMessage(user, request.Message);

            MessagesCache.Add((user.Id, request.Message));

            return SendMessageResponse.Success();
        }
    }
}
