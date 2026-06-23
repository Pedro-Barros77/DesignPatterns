using DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators;
using Prototype.Problem;
using Prototype.Solution;
using static DesignPatterns.ConsoleUtils;

namespace Prototype
{
    public class PrototypeDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Clonar completamente um objeto existente.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored("Um objeto pode ter propriedades privadas, impossibilitando a clonagem por fora, comportamentos exclusivos e lógica complexa.", 1);
            WriteColored("Se o cliente precisar conhecer cada objeto que precisa clonar, o código pode ficar acoplado e desnecessariamente poluído.", 1);
            WriteColored("Se o cliente conhecer apenas a interface ou versão abstrata do objeto, não vai ter acesso a todas as propriedades do objeto concreto.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Tentativa de clonar um objeto manualmente por fora:", 2);

            RequestInput();

            await Problem.ObjectClonerService.CloneObjects();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("Observamos que há muitas limitações para clonar um objeto por fora dele, como "), new("Propriedades Privadas", ConsoleColor.Red), new(", "), new("Interfaces abstratas", ConsoleColor.Red), new(" e "), new("Acoplamento do tipo do objeto ao cliente", ConsoleColor.Red), new(".", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Prototype)", ConsoleColor.White, 1));
            WriteColored("O padrão de design Prototype sugere delegar o processo de clonagem ao próprio objeto sendo clonado.", 1);
            WriteColored("O padrão declara uma interface comum para todos os objetos que suportam clonagem, geralmente com um único método ");
            WriteColored(new TextItem("Clone()", ConsoleColor.Yellow), new(".", 1));
            WriteColored(new TextItem("Dessa forma, o cliente não fica acoplado ao tipo do objeto e, com o objeto se auto clonando, ele conhece e tem acesso a todas as propriedades privadas.", 1));
            WriteColored(new("Objetos que suportam clonagem são chamados de "), new("\"Prototypes\"", ConsoleColor.White), new(".", 1));

            RequestInput();

            await Solution.ObjectClonerService.CloneObjects();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, o objeto é devidamente clonado, sem acoplar ao tipo e sem se preocupar com propriedades privadas nem interface genérica. ", 1));
            WriteColored("Observamos que o Id/Hash do objeto é diferente, o que mostra que não é uma cópia por referência, e que todos os outros campos são devidamente copiados, mesmo os gerados aleatoriamente no construtor.", 1);
            WriteColored(new("A interface "), new("IPrototype", ConsoleColor.Green), new(" garante que seja qual for a classe implementadora, o contrato sempre incluirá um método "), new("Clone()", ConsoleColor.Yellow), new(".", 1));

            RequestInput();
        }
    }
}
