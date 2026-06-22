using Builder.Problem.Models.Layers;
using static DesignPatterns.ConsoleUtils;

namespace Builder.Problem.Models
{
    public enum Container
    {
        Cup = 0,
        Cone = 1,
    }
    public enum Size
    {
        Small,
        Medium,
        Large
    }
    public class IceCream
    {
        public Container Container { get; private set; }
        public Size Size { get; private set; }
        public List<IIceCreamLayer> Layers { get; private set; } = [];
        public List<IIceCreamExtra> Extras { get; private set; } = [];
        public SauceLayer? CoatingFlavor { get; private set; }
        public bool IncludeCutlery { get; private set; }
        public bool IncludeNapkins { get; private set; }
        public bool IsTakeoutOrder { get; private set; }

        public IceCream(Container container, Size size, List<IIceCreamLayer>? layers = null, List<IIceCreamExtra>? extras = null, SauceLayer? coatingFlavor = null, bool includeCutlery = true, bool includeNapkins = true, bool isTakeoutOrder = true)
        {
            Container = container;
            Size = size;
            if (layers != null)
                Layers = layers;
            if (extras != null)
                Extras = extras;
            CoatingFlavor = coatingFlavor;
            IncludeCutlery = includeCutlery;
            IncludeNapkins = includeNapkins;
            IsTakeoutOrder = isTakeoutOrder;
        }

        public void PrintDetails()
        {
            WriteColored(new TextItem("*** Sorvete de "), new(Container == Container.Cone ? "casquinha" : "pote", ConsoleColor.White));
            WriteColored(new TextItem(" tamanho "), new(GetSizeName(), ConsoleColor.White), new(". ***", 1));
            WriteColored(new TextItem("Talheres: "), new(YesNo(IncludeCutlery), ConsoleColor.White, 1));
            WriteColored(new TextItem("Guardanapos: "), new(YesNo(IncludeNapkins), ConsoleColor.White, 1));
            WriteColored(new TextItem("Retirada: "), new(YesNo(IsTakeoutOrder), ConsoleColor.White, 1));
            WriteColored(new TextItem("Cobertura Interna: "), new(CoatingFlavor != null ? CoatingFlavor.GetName() : "Não", ConsoleColor.White, 2));

            WriteColored(new TextItem("Camadas:", 1));
            foreach (var layer in Layers)
            {
                WriteColored(new TextItem("- "), new(layer.GetName(), ConsoleColor.White, 1));
            }

            WriteColored(new TextItem("", 1));

            WriteColored(new TextItem("Acréscimos:", 1));
            foreach (var extra in Extras)
            {
                WriteColored(new TextItem("- "), new(extra.GetName(), ConsoleColor.White, 1));
            }

            WriteColored(new TextItem("", 1));
        }

        private string GetSizeName() => Size switch
        {
            Size.Small => "pequeno",
            Size.Medium => "médio",
            Size.Large => "grande",
            _ => throw new NotImplementedException()
        };

        private string YesNo(bool value) => value ? "Sim" : "Não";
    }
}
