using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Problem.Models
{
    public class SendMessageRequest
    {
        public readonly Guid UserId;
        public string Message { get; set; }

        public SendMessageRequest(Guid userId, string message)
        {
            UserId = userId;
            Message = message;
        }
    }
}
