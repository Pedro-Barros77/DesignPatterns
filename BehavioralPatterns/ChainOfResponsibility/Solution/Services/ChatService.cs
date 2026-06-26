using ChainOfResponsibility.Solution.Models;
using static DesignPatterns.ConsoleUtils;

namespace ChainOfResponsibility.Solution.Services
{
    public static class ChatService
    {
        public const string BAN_WARNING = "Se esse comportamento continuar, você poderá ser banido do chat.";
        public static List<(Guid UserId, string Message)> MessagesCache { get; set; } = [];

        private static bool IsChatActive = true;

        public static async Task<bool> LockChat()
        {
            await Task.Delay(100);
            
            bool wasChatActive = IsChatActive;
            IsChatActive = false;

            return wasChatActive;
        }

        public static async Task<bool> UnLockChat()
        {
            await Task.Delay(100);

            bool wasChatActive = IsChatActive;
            IsChatActive = true;

            return !wasChatActive;
        }

        public static async Task<bool> SendMessage(User user, string message)
        {
            await Task.Delay(100);

            if(!IsChatActive && !user.IsModerator)
            {
                WriteColored(new TextItem("Chat bloqueado, apenas moderadores podem enviar mensagens", ConsoleColor.DarkRed, 1));
                return false;
            }

            WriteColored(new TextItem($"[{user.Name}]: "), new(message, ConsoleColor.White, 1));

            return true;
        }
    }
}
