using Bridge.Solution.Entities;
using static DesignPatterns.ConsoleUtils;

namespace Bridge.Solution
{
    public static class MusicPlayerService
    {
        public async static Task HandleMusic()
        {
            WriteSeparator();

            IPlatform android = new AndroidPlatform();
            IPlatform windows = new WindowsPlatform();

            IEarphone headphone = new Headphone(android);
            IEarphone earbud = new Earbud(android);

            WriteColored(new TextItem("Iniciando música no sistema android", 2));

            await Task.Delay(1000);

            WriteColored(new TextItem("Headphone: ", ConsoleColor.Blue, 2));
            await TestDevice(headphone);

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Earbud: ", ConsoleColor.Cyan, 2));
            await TestDevice(earbud);

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Iniciando música no sistema windows", 2));
            headphone.SwitchPlatform(windows);
            earbud.SwitchPlatform(windows);

            await Task.Delay(1000);

            WriteColored(new TextItem("Headphone: ", ConsoleColor.Blue, 2));
            await TestDevice(headphone);

            WriteColored("", 1);
            WriteSeparator();

            await Task.Delay(1000);

            WriteColored(new TextItem("Earbud: ", ConsoleColor.Cyan, 2));
            await TestDevice(earbud);
        }

        private async static Task TestDevice(IEarphone device)
        {
            await Task.Delay(500);
            device.DecreaseVolume();
            await Task.Delay(500);
            device.NextSong();
            await Task.Delay(500);
            device.IncreaseVolume();
            await Task.Delay(500);
            device.TogglePlayback();
        }
    }
}
