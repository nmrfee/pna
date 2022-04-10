using System.Collections;
using System.Linq;
using Lab16.Common.Consoles;
using ConsoleColor = System.ConsoleColor;
using Exception = System.Exception;
using SystemConsole = System.Console;

namespace Lab16.Common.Extensions
{ 
    public static partial class ConsoleExtensions
    {
        internal static void PushForegroundColor(ConsoleColor newColor)
        {
            _foregroundColorBuffer = SystemConsole.ForegroundColor;

            SystemConsole.ForegroundColor = newColor;
        }

        internal static void PushColors()
        {
            PushForegroundColor();

            PushBackgroundColor();
        }

        internal static void PopColors()
        {
            PopForegroundColor();

            PopBackgroundColor();
        }

        internal static void PushForegroundColor() 
            => _foregroundColorBuffer = SystemConsole.ForegroundColor;

        internal static void PopForegroundColor() 
            => SystemConsole.ForegroundColor = _foregroundColorBuffer;

        internal static void PushBackgroundColor(ConsoleColor newColor)
        {
            _backgroundColorBuffer = SystemConsole.BackgroundColor;

            SystemConsole.BackgroundColor = newColor;
        }

        internal static void PushBackgroundColor()
            => _backgroundColorBuffer = SystemConsole.BackgroundColor;

        internal static void PopBackgroundColor() 
            => SystemConsole.BackgroundColor = _backgroundColorBuffer;

        public static void WaitForUser(this Console subject)
        {
            subject.WriteLine("Press any key to continue...");

            subject.ReadKey();
        }

        public static void WaitForUser(this Console subject, int x, int y)
        {
            subject.SetCursorPosition(x, y);

            subject.Write("Press any key to continue...");

            subject.ReadKey();
        }

        public static void WriteError(this Console subject, Exception exception)
        {
            subject.WriteLine(exception);

            if (exception.InnerException != null)
            {
                subject.WriteLine($"Due to: {exception.InnerException}");
            }

            var data = exception.Data.Cast<DictionaryEntry>().Select(entry => $"{entry.Key} = {entry.Value}");

            if (data.Any())
            {
                subject.WriteLine(data.ToAggregateString());
            }
        }

        private static ConsoleColor _backgroundColorBuffer;

        private static ConsoleColor _foregroundColorBuffer;
    }
}