using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Solution.Models
{
    public class SendMessageResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = [];

        public SendMessageResponse(bool success)
        {
            IsSuccess = success;
        }
        public SendMessageResponse(bool success, List<string> messages)
        {
            IsSuccess = success;
            Messages = messages;
        }

        public static SendMessageResponse Success() => new(true);
        public static SendMessageResponse Fail(string message) => new(false, [message]);
        public static SendMessageResponse Fail() => new(false, []);
    }
}
