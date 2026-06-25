using static DesignPatterns.ConsoleUtils;

using System.Diagnostics;
using System.Reflection;

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

            //var bridgeDesign = new Bridge.BridgeDesign();
            //bridgeDesign.Describe();
            //await bridgeDesign.RunProblem();
            //await bridgeDesign.RunSolution();

            //var compositeDesign = new Composite.CompositeDesign();
            //compositeDesign.Describe();
            //await compositeDesign.RunProblem();
            //await compositeDesign.RunSolution();

            //var decoratorDesign = new Decorator.DecoratorDesign();
            //decoratorDesign.Describe();
            //await decoratorDesign.RunProblem();
            //await decoratorDesign.RunSolution();

            var flyweightDesign = new Flyweight.FlyweightDesign();

            if (args.Length == 1 && args[0] == "--flyweight-problem")
            {
                await flyweightDesign.RunProblem();
                return;
            }

            if (args.Length == 1 && args[0] == "--flyweight-solution")
            {
                await flyweightDesign.RunSolution();
                return;
            }

            flyweightDesign.Describe();
            //necessário para não compartilhar memória RAM entre os 2 testes
            await RunFlyweightTestInCleanProcess("--flyweight-problem");
            await RunFlyweightTestInCleanProcess("--flyweight-solution");
        }

        private static async Task RunFlyweightTestInCleanProcess(string mode)
        {
            var entryAssemblyPath = Assembly.GetEntryAssembly()?.Location
                ?? throw new InvalidOperationException("Não foi possível encontrar o assembly da aplicação.");

            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                UseShellExecute = false
            };

            startInfo.ArgumentList.Add(entryAssemblyPath);
            startInfo.ArgumentList.Add(mode);

            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException($"Não foi possível iniciar o processo {mode}.");

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                throw new InvalidOperationException($"O processo {mode} terminou com exit code {process.ExitCode}.");
        }
    }
}
