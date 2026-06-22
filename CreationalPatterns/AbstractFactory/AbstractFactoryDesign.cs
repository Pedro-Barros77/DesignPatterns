using AbstractFactory.Problem;
using AbstractFactory.Solution;
using AbstractFactory.Solution.Creators;
using static DesignPatterns.ConsoleUtils;

namespace AbstractFactory
{
    public class AbstractFactoryDesign
    {

        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Montar uma experiência para os clientes onde eles escolhem uma nacionalidade e recebem uma refeição surpresa completa dessa nacionalidade, incluindo entrada, prato principal, bebida e sobremesa.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored("Existem 4 tipos de produtos e cada um possui (hoje) 3 nacionalidades: ");
            WriteColored(new("Brasileira", ConsoleColor.Green), new(", "), new("Italiana", ConsoleColor.Magenta), new(" e "), new("Japonesa", ConsoleColor.Cyan), new(".", 1));
            WriteColored("Para garantir a imersão, todos os itens do cardápio devem ser da mesma nacionalidade.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Uma classe para cada prato de cada nacionalidade e um switch no código do serviço contendo a lógica para cada opção:", 2);

            RequestInput();

            //If user chooses Brasillian
            await Problem.MenuService.PrepareNationalityMeal(Nationality.Brazillian);
            //If user chooses Italian
            await Problem.MenuService.PrepareNationalityMeal(Nationality.Italian);
            //If user chooses Japanese
            await Problem.MenuService.PrepareNationalityMeal(Nationality.Japanese);

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("Observamos que há muita repetição de código, e se um dia for necessário adicionar uma nova nacionalidade, como "), new("Mexicana", ConsoleColor.Yellow), new(", toda a estrutura de envio seria repetida, acoplando mais regra ao "), new("MenuService", ConsoleColor.White), new(".", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Abstract Factory)", ConsoleColor.White, 1));
            WriteColored("Enquanto o Factory Method varia a criação de um produto, o Abstract Factory fornece uma família inteira de produtos relacionados.", 1);
            WriteColored(new("Aqui, cada implementação de "), new("IMenuFactory", ConsoleColor.White), new(" cria entrada, bebida, prato principal e sobremesa da "), new("mesma nacionalidade", ConsoleColor.Yellow), new(".", 1));
            WriteColored("O cliente usa apenas as interfaces dos produtos e troca a família completa ao receber outra fábrica, sem combinar itens incompatíveis por acidente.", 2);
            WriteColored(new("As famílias são definidas pelos contratos "), new("IStarter", ConsoleColor.Green), new(", "), new("IDrink", ConsoleColor.Green), new(", "), new("IMainDish", ConsoleColor.Green), new(" e "), new("IDessert", ConsoleColor.Green), new(".", 2));

            RequestInput();

            //If user chooses Brasillian
            var brasilianFactory = new BrazillianMenuFactory();
            await Solution.MenuService.PrepareNationalityMeal(brasilianFactory);

            var italianFactory = new ItalianMenuFactory();
            await Solution.MenuService.PrepareNationalityMeal(italianFactory);

            var japaneseFactory = new JapaneseMenuFactory();
            await Solution.MenuService.PrepareNationalityMeal(japaneseFactory);

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new("O ganho central não é apenas remover o switch: "), new("IMenuFactory", ConsoleColor.White), new(" garante a criação conjunta de produtos que pertencem à mesma família.", 1));
            WriteColored(new("O "), new("MenuService", ConsoleColor.White), new(" conhece os tipos abstratos e coordena a refeição; cada fábrica concreta conhece somente os pratos de sua nacionalidade.", 1));
            WriteColored("Para adicionar uma família mexicana, criamos seus quatro produtos e uma MexicanMenuFactory. O fluxo de preparo permanece inalterado.", 1);
            WriteColored(new("Em resumo: "), new("Factory Method", ConsoleColor.Cyan), new(" escolhe qual implementação de um produto criar; "), new("Abstract Factory", ConsoleColor.Green), new(" escolhe qual família de produtos relacionados criar.", 2));

            RequestInput();
        }
    }
}
