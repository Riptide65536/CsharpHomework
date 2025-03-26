using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class ConsoleMenu
    {
        //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        private readonly List<(string Key, string Text, Action Action)> _options = new();

        public ConsoleMenu(string title) => Title = title;

        public string Title { get; }
        private bool isInfinite = false;
        public void turnOff()
        {
            isInfinite = false;
        }
        public void turnOn()
        {
            isInfinite = true;
        }

        public ConsoleMenu AddOption(string key, string text, Action action)
        {
            _options.Add((key, text, action));
            return this;
        }

        // 字符宽度计算方法
        private static int GetDisplayWidth(string text)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                // 显式指定GB18030编码（兼容GBK且包含最新汉字）
                var encoding = Encoding.GetEncoding("GB18030",
                    EncoderFallback.ReplacementFallback,
                    DecoderFallback.ReplacementFallback);

                return encoding.GetByteCount(text);
            }
            catch (ArgumentException ex)
            {
                // 兜底策略：使用UTF-8计算字符宽度
                Console.WriteLine($"编码获取失败，已切换UTF-8模式: {ex.Message}");
                return Encoding.UTF8.GetByteCount(text);
            }
        }

        // 文本对齐方法
        private static string PadChineseText(string text, int targetWidth)
        {
            int currentWidth = GetDisplayWidth(text);
            return text.PadRight(targetWidth - (currentWidth - text.Length));
        }

        // 标题居中方法
        private static string PadCenter(string text, int width)
        {
            int totalSpace = width - GetDisplayWidth(text);
            int leftSpace = totalSpace / 2;
            return new string(' ', leftSpace) + text + new string(' ', totalSpace - leftSpace);
        }

        public void Show()
        {
            const int minWidth = 30;
            int maxTextWidth = _options.Max(o => GetDisplayWidth(o.Text));
            if (GetDisplayWidth(Title) > maxTextWidth) maxTextWidth = GetDisplayWidth(Title);
            int boxWidth = Math.Max(minWidth, maxTextWidth + 8);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"╔{new string('═', boxWidth)}╗");
                Console.WriteLine($"║ {PadCenter(Title, boxWidth - 4)} ║");
                Console.WriteLine($"╠{new string('─', boxWidth)}╣");

                foreach (var opt in _options)
                {
                    string paddedText = PadChineseText(opt.Text, maxTextWidth);
                    Console.WriteLine($"║ {opt.Key.PadRight(2)} {paddedText} ║");
                }
                Console.WriteLine($"╚{new string('═', boxWidth)}╝");

                var input = Console.ReadKey(intercept: true).KeyChar.ToString();
                var selected = _options.FirstOrDefault(o => o.Key == input);

                if (selected.Action != null)
                {
                    selected.Action.Invoke();
                    if (!isInfinite) return;
                }
                else
                {
                    Console.WriteLine("非法输入！请重新输入！");
                }
            }
        }
    }
}
