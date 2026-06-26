using ChainOfResponsibility.Problem.Models;
using static DesignPatterns.ConsoleUtils;

namespace ChainOfResponsibility.Problem
{
    public static class MessagingService
    {
        private static readonly Guid DavidId = new("0A2A2FF2-B055-4608-9B41-32BCCA2907A4");
        private static readonly Guid ModeratorId = new("63065E30-94AE-4CCD-9FD6-123E6E02BEA3");
        public static async Task HandleMessaging()
        {
            WriteSeparator();

            var handler = new SendMessageHandler();

            await SendFormValidationTests(handler);
            await SendAccessValidationTests(handler);
            await SendSpamValidationTests(handler);
            await SendBannedWordValidationTests(handler);
            await SendContactValidationTests(handler);
            await SendModeratorCommandTests(handler);

            await Send(new(DavidId, "Mensagem com sucesso!"), handler);

            WriteColored("", 1);
        }

        private static async Task Send(SendMessageRequest request, SendMessageHandler handler)
        {
            var result = await handler.Execute(request);
            if (!result.IsSuccess && result.Messages.Count > 0)
                WriteColored(new TextItem("Erro: ", ConsoleColor.DarkGray), new(string.Join("\n", result.Messages), ConsoleColor.Red, 1));
            WriteColored("", 1);
        }

        private static async Task SendFormValidationTests(SendMessageHandler handler)
        {
            WriteColored(new TextItem("* Enviando mensagem vazia...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, ""), handler);

            WriteColored(new TextItem("* Enviando mensagem muito grande...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa."), handler);

            WriteColored(new TextItem("* Enviando mensagem sem id do usuário...", ConsoleColor.DarkGray, 1));
            await Send(new(Guid.Empty, "Hello, World!"), handler);
        }

        private static async Task SendAccessValidationTests(SendMessageHandler handler)
        {
            WriteColored(new TextItem("* Enviando mensagem com usuário inexistente...", ConsoleColor.DarkGray, 1));
            await Send(new(new Guid("935D0420-AF81-4BF9-9624-DFFF07CC60B6"), "Hello, World!"), handler);

            WriteColored(new TextItem("* Enviando mensagem com usuário sem idade suficiente...", ConsoleColor.DarkGray, 1));
            await Send(new(new Guid("E2E651BF-3245-4844-BECC-40F852E4DC57"), "Hello, World!"), handler);

            WriteColored(new TextItem("* Enviando mensagem com usuário bloqueado...", ConsoleColor.DarkGray, 1));
            await Send(new(new Guid("66F88FD6-9611-45C7-ACFB-B6991978C1FF"), "Hello, World!"), handler);
        }

        private static async Task SendSpamValidationTests(SendMessageHandler handler)
        {
            WriteColored("", 1);
            WriteColored(new TextItem("* Enviando spam 5x...", ConsoleColor.DarkGray, 1));
            for (int i = 1; i <= 5; i++)
            {
                WriteColored(new TextItem($"* {i}/5", ConsoleColor.DarkGray, 1));
                await Send(new(DavidId, "ACHEI FÁCIL"), handler);
            }
        }

        private static async Task SendBannedWordValidationTests(SendMessageHandler handler)
        {
            WriteColored(new TextItem("* Enviando mensagem com ofensa \"idiota\"...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, $"Você é um IDIOTA!"), handler);
        }

        private static async Task SendContactValidationTests(SendMessageHandler handler)
        {
            WriteColored(new TextItem("* Enviando mensagem contato...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, $"Me chama no whatsapp 31 91234-5678, ou manda email no david@gmail.com ou entra no meu site: https://david-website.com"), handler);
        }

        private static async Task SendModeratorCommandTests(SendMessageHandler handler)
        {
            WriteColored(new TextItem("* Enviando comando de usuário comum...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, $"/list"), handler);

            WriteColored(new TextItem("* Enviando comando /list...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/list"), handler);

            WriteColored(new TextItem("* Enviando comando /tell...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/tell {DavidId} Olá!"), handler);

            WriteColored(new TextItem("* Enviando mensagem de David antes do ban...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, "Hello, World!"), handler);

            WriteColored(new TextItem("* Enviando comando /ban david...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/ban {DavidId}"), handler);

            WriteColored(new TextItem("* Enviando mensagem de David após o ban...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, "Hello, World!"), handler);

            WriteColored(new TextItem("* Enviando comando /unban david...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/unban {DavidId}"), handler);

            WriteColored(new TextItem("* Enviando comando /lockc...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/lockc"), handler);

            WriteColored(new TextItem("* Enviando mensagem de David com chat bloqueado...", ConsoleColor.DarkGray, 1));
            await Send(new(DavidId, "Hello, World!"), handler);

            WriteColored(new TextItem("* Enviando mensagem de moderador com chat bloqueado...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"Pessoal, peço que não poluam o chat."), handler);

            WriteColored(new TextItem("* Enviando comando /unlockc...", ConsoleColor.DarkGray, 1));
            await Send(new(ModeratorId, $"/unlockc"), handler);
        }
    }
}
