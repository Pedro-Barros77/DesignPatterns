using DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators;
using Prototype.Problem;
using Prototype.Solution;
using static DesignPatterns.ConsoleUtils;

namespace ChainOfResponsibility
{
    public class ChainOfResponsibilityDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Enviar mensagens em um chat público de algum jogo ou plataforma.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored(new TextItem("O chat deve possuir várias regras e filtros como "), new("Validação de Formulário, Controle de Acesso, Proteção contra SPAM, Bloqueio de palavrões ou mensagens ofensivas, Sanitização de Contato externo, Execução de Comandos /command de moderadores.", ConsoleColor.Green, 1));
            WriteColored(new TextItem("Algumas regras quebram o fluxo e retornam erro, outras tratam a mensagem e continuam o fluxo.", 2));

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Um handler gigante contendo todas as regras de todos esses contextos.", 2);

            RequestInput();

            await Problem.MessagingService.HandleMessaging();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("Observamos que com apenas 1 handler central, o código fica muito extenso, complexo, acoplado e nada flexível. Não seria possível, por exemplo, deixar de validar "), new("Spam", ConsoleColor.Red), new(" somente para um usuário administrador específico.", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Chain of Responsibility)", ConsoleColor.White, 1));
            WriteColored(new TextItem("O padrão de design Chain of Responsibility sugere extrair cada tipo de validação para um "), new("Handler", ConsoleColor.Green), new(" separado, depois vincular esses handlers em uma corrente.", 1));
            WriteColored(new TextItem("O padrão declara em cada handler um campo para referenciar o próximo handler da corrente.", 1));
            WriteColored(new TextItem("Dessa forma, cada handler faz o seu trabalho e depois passa a requisição pro próximo handler até que todos da corrente tenham executado ou até que um deles quebre a corrente.", 1));
            WriteColored(new TextItem("Cada handler pode decidir se processa a requisição ou a mantém intocada e passa para frente, além de decidir se continua a corrente ou para todo o processamento.", 1));
            WriteColored(new("Para isso criamos a interface "), new("\"IHandler\"", ConsoleColor.Green), new(", que declara os métodos "), new("SetNext", ConsoleColor.Yellow), new(" e "), new("Handle", ConsoleColor.Yellow, 1));
            WriteColored(new("Opcionalmente, podemos ter um Handler base abstrato "), new("\"BaseHandler\"", ConsoleColor.Cyan), new(" contendo os comportamentos básicos de definir e executar o próximo handler.", 2));

            RequestInput();

            await Solution.MessagingService.HandleMessaging();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, garantimos o princípio de responsabilidade única. Cada handler tem o seu trabalho, sem misturar as regras e contextos. ", 1));
            WriteColored("Além disso, o fluxo de validação fica mais flexível e pode ser alterado em runtime, escolhendo quais validações realizar para cada usuário, contexto, ambiente, dispositivo, etc.", 1);
            WriteColored(new("Esse comportamento é bem parecido com o "), new("Decorator", ConsoleColor.Cyan), new(", a diferença é que o "), new("Decorator", ConsoleColor.Cyan), new(" extende o comportamento de um objeto, enquanto os handlers de "), new("CoR", ConsoleColor.Green), new(" executam operações arbitrárias de forma independente um do outro.", 1));
            WriteColored(new("Outra diferença é que o "), new("CoR", ConsoleColor.Green), new(" pode quebrar a corrente/fluxo a qualquer momento, já o "), new("Decorator", ConsoleColor.Cyan), new(" não pode impedir o fluxo original da solicitação.", 2));

            RequestInput();
        }
    }
}
