using System.Drawing;
using System.Numerics;

namespace Flyweight.Solution.Models
{
    public class Billboard
    {
        //Intrinsic data
        public readonly Guid Id;
        public Vector3 Position { get; set; }

        //Extrinsic data
        private BillboardFlyweight Flyweight { get; set; }

        public Billboard(Vector3 position, BillboardFlyweight flyweight)
        {
            Id = Guid.NewGuid();
            Position = position;
            Flyweight = flyweight;
        }

        public void Render()
        {
            string work = $"Rendering Billboard {Id} in position {Position}, with size {Flyweight.Size}, displaying image {Flyweight.ImageBytes.Length}, with frame color {Flyweight.FrameColor}, using {(Flyweight.HasFloodlights ? 2 : 0)} floodlights and a {(Flyweight.IsDigital ? "digital" : "paper")} surface.";
        }
    }
}
