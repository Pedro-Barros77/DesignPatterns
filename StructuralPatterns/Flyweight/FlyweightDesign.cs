using static DesignPatterns.ConsoleUtils;

namespace Flyweight
{
    public class FlyweightDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored(new TextItem("Temos uma missão de marketing para a Rockstar Games. Devemos espalhar "), new("Billboards", ConsoleColor.Cyan), new(" (cartazes) contendo a imagem da capa do jogo GTA 6 por toda a cidade de um jogo mundo aberto existente.", 2));

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored(new TextItem("Ao espalhar 1000 cartazes pela cidade, o sistema apresentou um "), new("alto consumo de memória RAM", ConsoleColor.Red, 2));

            RequestInput();
        }

        public async Task RunProblem()
        {

            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored(new TextItem("Foi criada a classe "), new("Billboard", ConsoleColor.Green), new(" com os campos:", 1));
            WriteColored(new TextItem("Id", ConsoleColor.White), new(", "), new("Position", ConsoleColor.Yellow), new(", "), new("Size", ConsoleColor.Yellow), new(", "), new("ImageBytes", ConsoleColor.Red), new(", "), new("FrameColor", ConsoleColor.Yellow), new(", "), new("HasFloodLights", ConsoleColor.Green), new(" e "), new("IsDigital", ConsoleColor.Green, 1));
            WriteColored(new("Essa mesma classe é instanciada "), new("1000", ConsoleColor.Red), new("x com valores novos, mas que muitas vezes são idênticos para todos os cartazes.", 2));

            RequestInput();

            await Problem.MarketingService.PopulateCityWithBillboards();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos um pulo gigante no consumo de memória devido a quantidade de dados repetidos para cada objeto.", 1));
            WriteColored(new TextItem("Por exemplo, a "), new("Imagem", ConsoleColor.Red), new(" é a mesma para todos os 1000 objetos, enquanto "), new("Size", ConsoleColor.Yellow), new(", "), new("FrameColor", ConsoleColor.Yellow), new(", "), new("HasFloodLight", ConsoleColor.Green), new(" e "), new("IsDigital", ConsoleColor.Green), new(" possuem apenas 3 variantes.", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Flyweight)", ConsoleColor.White, 1));
            WriteColored(new TextItem("O padrão de design Flyweight sugere parar de armazenar valores estáticos ou com poucas variantes no objeto em si e passar a receber esses valores como referências compartilhadas. O valor em si fica armazenado em outro contexto para que todos os objetos tenham acesso.", 1));
            WriteColored(new TextItem("O objeto original contém apenas os valores únicos a ele "), new("(intrínsecos)", ConsoleColor.Green), new(". Objetos que contém apenas valores intrínsecos são chamados de "), new("Contextual Objects", ConsoleColor.Green), new(", eles contém apenas o essencial para os identificar.", 1));
            WriteColored(new TextItem("O objeto com os valores compartilhados "), new("(extrínsecos)", ConsoleColor.Magenta), new(" são chamados de "), new("Flyweight", ConsoleColor.Green), new(", esses objetos são como templates/variantes que carregam dados pesados compartilhados entre muitas instâncias de objetos contextuais.", 1));
            WriteColored(new TextItem("Para conveniência e para garantir que Flyweights não sejam repetidos com dados idênticos, criamos uma "), new("\"FlyweightFactory\"", ConsoleColor.Green), new(" com um método Create() que recebe os valores extrínsecos, verifica se já existe um objeto assim, caso exista retorna essa mesma referência, do contrário, cria um novo Flyweight e adiciona no cache.", 2));

            RequestInput();

            await Solution.MarketingService.PopulateCityWithBillboards();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, apenas 3 objetos "), new("BillboardFlyweight", ConsoleColor.White), new(" com os dados pesados foram criados, enquanto os outros 1000 objetos contextuais "), new("Billboard", ConsoleColor.White), new(" contém apenas "), new("Id", ConsoleColor.Yellow), new(" e "), new("Position", ConsoleColor.Yellow), new(", o que reduz o consumo de memória em até "), new("40x", ConsoleColor.Green), new(" nesse teste!", 1));
            WriteColored(new TextItem("O "), new("BillboardFlyweightFactory", ConsoleColor.Blue), new(" recebe uma chamada para criar um novo flyweight e decide se deve criar mesmo ou retornar um dos 3 já existentes.", 1));
            WriteColored(new TextItem("Assim, a mesma referência de dados pesados como a "), new("Image", ConsoleColor.Red), new(" é utilizada para cada novo objeto contextual criado.", 2));

            RequestInput();
        }
    }
}
