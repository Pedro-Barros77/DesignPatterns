using Flyweight.Problem.Models;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using static DesignPatterns.ConsoleUtils;

namespace Flyweight.Problem
{
    public static class MarketingService
    {
        private static readonly Random Rand = new Random();
        public static async Task PopulateCityWithBillboards()
        {
            WriteColored(new TextItem("Iniciando medição de consumo de memória em idle (sem teste de stress)...", ConsoleColor.Green, 7));

            await Task.Delay(2000);

            double peakPrivateMemoryMb = 0;
            DateTime next10Seconds = DateTime.Now.AddSeconds(10);

            int x = Console.CursorLeft;
            int y = Console.CursorTop - 5;

            using (Process currentProc = Process.GetCurrentProcess())
            {
                while (DateTime.Now < next10Seconds)
                {
                    Console.SetCursorPosition(x, y);
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    Console.SetCursorPosition(x, y);

                    WriteColored(new TextItem("Tempo Restante: "), new($"{(next10Seconds - DateTime.Now).TotalSeconds:F2}s", ConsoleColor.Cyan, 1));

                    currentProc.Refresh();
                    double privateMemoryMb = currentProc.PrivateMemorySize64 / (1024.0 * 1024.0);

                    WriteColored(new TextItem("Consumo de memória atual: "), new TextItem($"{privateMemoryMb}mb", ConsoleColor.Red, 1));

                    if (privateMemoryMb > peakPrivateMemoryMb)
                    {
                        peakPrivateMemoryMb = privateMemoryMb;
                    }

                    WriteColored(new TextItem("Consumo máximo: "), new TextItem($"{peakPrivateMemoryMb}mb", ConsoleColor.Red, 1));

                    await Task.Delay(50);
                }
            }

            await Task.Delay(2000);

            int goldenCount = 100;
            int mediumCount = 400;
            int stickerCount = 500;

            WriteColored("", 1);
            WriteColored(new TextItem("Iniciando teste de stress com ", ConsoleColor.Green), new($"{goldenCount + mediumCount + stickerCount}", ConsoleColor.Red), new(" Billboards", ConsoleColor.Green, 7));

            await Task.Delay(2000);

            List<Billboard> billboards = new();

            for (int i = 0; i < goldenCount; i++)
            {
                var pos = GetRandomPosition();
                var billboard = await CreateGoldenBillboard(pos);
                billboard.Render();
                billboards.Add(billboard);
            }

            for (int i = 0; i < mediumCount; i++)
            {
                var pos = GetRandomPosition();
                var billboard = await CreateMediumPoster(pos);
                billboard.Render();
                billboards.Add(billboard);
            }

            for (int i = 0; i < stickerCount; i++)
            {
                var pos = GetRandomPosition();
                var billboard = await CreateSmallSticker(pos);
                billboard.Render();
                billboards.Add(billboard);
            }

            double stressPeakPrivateMemoryMb = 0;
            next10Seconds = DateTime.Now.AddSeconds(10);

            x = Console.CursorLeft;
            y = Console.CursorTop - 5;

            using (Process currentProc = Process.GetCurrentProcess())
            {
                while (DateTime.Now < next10Seconds)
                {
                    Console.SetCursorPosition(x, y);
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    WriteColored(new TextItem(new string(' ', Console.BufferWidth), ConsoleColor.Black, ConsoleColor.Black, 1));
                    Console.SetCursorPosition(x, y);

                    WriteColored(new TextItem("Tempo Restante: "), new($"{(next10Seconds - DateTime.Now).TotalSeconds:F2}s", ConsoleColor.Cyan, 1));

                    currentProc.Refresh();
                    double privateMemoryMb = currentProc.PrivateMemorySize64 / (1024.0 * 1024.0);

                    WriteColored(new TextItem("Consumo de memória atual: "), new TextItem($"{privateMemoryMb}mb", ConsoleColor.Red, 1));

                    if (privateMemoryMb > stressPeakPrivateMemoryMb)
                    {
                        stressPeakPrivateMemoryMb = privateMemoryMb;
                    }

                    WriteColored(new TextItem("Consumo máximo: "), new TextItem($"{stressPeakPrivateMemoryMb}mb", ConsoleColor.Red, 1));

                    await Task.Delay(50);
                }
            }

            await Task.Delay(1000);

            WriteColored("", 1);
            WriteColored(new TextItem("O consumo no teste de stress foi "), new TextItem($"{(stressPeakPrivateMemoryMb / peakPrivateMemoryMb):F2}", ConsoleColor.Red), new("x maior que durante o idle", 2));

            await Task.Delay(2000);
        }

        private static Vector3 GetRandomPosition()
        {
            return new Vector3(Rand.Next() * 100, Rand.Next() * 100, Rand.Next() * 100);
        }

        private static async Task<Billboard> CreateGoldenBillboard(Vector3 pos)
        {
            byte[] image = await LoadImage();
            return new Billboard(pos, new(20, 20), image, Color.Gold, true, true);
        }

        private static async Task<Billboard> CreateSmallSticker(Vector3 pos)
        {
            byte[] image = await LoadImage();
            return new Billboard(pos, new(0.5f, 0.5f), image, Color.White, false, false);
        }

        private static async Task<Billboard> CreateMediumPoster(Vector3 pos)
        {
            byte[] image = await LoadImage();
            return new Billboard(pos, new(3, 3), image, Color.Red, false, true);
        }

        private static async Task<byte[]> LoadImage()
        {
            string imageName = "GTA 6 Cover.png";
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            string imagePath = Path.Combine(projectRoot, "StructuralPatterns", "Flyweight", imageName);
            byte[] imageBytes;
            try
            {
                imageBytes = await File.ReadAllBytesAsync(imagePath);
            }
            catch (Exception ex)
            {
                WriteColored(new("Não foi possível carregar imagem. Erro: ", 2), new TextItem(ex.Message, ConsoleColor.Red, 2));
                throw;
            }

            return imageBytes;
        }
    }
}
