using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public static class ConsoleUtils
    {
        public struct TextItem
        {
            public string Text { get; set; } = "";
            public ConsoleColor Foreground { get; set; } = ConsoleColor.Gray;
            public ConsoleColor Background { get; set; } = ConsoleColor.Black;
            public int BR { get; set; } = 0;

            public TextItem() { }
            public TextItem(string text, int br = 0)
            {
                Text = text;
                BR = br;
            }
            public TextItem(string text, ConsoleColor foreground, int br = 0)
            {
                Text = text;
                Foreground = foreground;
                BR = br;
            }
            public TextItem(string text, ConsoleColor foreground, ConsoleColor background, int br = 0)
            {
                Text = text;
                Foreground = foreground;
                Background = background;
                BR = br;
            }
        }
        public static void WriteColored(TextItem item)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = item.Foreground;
            Console.BackgroundColor = item.Background;

            Console.Write(item.Text);

            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;

            for (int i = 0; i < item.BR; i++)
            {
                Console.WriteLine();
            }
        }

        public static void WriteColored(string text)
        {
            WriteColored(new TextItem(text));
        }

        public static void WriteColored(string text, int br)
        {
            WriteColored(new TextItem(text, br));
        }

        public static void WriteColored(IEnumerable<TextItem> items)
        {
            foreach (var item in items)
                WriteColored(item);
        }

        public static void WriteColored(params TextItem[] items)
        {
            foreach (var item in items)
                WriteColored(item);
        }

        public static void RequestInput()
        {
            WriteColored(new TextItem("Pressione qualquer tecla para continuar...", ConsoleColor.DarkGray, 2));
            Console.ReadKey();
        }

        public static void WriteSeparator(ConsoleColor color = ConsoleColor.DarkGray)
        {
            WriteColored(new TextItem(new string(' ', Console.BufferWidth), color, color, 2));
        }
    }
}
