using FactoryMethod;
using static DesignPatterns.ConsoleUtils;

namespace DesignPatterns
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WriteColored("Inicializando...", 2);

            var factorDesign = new FactoryMethodDesign();
            factorDesign.Describe();
            await factorDesign.RunProblem();
            await factorDesign.RunSolution();
        }
    }
}
