using Composite.Solution.Entities;
using static DesignPatterns.ConsoleUtils;

namespace Composite.Solution
{
    public static class FileBrowserService
    {
        public async static Task RenderTree()
        {
            INode rootFolder = new FolderNode("C:", true,
            [
                new FolderNode("Images", false,
                [
                    new FolderNode("Screenshots", false, [
                        new FileNode("Screenshot_20-06-26-112523.jpg", 200_000),
                        new FileNode("Screenshot_22-06-26-154001.jpg", 202_001),
                        new FileNode("Screenshot_22-06-26-162311.jpg", 202_001),
                        new FileNode("Screenshot_23-06-26-081659.jpg", 201_221)
                    ]),
                    new FolderNode("Wedding", false, [
                        new FileNode("1.jpeg", 2_097_255),
                        new FileNode("2.jpeg", 2_097_128),
                        new FileNode("3.jpeg", 2_097_064),
                        new FileNode("4.jpeg", 2_097_172),
                        new FileNode("5.jpeg", 2_097_179),
                        new FileNode("6.jpeg", 2_097_032)
                    ]),
                    new FolderNode("DCIM", false, []),
                    new FileNode("Meme.png", 306_255)
                ]
                ),
                new FolderNode("Documents", false,
                [
                    new FolderNode("Bills", false, [
                        new FileNode("Water_04-2026.pdf", 526_128),
                        new FileNode("Internet_04-2026.pdf", 584_064),
                        new FileNode("Electricity_04-2026.pdf", 516_124),
                        new FileNode("Gas_04-2026.pdf", 258_255)
                    ]),
                    new FolderNode("Curriculums", false, [
                        new FileNode("MyCurriculum_04-2024.docx", 897_255),
                        new FileNode("MyCurriculum_08-2025.docx", 899_128),
                        new FileNode("MyCurriculum_06-2026.docx", 902_255)
                    ]),
                    new FileNode("IPVA-2026.pdf", 197_255)
                ]),
               new FileNode("Backup_22-02-2023.bak", 44_000_128_172)
            ]);

            WriteColored("Sistema de Arquivos: ", 2);
            await Task.Delay(1000);

            WriteColored("", 1);
            WriteSeparator();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Images: ", 2);
            await Task.Delay(2000);

            ((IFolder)rootFolder).Expand([0]);

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Screenshots: ", 2);
            await Task.Delay(2000);

            ((IFolder)rootFolder).Expand([0, 0]);

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Collapsando Tudo: ", 2);
            await Task.Delay(2000);

            ((IFolder)rootFolder).CollapseAll();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Tudo: ", 2);
            await Task.Delay(2000);

            ((IFolder)rootFolder).ExpandAll();

            rootFolder.Render();

            WriteColored("", 1);
        }
    }
}
