using static DesignPatterns.ConsoleUtils;

namespace ChainOfResponsibility.Solution.Services
{
    public static class ModeratorCommandService
    {
        private static readonly List<string> Commands =
        [
            "/list", "/tell", "/ban", "/unban", "/lockc", "/unlockc"
        ];
        public static async Task<bool> HandleCommand(string text)
        {
            if (!Commands.Any(c => text.StartsWith(c, StringComparison.InvariantCultureIgnoreCase)))
                return false;

            string command = text.ToLower().Trim();
            List<string> commandParams = command.Split(" ").ToList();

            await Task.Delay(100);

            switch (commandParams[0])
            {
                case "/list":
                    return await HandleList();

                case "/tell":
                    return await HandleTell(commandParams);

                case "/ban":
                    return await HandleBan(commandParams, true);

                case "/unban":
                    return await HandleBan(commandParams, false);

                case "/lockc":
                    return await HandleLockChat(true);

                case "/unlockc":
                    return await HandleLockChat(false);
            }

            return false;
        }

        private static async Task<bool> HandleList()
        {
            var users = await UserService.ListAsync();
            WriteColored(new TextItem("Command /list: ", ConsoleColor.Magenta), new TextItem(string.Join(", ", users.Select(x => $"{x.Name} ({x.Id})")), 1));
            return true;
        }

        private static async Task<bool> HandleTell(List<string> commandParams)
        {
            if (commandParams.Count < 3)
                return false;

            WriteColored(new TextItem("Command /tell: ", ConsoleColor.Magenta), new("Enviando mensagem privada para "), new(commandParams[1], ConsoleColor.White), new(": "), new(commandParams[2], 1));
            return true;
        }

        private static async Task<bool> HandleBan(List<string> commandParams, bool ban)
        {
            if (commandParams.Count < 2)
                return false;

            if (!Guid.TryParse(commandParams[1], out var id))
                return false;

            if (!await UserService.BanUser(id, ban))
                return false;

            WriteColored(new TextItem($"Command /{(ban ? "" : "un")}ban: ", ConsoleColor.Magenta), new($"{(ban ? "Banindo" : "Reativando")} usuário "), new($"{id}", ConsoleColor.White, 1));
            return true;
        }

        private static async Task<bool> HandleLockChat(bool locked)
        {
            if (!(locked ? await ChatService.LockChat() : await ChatService.UnLockChat()))
                return false;

            WriteColored(new TextItem($"Command /{(locked ? "" : "un")}lockc: ", ConsoleColor.Magenta), new($"{(locked ? "Travando" : "Destravando")} chat", 1));
            return true;
        }
    }
}
