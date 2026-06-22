using DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators;
using static DesignPatterns.ConsoleUtils;

namespace Builder
{
    public class BuilderDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Montar um sorvete customizado, escolhendo os sabores, camadas, coberturas e adicionais.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored("Existem quase infinitas configurações de montagem de sorvetes. Algumas são as mais vendidas e famosas, outras criadas totalmente do zero por um usuário exigente.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Um único construtor enorme com todos os parâmetros possíveis.", 2);

            RequestInput();

            await Problem.IceCreamService.GetOrder();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos que o construtor é muito poluído, com diversos campos que muitas vezes nem são utilizados. Se novas opções de montagem aparecerem, ele se tornará ainda maior.", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Builder)", ConsoleColor.White, 1));
            WriteColored("O Builder separa a construção de um objeto complexo de sua representação final.", 1);
            WriteColored(new("O "), new("IceCreamBuilder", ConsoleColor.White), new(" oferece etapas nomeadas e permite montar somente as partes necessárias, mantendo o mesmo processo capaz de produzir muitas configurações.", 1));
            WriteColored(new("O "), new("IceCreamDirector", ConsoleColor.Green), new(" é opcional: ele encapsula sequências conhecidas de etapas para reproduzir sorvetes predefinidos.", 2));

            RequestInput();

            await Solution.IceCreamService.GetOrder();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("O "), new("IceCreamBuilder", ConsoleColor.White), new(" torna explícita cada etapa, elimina parâmetros posicionais ambíguos e entrega o produto somente ao chamar "), new("Build()", ConsoleColor.Cyan), new(".", 1));
            WriteColored(new("O cliente pode escolher as etapas livremente. Quando existe uma receita recorrente, o "), new("IceCreamDirector", ConsoleColor.Green), new(" coordena a ordem dessas etapas sem conhecer os detalhes internos do produto.", 1));
            WriteColored(new("O principal ganho do padrão é controlar a construção gradual de objetos complexos. A sintaxe fluente entra como uma forma conveniente de apresentar esse processo: "), new("builder.OnCup().WithSize(Size.Large).AddScoopLayer(Flavor.Chocolate)", ConsoleColor.Blue), new(".", 2));

            RequestInput();
        }
    }
}
