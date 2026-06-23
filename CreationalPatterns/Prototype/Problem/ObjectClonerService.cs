using Prototype.Problem.Models;
using static DesignPatterns.ConsoleUtils;

namespace Prototype.Problem
{
    public static class ObjectClonerService
    {
        public static async Task CloneObjects()
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
            WriteColored(new TextItem("Objeto 2 (tentando clonar por referência): ", ConsoleColor.Green, 2));

            var obj2 = obj1;
            obj2.PrintObject();

            WriteColored(new TextItem("Os ID's dos objetos são iguais, então essencialmente são o mesmo objeto em memória", ConsoleColor.DarkRed, 2));

            await Task.Delay(1000);

            WriteSeparator();
            WriteColored(new TextItem("Objeto 3 (new() + trazendo os valores): ", ConsoleColor.Green, 2));

            var obj3 = new ComplexObject(

                obj1.PublicText,
                obj1.PublicNumber,
                obj1.PublicList,
                obj1.PublicTextPrivateSet
            );
            obj3.BooleanNotInConstructor = obj1.BooleanNotInConstructor;
            obj3.PrintObject();

            WriteColored(new TextItem("PrivateText e PrivateReadonlyText são diferentes, pois os valores foram gerados aleatoriamente dentro do construtor", ConsoleColor.DarkRed, 2));

            await Task.Delay(1000);

            WriteSeparator();
            WriteColored(new TextItem("Objeto 4 (conhecendo apenas a interface IComplexObject): ", ConsoleColor.Green, 2));

            IComplexObject obj4 = new ComplexObject(

                obj1.PublicText,
                obj1.PublicNumber,
                obj1.PublicList,
                obj1.PublicTextPrivateSet
            );
            //obj4.BooleanNotInConstructor ??
            obj4.PrintObject();

            WriteColored(new TextItem("BooleanNotInConstructor é diferente, pois a interface mais abstrata não declara esta propriedade, além dos 2 últimos valores aleatórios", ConsoleColor.DarkRed, 2));

            await Task.Delay(1000);
        }
    }
}
