using ChainOfResponsibility.Solution.Models;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Solution.Handlers
{
    public class MessageContactValidationHandler : BaseHandler<SendMessageRequest, SendMessageResponse>
    {
        public override async Task<SendMessageResponse> Handle(SendMessageRequest request)
        {
            //Email
            request.Message = Regex.Replace(request.Message, @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b", "***");
            //Link
            request.Message = Regex.Replace(request.Message, @"\b(?:https?:\/\/|www\.)\S+\b", "***");
            //Telefone
            request.Message = Regex.Replace(request.Message, @"\b(?:\+55\s?)?(?:\(?\d{2}\)?\s?)?(?:9\s?)?\d{4}[-\s]?\d{4}\b", "***");

            return await base.Handle(request);
        }
    }
}
