using System.Runtime.CompilerServices;
using static DesignPatterns.ConsoleUtils;

namespace Prototype.Problem.Models
{
    public class ComplexObject : IComplexObject
    {
        public string PublicText { get; set; }
        public int PublicNumber { get; set; }
        public List<string> PublicList { get; set; }
        public bool BooleanNotInConstructor { get; set; }
        public string PublicTextPrivateSet { get; private set; }
        private string PrivateText { get; set; }
        private readonly string PrivateReadOnlyText;

        public ComplexObject(string publicText, int publicNumber, List<string> publicList, string publicTextPrivateSet)
        {
            PublicText = publicText;
            PublicNumber = publicNumber;
            PublicList = publicList;
            PublicTextPrivateSet = publicTextPrivateSet;
            PrivateText = RandomString(8);
            PrivateReadOnlyText = RandomString(4);
        }

        public void PrintObject()
        {
            WriteColored(new TextItem("Object ID: "), new(RuntimeHelpers.GetHashCode(this).ToString(), ConsoleColor.White, 1));
            WriteColored(new TextItem("PublicText: "), new(PublicText, ConsoleColor.White, 1));
            WriteColored(new TextItem("PublicNumber: "), new(PublicNumber.ToString(), ConsoleColor.White, 1));
            WriteColored(new TextItem("PublicList: "), new(string.Join(",", PublicList), ConsoleColor.White, 1));
            WriteColored(new TextItem("BooleanNotInConstructor: "), new(BooleanNotInConstructor.ToString(), ConsoleColor.White, 1));
            WriteColored(new TextItem("PublicTextPrivateSet: "), new(PublicTextPrivateSet, ConsoleColor.White, 1));
            WriteColored(new TextItem("PrivateText: "), new(PrivateText, ConsoleColor.White, 1));
            WriteColored(new TextItem("PrivateReadOnlyText: "), new(PrivateReadOnlyText, ConsoleColor.White, 2));
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
