using Builder.Solution.Models.Layers;
using static DesignPatterns.ConsoleUtils;

namespace Builder.Solution.Models
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

        public IceCream(Container container, Size size)
        {
            Container = container;
            Size = size;
        }

        public void SetSize(Size size)
        {
            Size = size;
        }
        public void SetContainer(Container container)
        {
            Container = container;
        }
        public void SetCoating(SauceLayer sauce)
        {
            CoatingFlavor = sauce;
        }
        public void SetCutlery(bool includeCutlery)
        {
            IncludeCutlery = includeCutlery;
        }
        public void SetNapkins(bool includeNapkins)
        {
            IncludeNapkins = includeNapkins;
        }
        public void SetTakeoutOrder(bool isTakeoutOrder)
        {
            IsTakeoutOrder = isTakeoutOrder;
        }
        public void AddLayer(IIceCreamLayer layer)
        {
            Layers.Add(layer);
        }
        public void SetLayers(IEnumerable<IIceCreamLayer> layers)
        {
            Layers = layers.ToList();
        }
        public void AddExtra(IIceCreamExtra extra)
        {
            Extras.Add(extra);
        }
        public void SetExtras(IEnumerable<IIceCreamExtra> extras)
        {
            Extras = extras.ToList();
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

        private static string YesNo(bool value) => value ? "Sim" : "Não";
    }
}
