using static DesignPatterns.ConsoleUtils;

namespace Bridge
{
    public class BridgeDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Controlar um sistema de música através de fones de ouvidos.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored(new TextItem("Existem atualmente duas interfaces disponíveis para o usuário: "), new("Earbuds", ConsoleColor.Cyan), new(" e "), new("Headphones", ConsoleColor.Blue, 1));
            WriteColored(new TextItem("Earbuds", ConsoleColor.Cyan), new(" são fones intra auriculares e possuem superfícies sensíveis ao toque (touch) como input, enquanto "), new("Headphones", ConsoleColor.Blue), new(" são fones de ouvido que cobrem as orelhas e possuem botões físicos e rodas de rolagem como input.", 1));
            WriteColored(new TextItem("Além disso, a conexão pode ser feita com 2 tipos de sistemas distintos: "), new("Windows", ConsoleColor.White), new(" e "), new("Android", ConsoleColor.DarkGreen));
            WriteColored(", que por sua vez, também têm suas peculiaridades de funcionamento.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored(new TextItem("Foram criadas as classes "), new("EarbudForAndroid", ConsoleColor.Cyan), new(", "), new("EarbudForWindows", ConsoleColor.Cyan), new(", "), new("HeadphoneForAndroid", ConsoleColor.Blue), new(" e "), new("HeadphoneForWindows", ConsoleColor.Blue), new(".", 1));
            WriteColored(new("Dessa forma, o tipo de dispositivo controla o input/interface de usuário (touch vs click), enquanto o sistema operacional controla a função (aumentar volume, pular música)"), 2);

            RequestInput();

            await Problem.MusicPlayerService.HandleMusic();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos que com essa estrutura, o número de classes cresce exponencialmente. Se fosse necessário adicionar um novo SO como "), new("IoS", ConsoleColor.Magenta), new(", seria necessário criar novas classes "), new("EarbudForIoS", ConsoleColor.DarkRed), new(" e "), new("HeadphoneForIoS", ConsoleColor.DarkRed), new(".", 1));
            WriteColored(new TextItem("O mesmo para novos dispositivos como "), new("Speaker", ConsoleColor.Magenta), new(", seria necessário criar novas classes "), new("SpeakerForAndroid", ConsoleColor.DarkRed), new(" e "), new("SpeakerForWindows", ConsoleColor.DarkRed), new(".", 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Bridge)", ConsoleColor.White, 1));
            WriteColored("O padrão de design Bridge sugere separar a abstração (Dispositivo) da implementação (SO), permitindo que ambas evoluam independentemente.", 1);
            WriteColored(new TextItem("A Bridge atua como um intermediário (ponte) entre a abstração e a implementação.", ConsoleColor.Yellow), new(".", 1));
            WriteColored(new TextItem("Para isso, a abstração define uma interface em comum: "), new("\"IEarphone\"", ConsoleColor.White, 1));
            WriteColored(new TextItem("E a implementação também define uma interface em comum: "), new("\"IPlatform\"", ConsoleColor.White, 1));
            WriteColored("O dispositivo agora \"Possui\" uma referência para a plataforma, em vez de \"Ser\" um sub-dispositivo com variação de plataforma.", 1);
            WriteColored(new TextItem("IEarphone", ConsoleColor.Green), new("."), new("IncreaseVolume", ConsoleColor.Yellow), new("()", ConsoleColor.White), new(" => "), new("this", ConsoleColor.Blue), new TextItem(".Platform.", ConsoleColor.White), new("IncreaseVolume", ConsoleColor.Yellow), new("();", ConsoleColor.White, 2));

            RequestInput();

            await Solution.MusicPlayerService.HandleMusic();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, a Abstração "),new("(IEarphone)", ConsoleColor.Green), new(" cuida da interface de usuário (input) e a Implementação "),  new("(IPlatform)", ConsoleColor.Green), new(" cuida dos detalhes operacionais.", 1));
            WriteColored(new TextItem("Observamos que o serviço "), new("MusicPlayerService", ConsoleColor.White), new(" nem consegue mais diferenciar os dispositivos, pois ambos implementam a mesma interface e possuem uma plataforma de mesma interface.", 1));
            WriteColored(new TextItem("Assim, caso seja necessário adicionar uma nova plataforma ou novo dispositivo, basta criar suas respectivas classes implementando a interface comum.", 1));
            WriteColored(new TextItem("Sem mais crescimento exponencial de número de classes. Além disso, os dispositivos ganharam uma nova habilidade especial, que é a troca de plataformas em tempo de execução. Caso seja uma conexão bluetooth, basta alternar entre Android e Windows, o mesmo dispositivo vai conseguir lidar com ambos!", 1));

            RequestInput();
        }
    }
}
