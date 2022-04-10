using System;
using Lab16.Common;
using Lab16.Common.Testing;

namespace Lab16.Maths.Pna.Tests
{
    internal static partial class Program
	{
		public static void Main()
		{
			var result = default(TestRunnerResult);

			try
			{
				Console.WindowWidth = 192;

				new DemoRunner().Run();

			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);

				if (exception.InnerException != null)
				{
					Console.WriteLine($"Due to: {exception.InnerException.Message}");
				}
			}

#if DEBUG
			if (RunningProgram.HasDebuggerAttached())
			{
				if (result?.HasFailures ?? false)
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}

				Console.WriteLine("\r\n----------------------------");
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();				
			}
#endif
		}
	}
}