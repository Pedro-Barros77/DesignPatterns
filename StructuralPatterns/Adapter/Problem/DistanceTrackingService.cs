using Adapter.Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Adapter.Problem
{
    public static class DistanceTrackingService
    {
        public static async Task TrackDistances()
        {
            WriteSeparator();

            WriteColored(new TextItem("Iniciando contagem de distância no sistema Métrico...", 2));

            int distance1InMeters = 500;
            int distance2InMeters = 1300;
            float distance3InKilometers = 1.2f;

            WriteColored(new TextItem("Distância 1: "), new($"{distance1InMeters}m", ConsoleColor.White, 1));
            WriteColored(new TextItem("Distância 2: "), new($"{distance2InMeters}m", ConsoleColor.White, 1));
            WriteColored(new TextItem("Distância 3: "), new($"{distance3InKilometers}km", ConsoleColor.White, 2));

            var tracker = new DistanceTracker();
            tracker.AddDistanceInMeters(distance1InMeters);
            tracker.AddDistanceInMeters(distance2InMeters);
            tracker.AddDistanceInKilometers(distance3InKilometers);

            WriteColored(new TextItem("Distância Total Calculada: "), new($"{tracker.TotalDistanceInMeters}m", ConsoleColor.Green, 2));

            await Task.Delay(1000);

            WriteSeparator();
            tracker.Reset();

            WriteColored(new TextItem("Iniciando contagem de distância no sistema Imperial...", 2));

            int distance4InFeet = 1640;
            int distance5InFeet = 4263;
            float distance6InMiles = 0.747f;

            WriteColored(new TextItem("Distância 1: "), new($"{distance4InFeet}ft", ConsoleColor.White, 1));
            WriteColored(new TextItem("Distância 2: "), new($"{distance5InFeet}ft", ConsoleColor.White, 1));
            WriteColored(new TextItem("Distância 3: "), new($"{distance6InMiles}mi", ConsoleColor.White, 2));

            tracker.AddDistanceInMeters(distance4InFeet);
            tracker.AddDistanceInMeters(distance5InFeet);
            tracker.AddDistanceInKilometers(distance6InMiles);

            WriteColored(new TextItem("Distância Total Calculada: "), new($"{tracker.TotalDistanceInMeters}m", ConsoleColor.White, 2));

            WriteColored(new TextItem("O usuário esperava o cálculo em Pés: "), new($"9847.16ft", ConsoleColor.DarkRed), new(" e o valor interno no sistema "), new($"3000m", ConsoleColor.White, 2));

            await Task.Delay(1000);
        }
    }
}
