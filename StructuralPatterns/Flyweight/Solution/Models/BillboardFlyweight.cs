using System.Drawing;
using System.Numerics;

namespace Flyweight.Solution.Models
{
    public class BillboardFlyweight
    {
        //Extrinsic data
        public Vector2 Size { get; private set; }
        public bool HasFloodlights { get; private set; }
        public bool IsDigital { get; private set; }
        public byte[] ImageBytes { get; private set; }
        public Color FrameColor { get; private set; }

        public BillboardFlyweight(Vector2 size, byte[] image, Color frameColor, bool hasFloodLights, bool isDigital)
        {
            Size = size;
            ImageBytes = image;
            FrameColor = frameColor;
            HasFloodlights = hasFloodLights;
            IsDigital = isDigital;
        }
    }
}
