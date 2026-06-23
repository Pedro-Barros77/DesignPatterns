using Prototype.Solution.Models;
using static DesignPatterns.ConsoleUtils;

namespace Prototype.Solution
{
    public static class ObjectClonerService
    {
        public async static Task CloneObjects()
        {
            WriteSeparator();
            WriteColored(new TextItem("Objeto 1 (original): ", ConsoleColor.Green, 2));

            var obj1 = new ComplexObject(

                "Hello, World!",
                25,
                ["Maçã", "Banana", "Laranja"],
                "Texto com set privado"
            );
            obj1.BooleanNotInConstructor = true;
            obj1.PrintObject();

            await Task.Delay(1000);

            WriteSeparator();
            WriteColored(new TextItem("Objeto 2 (clone do protótipo): ", ConsoleColor.Green, 2));

            IComplexObject obj2 = obj1.Clone();

            obj2.PrintObject();

            WriteColored(new TextItem("Os IDs dos objetos são diferentes e todos os outros dados são idênticos", ConsoleColor.DarkGreen, 2));

            await Task.Delay(1000);
        }
    }
}
