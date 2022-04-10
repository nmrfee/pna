using System;
using System.Linq;
using System.Reflection;
using Lab16.Common.Extensions;

namespace Lab16.Common.Testing
{
    public partial class DemoRunner
	{
		public void Run()
		{
			Assembly
				.GetEntryAssembly()
				.GetImplementationsOf<ITestContainer>()
				.ForEach(
					testContainer =>
					{
						var methods = testContainer.GetMethodsWith<DemoAttribute>();

						if (methods.Any())
						{
							_newLine();

							$"{testContainer.GetTypeName().FillLine(_defaultConsoleWidth)}".WriteLineToConsole();

							var instance = testContainer.New<ITestContainer>();

							var setupMethod = testContainer.GetMethodWith<SetupAttribute>();

							methods.ForEach(
								testMethod =>
								{
									instance.CallOrDefault(setupMethod);

									try
									{
										_writeResult(instance, testMethod, instance.CallResult<string>(testMethod));
									}
									catch (Exception exception)
									{
										_writeResult(instance, testMethod, exception);
									}
								});
						}
					});
		}
	}

	public partial class DemoRunner
	{
		private static void _newLine()
			=> "\r\n".WriteToConsole();

		private static void _popForegroundColor()
			=> Console.ForegroundColor = _foregroundColorBuffer;

		private static void _pushForegroundColor(ConsoleColor newColor)
		{
			_foregroundColorBuffer = Console.ForegroundColor;

			Console.ForegroundColor = newColor;
		}

		private static void _write(object subject)
			=> Console.Write(subject);

		private static void _writeResult(ITestContainer testContainer, MethodInfo test, Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			if (exception.InnerException != null)
			{
				_writeResult(testContainer, test, exception.InnerException);

				return;
			}

			_writeResult(testContainer, test, exception.Message, _colorCritical);
		}

		private static void _writeResult(ITestContainer testContainer, MethodInfo test, string demo)
			=> _writeResult(testContainer, test, demo, _colorSuccess);

		private static void _writeResult(ITestContainer _, MethodInfo test, string demo, ConsoleColor color)
		{
			$"+-{test.Name.FillLine(_defaultConsoleWidth - 1)}".WriteToConsole();

			_write("\r\n\r\n");

			_pushForegroundColor(color);

			_write(demo);

			_popForegroundColor();

			_write("\r\n\r\n");
		}
	}

	public partial class DemoRunner
	{
		private const ConsoleColor _colorCritical
			  = ConsoleColor.Red;

		private const ConsoleColor _colorSuccess
			= ConsoleColor.Green;

		private const int _defaultConsoleWidth
			= 140;

		private static ConsoleColor _foregroundColorBuffer;
	}
}