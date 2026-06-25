using System.Drawing;
using System.Numerics;

namespace Flyweight.Problem.Models
{
    public class Billboard
    {
        public readonly Guid Id;
        public Vector3 Position { get; set; }
        public Vector2 Size { get; set; }
        public bool HasFloodlights { get; set; }
        public bool IsDigital { get; set; }
        public byte[] ImageBytes { get; set; }
        public Color FrameColor { get; set; }

        public Billboard(Vector3 position, Vector2 size, byte[] image, Color frameColor, bool hasFloodLights, bool isDigital)
        {
            Id = Guid.NewGuid();
            Position = position;
            Size = size;
            ImageBytes = image;
            FrameColor = frameColor;
            HasFloodlights = hasFloodLights;
            IsDigital = isDigital;
        }

        public void Render()
        {
            string work = $"Rendering Billboard {Id} in position {Position}, with size {Size}, displaying image {ImageBytes.Length}, with frame color {FrameColor}, using {(HasFloodlights ? 2 : 0)} floodlights and a {(IsDigital ? "digital" : "paper")} surface.";
        }
    }
}
