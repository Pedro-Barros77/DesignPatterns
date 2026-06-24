using static DesignPatterns.ConsoleUtils;

namespace Composite
{
    public class CompositeDesign
    {
        public void Describe()
        {
            WriteColored(new TextItem("Objetivo", ConsoleColor.Green, 1));
            WriteColored("Exibir uma árvore de pastas e arquivos para um sistema de explorador de arquivos.", 2);

            WriteColored(new TextItem("Problema", ConsoleColor.Red, 1));
            WriteColored(new TextItem("Cada pasta pode conter vários "), new("arquivos", ConsoleColor.Green), new(" e até outras "), new("pastas", ConsoleColor.Cyan, 1));
            WriteColored(new TextItem("O sistema deve desenhar no console essa estrutura, incluindo o tamanho do arquivo em bytes, kilobytes, megabytes, gigabytes ou terabytes.", 1));
            WriteColored("A pasta deve exibir a soma do tamanho de todos os arquivos e pastas dentro dela.", 2);

            RequestInput();
        }

        public async Task RunProblem()
        {
            WriteColored(new("Implementação atual ("), new("legado", ConsoleColor.Red), new(")", 1));
            WriteColored(new TextItem("Foram criadas as classes "), new("FileNode", ConsoleColor.Green), new(" e "), new("FolderNode", ConsoleColor.Cyan), new(", sendo que a primeira contém o tamanho do arquivo e a segunda realiza uma série de loops para calcular o tamanho de todos os seus filhos.", 1));
            WriteColored(new("Dessa forma, toda a recursão ficou como responsabilidade da pasta. Se um dia for necessário adicionar outros tipos de nós como pastas compactadas ou pastas de rede, será necessário modificar toda essa estrutura."), 2);

            RequestInput();

            await Problem.FileBrowserService.RenderTree();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Observamos que com essa estrutura, a "), new("Pasta", ConsoleColor.Cyan), new(" fica com toda a responsabilidade de cálculos e métodos, além de estar totalmente "), new("acoplada", ConsoleColor.Red), new(". Ela precisa saber se seus filhos são "), new("Pastas", ConsoleColor.Cyan), new(" ou "), new("Arquivos", ConsoleColor.Green, 1));
            WriteColored(new TextItem("Se for necessário adicionar novos tipos de nós como "), new("Pasta Compactada", ConsoleColor.Magenta), new(" ou "), new("Pasta de Rede", ConsoleColor.Blue), new(", precisaríamos adicionar novas listas e novos loops no código da "), new("FolderNode", ConsoleColor.Cyan, 2));

            RequestInput();
        }

        public async Task RunSolution()
        {
            WriteColored(new TextItem("Solução", ConsoleColor.Green), new TextItem(" (Composite)", ConsoleColor.White, 1));
            WriteColored(new TextItem("O padrão de design Composite sugere tratar "), new("pastas", ConsoleColor.Cyan), new(" e "), new("arquivos", ConsoleColor.Green), new(" como a mesma coisa, através de uma interface em comum, que declara os métodos para calcular tamanho e renderizar.", 1));
            WriteColored(new TextItem("Esse padrão permite também desacoplar das classes concretas que compõem a árvore. Você não precisa saber se um nó é arquivo ou pasta, desde que eles executem sua parte através do contrato da interface em comum.", 1));
            WriteColored(new TextItem("Para isso, definimos a interface "), new("\"INode\"", ConsoleColor.White, 1));

            RequestInput();

            await Solution.FileBrowserService.RenderTree();

            WriteSeparator();

            WriteColored(new TextItem("Conclusão", ConsoleColor.DarkYellow, 1));
            WriteColored(new TextItem("Dessa forma, a interface serve tanto para o nó final, também chamado de Leaf "), new("(FileNode)", ConsoleColor.Green), new(", quanto para o nó intermediário, também chamado de Container "), new("(FolderNode)", ConsoleColor.Cyan), new(".", 1));
            WriteColored(new TextItem("Ambos conseguem implementar o cálculo de tamanho. O arquivo simplesmente retorna o seu tamanho, enquanto a pasta delega essa função para seus arquivos filhos ou para pastas filhas, que também delegam essa função para seus filhos, recursivamente.", 1));
            WriteColored(new TextItem("Observamos que a "), new("pasta", ConsoleColor.Cyan), new(" não precisa mais saber o tipo dos seus filhos para requisitar seu tamanho.", 1));
            WriteColored(new TextItem("Assim, caso seja necessário adicionar um novo tipo de nó intermediário (container) como "), new("Pasta Compactada", ConsoleColor.Magenta), new(" ou "), new("Pasta de Rede", ConsoleColor.Blue), new(", basta que elas implementem a interface "), new("INode", ConsoleColor.Green), new(" que o sistema continuará funcionando normalmente, sem precisar de refatoração ou mudanças drásticas.", 2));

            RequestInput();
        }
    }
}
