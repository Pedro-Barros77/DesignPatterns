using Composite.Problem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.ConsoleUtils;

namespace Composite.Problem
{
    public static class FileBrowserService
    {
        public async static Task RenderTree()
        {
            var rootFolder = new FolderNode("C:", true,
            [
                new("Images", false,
                [
                    new("Screenshots", false, [], [
                                                    new("Screenshot_20-06-26-112523.jpg", 200_000),
                                                    new("Screenshot_22-06-26-154001.jpg", 202_001),
                                                    new("Screenshot_22-06-26-162311.jpg", 202_001),
                                                    new("Screenshot_23-06-26-081659.jpg", 201_221),
                                                  ]
                    ),
                    new("Wedding", false, [],     [
                                                    new("1.jpeg", 2_097_255),
                                                    new("2.jpeg", 2_097_128),
                                                    new("3.jpeg", 2_097_064),
                                                    new("4.jpeg", 2_097_172),
                                                    new("5.jpeg", 2_097_179),
                                                    new("6.jpeg", 2_097_032),
                                                  ]
                    ),
                    new("DCIM", false, [], [])
                ],
                                                  [new("Meme.png", 306_255)]
                ),
                new("Documents", false,
                [
                    new("Bills", false, [],       [
                                                    new("Water_04-2026.pdf", 526_128),
                                                    new("Internet_04-2026.pdf", 584_064),
                                                    new("Electricity_04-2026.pdf", 516_124),
                                                    new("Gas_04-2026.pdf", 258_255),
                                                  ]
                    ),
                    new("Curriculums", false, [], [
                                                    new("MyCurriculum_04-2024.docx", 897_255),
                                                    new("MyCurriculum_08-2025.docx", 899_128),
                                                    new("MyCurriculum_06-2026.docx", 902_255),
                                                  ]
                    ),
                ],                                [new("IPVA-2026.pdf", 197_255)]
               )
            ],
                                                  [new("Backup_22-02-2023.bak", 44_000_128_172)]
            );

            WriteColored("Sistema de Arquivos: ", 2);
            await Task.Delay(1000);

            WriteColored("", 1);
            WriteSeparator();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Images: ", 2);
            await Task.Delay(2000);

            rootFolder.Folders[0].Expand();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Screenshots: ", 2);
            await Task.Delay(2000);

            rootFolder.Folders[0].Folders[0].Expand();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Collapsando Tudo: ", 2);
            await Task.Delay(2000);

            rootFolder.CollapseAll();

            rootFolder.Render();

            WriteColored("", 1);
            WriteSeparator();

            WriteColored("Expandindo Tudo: ", 2);
            await Task.Delay(2000);

            rootFolder.ExpandAll();

            rootFolder.Render();

            WriteColored("", 1);
        }
    }
}
