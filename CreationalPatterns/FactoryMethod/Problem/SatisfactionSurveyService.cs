using FactoryMethod.Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace FactoryMethod.Problem
{
    public enum PreferredMessageType
    {
        Email = 1,
        Whatsapp = 2,
        SMS = 3
    }

    public static class SatisfactionSurveyService
    {
        public static async Task SendSatisfactionSurvey(PreferredMessageType preferredMessageType, User user)
        {
            string title = "Pesquisa de Satisfação";
            string content = "Por favor, avalie nosso serviço de 1 a 5.";

            WriteSeparator();

            switch (preferredMessageType)
            {
                case PreferredMessageType.Email:
                    WriteColored([new("Iniciando pesquisa de satisfação via "), new("Email", ConsoleColor.Yellow, 2)]);
                    await SendEmailSurvey(title, content, user.email);
                    break;
                case PreferredMessageType.Whatsapp:
                    WriteColored([new("Iniciando pesquisa de satisfação via "), new("Whatsapp", ConsoleColor.Green, 2)]);
                    await SendWhatsappSurvey(title, content, user.phone);
                    break;
                case PreferredMessageType.SMS:
                    WriteColored([new("Iniciando pesquisa de satisfação via "), new("SMS", ConsoleColor.Cyan, 2)]);
                    await SendSMSSurvey(title, content, user.phone);
                    break;
                default:
                    Console.WriteLine("Tipo de mensagem preferida inválida.");
                    break;
            }
        }

        private static async Task SendEmailSurvey(string title, string content, string email)
        {
            var emailMessage = new Problem.Models.EmailMessage(title, content, email);
            await emailMessage.SendEmail();

            await Task.Delay(1000);
            emailMessage.SetEmailReceived();

            await Task.Delay(2000);
            emailMessage.SetEmailSeen();

            await Task.Delay(2000);
            emailMessage.SetEmailReplied("1");
        }

        private static async Task SendWhatsappSurvey(string title, string content, string phone)
        {
            var whatsappMessage = new Problem.Models.WhatsappMessage(title, content, phone);
            await whatsappMessage.SendWhatsappMessage();

            await Task.Delay(1000);
            whatsappMessage.SetWhatsappMessageReceived();

            await Task.Delay(2000);
            whatsappMessage.SetWhatsappMessageSeen();

            await Task.Delay(2000);
            whatsappMessage.SetWhatsappMessageReplied("2");
        }

        private static async Task SendSMSSurvey(string title, string content, string phone)
        {
            var smsMessage = new Problem.Models.SMSMessage(title, content, phone);
            await smsMessage.SendSMSMessage();

            await Task.Delay(1000);
            smsMessage.SetSMSMessageReceived();

            await Task.Delay(2000);
            smsMessage.SetSMSMessageReplied("3");
        }
    }
}
