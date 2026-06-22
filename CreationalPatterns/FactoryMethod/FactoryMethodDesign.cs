using DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators;
using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod
{
    public record User(string email, string phone);
    public class FactoryMethodDesign
    {
        private User RequestUser { get; set; } = new User("usuario@gmail.com", "(31)91234-5678");

        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Enviar para o cliente uma pesquisa de satisfação e obter resposta de 1 a 5.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored("Existem 3 meios de envio dependendo da preferência do cliente: ");
            WriteColored(new("Email", ConsoleColor.Yellow), new(", "), new("Whatsapp", ConsoleColor.Green), new(" ou "), new("SMS", ConsoleColor.Cyan), new(".", 1));
            WriteColored("Cada um utiliza um serviço/api/integração diferente.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Uma classe para cada meio de envio e um switch no código do serviço contendo a lógica para cada opção:", 2);

            RequestInput();

            //If user chooses Email
            await Problem.SatisfactionSurveyService.SendSatisfactionSurvey(Problem.PreferredMessageType.Email, RequestUser);
            //If user chooses Whatsapp
            await Problem.SatisfactionSurveyService.SendSatisfactionSurvey(Problem.PreferredMessageType.Whatsapp, RequestUser);
            //If user chooses SMS
            await Problem.SatisfactionSurveyService.SendSatisfactionSurvey(Problem.PreferredMessageType.SMS, RequestUser);

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("Observamos que há muita repetição de código, e se um dia for necessário adicionar uma nova opção, como "), new("Notificação Push", ConsoleColor.Blue), new(", toda a estrutura de envio seria repetida, acoplando mais regra ao "), new("SatisfactionSurveyService", ConsoleColor.White), new(".", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Factory Method)", ConsoleColor.White, 1));
            WriteColored("O padrão de design Factory Method sugere substituir a chamada ao construtor ");
            WriteColored(new TextItem("new", ConsoleColor.Blue), new TextItem("()", ConsoleColor.White));
            WriteColored(new(" por um método especial em uma classe "), new("\"Factory\"", ConsoleColor.White), new(".", 1));
            WriteColored(new("Objetos retornados por essa fábrica são chamados de "), new("\"Products\"", ConsoleColor.White), new(".", 1));
            WriteColored("Dessa forma, fábricas filhas podem sobrescrever esse método e retornar seu próprio tipo de produto, seja ele ");
            WriteColored(new("Email", ConsoleColor.Yellow), new(", "), new("Whatsapp", ConsoleColor.Green), new(" ou "), new("SMS", ConsoleColor.Cyan), new(".", 1));
            WriteColored("Para isso, todas as classes de produtos devem ter em comum uma classe pai ou uma interface, para que a fábrica pai possa retornar esse tipo.", 2);
            WriteColored(new("Nesse exemplo, vamos utilizar uma interface "), new("IMessage", ConsoleColor.Green), new(".", 2));

            RequestInput();

            //If user chooses Email
            var emailFactory = new EmailMessageFactory();
            await Solution.SatisfactionSurveyService.SendSatisfactionSurvey(emailFactory, RequestUser.email);

            //If user chooses Whatsapp
            var whatsappFactory = new WhatsappMessageFactory();
            await Solution.SatisfactionSurveyService.SendSatisfactionSurvey(whatsappFactory, RequestUser.phone);

            //If user chooses SMS
            var smsFactory = new SmsMessageFactory();
            await Solution.SatisfactionSurveyService.SendSatisfactionSurvey(smsFactory, RequestUser.phone);

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("Dessa forma, não há repetição de fluxo, pois toda a regra fica concentrada em "), new("MessageFactory", ConsoleColor.White), new(".", 2));
            WriteColored("Não importa para o negócio como a mensagem é enviada ou respondida, desde que o fluxo seja completado e a resposta chegue.", 1);
            WriteColored(new("A interface "), new("IMessage", ConsoleColor.Green), new(" garante que seja qual for o meio escolhido, o contrato será o mesmo, mas da liberdade para cada implementação produzir comportamentos exclusivos.", 1));
            WriteColored(new("Observe que nem o "), new("SatisfactionSurveyService", ConsoleColor.White), new(" e nem o "), new("MessageFactory", ConsoleColor.White), new(" conhecem o tipo da mensagem, mas fazem o seu trabalho de a entregar e receber sua resposta", 2));

            RequestInput();
        }
    }
}
