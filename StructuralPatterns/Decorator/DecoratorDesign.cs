using static DesignPatterns.ConsoleUtils;

namespace Decorator
{
    public class DecoratorDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Criar um inimigo em um jogo simples onde a cada onda o inimigo ganha atributos e comportamentos únicos. Aplicar dano a ele e observar os resultados.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored(new TextItem("O inimigo padrão apenas recebe dano e morre caso sua vida chegue a zero. Mas, suas próximas "), new("variantes", ConsoleColor.White), new(", podem ter comportamentos como "), new("Imunidade ao Fogo", ConsoleColor.DarkRed), new(", "), new("Explosão ao morrer", ConsoleColor.Magenta), new(", "), new("Armadura resistente", ConsoleColor.Blue), new(" e "), new("Recompensa em moedas ao morrer", ConsoleColor.Yellow, 1));
            WriteColored(new TextItem("Esses novos atributos/comportamentos são dinâmicos e acumulativos. Novos atributos/comportamentos podem surgir durante o desenvolvimento", 2));

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored(new TextItem("Foram criadas as classes "), new("Enemy", ConsoleColor.Green), new(", "), new("EnemyImmuneToFire", ConsoleColor.DarkRed), new(", "), new("EnemyWithArmor", ConsoleColor.Blue), new(", "), new("EnemyWithDeathExplosion", ConsoleColor.Magenta), new(" e "), new("EnemyWithDefeatReward", ConsoleColor.Yellow, 1));
            WriteColored(new("Dessa forma, cada filho de Enemy é uma variante com comportamentos antes ou depois de receber dano na classe base."), 1);
            WriteColored(new TextItem("Isso por si só já é um problema, mas tem um pior ainda. Para que os efeitos sejam cumulativos, é necessário criar classes para cada combinação possível, como "), new("EnemyWithDefeatRewardAndArmor", ConsoleColor.Red, 2));

            RequestInput();

            await Problem.GameService.RunGame();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos que com essa estrutura, o número de classes cresce exponencialmente ao tentar acumular os efeitos. "), new("EnemyWithDefeatRewardAndArmor", ConsoleColor.Red), new(" não é uma implementação viável.", 1));
            WriteColored(new TextItem("Se for necessário adicionar novos tipos de variantes, seriam criadas novas classes mistas como "), new("EnemyImmuneToFireWithArmor", ConsoleColor.DarkMagenta, 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Decorator)", ConsoleColor.White, 1));
            WriteColored(new TextItem("O padrão de design Decorator sugere adicionar os novos comportamentos a objetos existentes através de um objeto especial "), new("Wrapper", ConsoleColor.Green, 1));
            WriteColored(new TextItem("Esse wrapper contém o objeto original e implementa uma "), new("Interface"), new(" em comum. Quando os métodos do objeto original são chamados, o wrapper aplica suas alterações antes ou depois de executar o método no objeto original.", 1));
            WriteColored(new TextItem("Para isso, definimos a interface "), new("\"IEnemy\"", ConsoleColor.White, 2));

            RequestInput();

            await Solution.GameService.RunGame();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, os objetos são encapsulados recursivamente até que todos os efeitos desejados sejam aplicados. O Decorator base "), new("BaseEnemyDecorator", ConsoleColor.Green), new(" é uma classe abstrata que implementa a interface do "), new("IEnemy", ConsoleColor.White), new(" e delega todos os métodos para seu IEnemy interno.", 1));
            WriteColored(new TextItem("Os Decorators concretos como "), new("EnemyWithArmor", ConsoleColor.Blue), new(" herdam do decorator base, aplicam seus comportamentos e delegam o restante para o pai, que pode conter o Enemy final ou qualquer outro decorator que também implementa IEnemy", 1));
            WriteColored(new TextItem("Observamos que o "), new("GameService", ConsoleColor.White), new(" trata todos como IEnemy, sem distinção.", 1));
            WriteColored(new TextItem("Assim, caso seja necessário adicionar um novo tipo de inimigo como "), new("EnemyWithShield", ConsoleColor.Cyan), new(" ou até mesmo novas combinações de variantes, basta criar novos decorators e encapsular todos um dentro do outro, como bonecas russas de encaixar.", 2));

            RequestInput();
        }
    }
}
