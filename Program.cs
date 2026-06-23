using static DesignPatterns.ConsoleUtils;

namespace DesignPatterns
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WriteColored("Inicializando...", 2);

            //Creational Patterns

            //var factoryDesign = new FactoryMethodDesign();
            //factoryDesign.Describe();
            //await factoryDesign.RunProblem();
            //await factoryDesign.RunSolution();

            //var abstractFactoryDesign = new AbstractFactoryDesign();
            //abstractFactoryDesign.Describe();
            //await abstractFactoryDesign.RunProblem();
            //await abstractFactoryDesign.RunSolution();

            //var builderDesign = new BuilderDesign();
            //builderDesign.Describe();
            //await builderDesign.RunProblem();
            //await builderDesign.RunSolution();

            //var prototypeDesign = new Prototype.PrototypeDesign();
            //prototypeDesign.Describe();
            //await prototypeDesign.RunProblem();
            //await prototypeDesign.RunSolution();

            //Structural Patterns

            //var adapterDesign = new Adapter.AdapterDesign();
            //adapterDesign.Describe();
            //await adapterDesign.RunProblem();
            //await adapterDesign.RunSolution();

            var bridgeDesign = new Bridge.BridgeDesign();
            bridgeDesign.Describe();
            await bridgeDesign.RunProblem();
            await bridgeDesign.RunSolution();

        }
    }
}
