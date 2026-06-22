using AbstractFactory;
using Builder;
using FactoryMethod;
using static DesignPatterns.ConsoleUtils;

namespace DesignPatterns
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WriteColored("Inicializando...", 2);

            //var factoryDesign = new FactoryMethodDesign();
            //factoryDesign.Describe();
            //await factoryDesign.RunProblem();
            //await factoryDesign.RunSolution();

            //var abstractFactoryDesign = new AbstractFactoryDesign();
            //abstractFactoryDesign.Describe();
            //await abstractFactoryDesign.RunProblem();
            //await abstractFactoryDesign.RunSolution();

            var builderDesign = new BuilderDesign();
            builderDesign.Describe();
            await builderDesign.RunProblem();
            await builderDesign.RunSolution();
        }
    }
}
