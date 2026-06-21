using DesignPatterns.CreationalPatterns.FactoryMethod.Solution;
using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Solution
{
    public static class SatisfactionSurveyService
    {
        public static async Task SendSatisfactionSurvey(MessageFactory messageFactory, string to)
        {
            WriteSeparator();

            string title = "Pesquisa de Satisfação";
            string content = "Por favor, avalie nosso serviço de 1 a 5.";

            await messageFactory.SendSatisfactionSurvey(title, content, to);
        }
    }
}
