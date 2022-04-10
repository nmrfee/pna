using System;
using System.IO;
using System.Text;
using SystemConsole = System.Console;

namespace Lab16.Common.Consoles
{
    public class Console
    {
        public ConsoleColor BackgroundColor 
        {
            get => SystemConsole.BackgroundColor;
            set => SystemConsole.BackgroundColor = value;
        }

        public void Beep()
            => SystemConsole.Beep();

        public void Beep(int frequencyHz, int durationMs)
            => SystemConsole.Beep(frequencyHz, durationMs);

        public int BufferHeight
        {
            get => SystemConsole.BufferHeight;
            set => SystemConsole.BufferHeight = value;
        }

        public int BufferWidth
        {
            get => SystemConsole.BufferWidth;
            set => SystemConsole.BufferWidth = value;
        }

   //     public event ConsoleCancelEventHandler CancelKeyPress;

        public bool CapsLock
            => SystemConsole.CapsLock;
        
        public void Clear()
            => SystemConsole.Clear();

        public int CursorLeft
        {
            get => SystemConsole.CursorLeft;
            set => SystemConsole.CursorLeft = value;
        }

        public int CursorSize
        {
            get => SystemConsole.CursorSize;
            set => SystemConsole.CursorSize = value;
        }

        public int CursorTop
        {
            get => SystemConsole.CursorTop;
            set => SystemConsole.CursorTop = value;
        }

        public bool CursorVisible
        {
            get => SystemConsole.CursorVisible;
            set => SystemConsole.CursorVisible = value;
        }

        public TextWriter Error
            => SystemConsole.Error;
        
        public ConsoleColor ForegroundColor
        {
            get => SystemConsole.ForegroundColor;
            set => SystemConsole.ForegroundColor = value;
        }

        public TextReader In
            => SystemConsole.In;
        
        public Encoding InputEncoding
        {
            get => SystemConsole.InputEncoding;
            set => SystemConsole.InputEncoding = value;
        }

        public bool IsOutputRedirected
            => SystemConsole.IsOutputRedirected;
        
        public bool IsInputRedirected
            => SystemConsole.IsInputRedirected;
        
        public bool IsErrorRedirected
            => SystemConsole.IsErrorRedirected;
        
        public bool KeyAvailable
            => SystemConsole.KeyAvailable;
        
        public int LargestWindowHeight
            => SystemConsole.LargestWindowHeight;
        
        public int LargestWindowWidth
            => SystemConsole.LargestWindowWidth;
        
        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
            => SystemConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);

        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
            => SystemConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);

        public bool NumberLock
            => SystemConsole.NumberLock;

        public TextWriter Out
            => SystemConsole.Out;

        public Encoding OutputEncoding
        {
            get => SystemConsole.OutputEncoding;
            set => SystemConsole.OutputEncoding = value;
        }

        public Stream OpenStandardError()
            => SystemConsole.OpenStandardError();

        public Stream OpenStandardError(int bufferSize)
            => SystemConsole.OpenStandardError(bufferSize);

        public Stream OpenStandardInput(int bufferSize)
            => SystemConsole.OpenStandardInput(bufferSize);

        public Stream OpenStandardInput()
            => SystemConsole.OpenStandardInput();

        public Stream OpenStandardOutput(int bufferSize)
            => SystemConsole.OpenStandardOutput(bufferSize);

        public Stream OpenStandardOutput()
            => SystemConsole.OpenStandardOutput();

        public int Read()
            => SystemConsole.Read();

        public ConsoleKeyInfo ReadKey(bool intercept)
            => SystemConsole.ReadKey(intercept);

        public ConsoleKeyInfo ReadKey()
            => SystemConsole.ReadKey();

        public string ReadLine()
            => SystemConsole.ReadLine();

        public void ResetColor()
            => SystemConsole.ResetColor();

        public void SetBufferSize(int width, int height)
            => SystemConsole.SetBufferSize(width, height);

        public void SetCursorPosition(int left, int top)
            => SystemConsole.SetCursorPosition(left, top);

        public void SetError(TextWriter newError)
           => SystemConsole.SetError(newError);

        public void SetIn(TextReader newIn)
            => SystemConsole.SetIn(newIn);

        public void SetOut(TextWriter newOut)
            => SystemConsole.SetOut(newOut);

        public void SetWindowPosition(int left, int top)
            => SystemConsole.SetWindowPosition(left, top);

        public void SetWindowSize(int width, int height)
            => SystemConsole.SetWindowSize(width, height);   

        public string Title
        {
            get => SystemConsole.Title;
            set => SystemConsole.Title = value;
        }

        public bool TreatControlCAsInput
        {
            get => SystemConsole.TreatControlCAsInput;
            set => SystemConsole.TreatControlCAsInput = value;
        }

        public int WindowHeight
        {
            get => SystemConsole.WindowHeight;
            set => SystemConsole.WindowHeight = value;
        }

        public int WindowLeft
        {
            get => SystemConsole.WindowLeft;
            set => SystemConsole.WindowLeft = value;
        }

        public int WindowTop
        {
            get => SystemConsole.WindowTop;
            set => SystemConsole.WindowTop = value;
        }

        public int WindowWidth
        {
            get => SystemConsole.WindowWidth;
            set => SystemConsole.WindowWidth = value;
        }

        public void Write(object @object)
            => SystemConsole.Write($"{@object}");

        public void WriteLine(object @object)
            => SystemConsole.WriteLine($"{@object}");
    }
}