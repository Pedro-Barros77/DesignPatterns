using Flyweight.Solution.Models;
using System.Drawing;
using System.Numerics;
using static DesignPatterns.ConsoleUtils;

namespace Flyweight.Solution
{
    public static class BillboardFlyweightFactory
    {
        private static List<BillboardFlyweight> Flyweights { get; set; } = [];

        public static BillboardFlyweight Create(Vector2 size, byte[] image, Color frameColor, bool hasFloodLights, bool isDigital)
        {
            var cachedFlyweight = Flyweights.FirstOrDefault(x
                => x.Size.X == size.X
                && x.Size.Y == size.Y
                && x.ImageBytes.SequenceEqual(image)
                && x.FrameColor.R == frameColor.R
                && x.FrameColor.G == frameColor.G
                && x.FrameColor.B == frameColor.B
                && x.FrameColor.A == frameColor.A
                && x.HasFloodlights == hasFloodLights
                && x.IsDigital == isDigital
            );

            if (cachedFlyweight != null)
                return cachedFlyweight;

            var newFlyWeight = new BillboardFlyweight(size, image, frameColor, hasFloodLights, isDigital);
            Flyweights.Add(newFlyWeight);

            return newFlyWeight;
        }

        public static void PrintFlyweightsCount()
        {
            WriteColored(new TextItem("Total Flyweights: "), new($"{Flyweights.Count}", ConsoleColor.Green, 1));
        }
    }
}
