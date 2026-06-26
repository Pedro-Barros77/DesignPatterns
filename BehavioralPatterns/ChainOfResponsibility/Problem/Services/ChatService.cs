using ChainOfResponsibility.Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace ChainOfResponsibility.Problem.Services
{
    public static class ChatService
    {
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
