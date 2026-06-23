using DesignPatterns.CreationalPatterns.FactoryMethod.Solution.Creators;
using Prototype.Problem;
using Prototype.Solution;
using static DesignPatterns.ConsoleUtils;

namespace Adapter
{
    public class AdapterDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Adicionar distâncias percorridas e somar distância total no final.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored("Um aplicativo foi criado para suportar distâncias no sistema Métrico (Metros e Quilômetros)", 1);
            WriteColored("Mas o cliente pediu para aceitar entradas no sistema Imperial (Milhas e Pés)", 1);
            WriteColored("Toda a regra de negócio e cálculo do aplicativo está acoplada ao sistema Métrico. Como proceder sem espalhar conversões por todo o código?", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored("Tentativa de adicionar distâncias do sistema imperial na interface de sistema métrico:", 2);

            RequestInput();

            await Problem.DistanceTrackingService.TrackDistances();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos que sem a conversão correta de Pés para Metros e Milhas para Quilômetros, o cálculo não é realizado corretamente.", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Adapter)", ConsoleColor.White, 1));
            WriteColored("O padrão de design Adapter sugere criar um Wrapper que converta as unidades do sistema Imperial para o sistema Métrico.", 1);
            WriteColored("Dessa forma, o cliente pode continuar usando o sistema Métrico sem se preocupar com as conversões.", 1);
            WriteColored(new TextItem("O Adapter atua como um tradutor entre os dois sistemas.", ConsoleColor.Yellow), new(".", 1));
            WriteColored(new("Para isso, o adapter implementa uma interface em comum: "), new("\"IDistanceTracker\"", ConsoleColor.White), new(". Dessa forma, ele pode implementar seus métodos, traduzir para o sistema Métrico e passar o valor convertido para o objeto DistanceTracker interno.", 2));

            RequestInput();

            await Solution.DistanceTrackingService.TrackDistances();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, os valores foram convertidos e somados corretamente, sem alterar a lógica existente do sistema Métrico.", 1));
            WriteColored(new TextItem("Observamos que o Adapter preserva a interface original, por exemplo, "), new("AddDistanceInMeters()"), new(" mas interpreta o valor recebido como Pés, converte para Metros e só depois delega para o DistanceTracker em si.", 2));

            RequestInput();
        }
    }
}
