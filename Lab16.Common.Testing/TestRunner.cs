using System;
using System.Linq;
using System.Reflection;
using Lab16.Common.Extensions;

namespace Lab16.Common.Testing
{
    public partial class TestRunner
	{
		public TestRunnerResult Run()
		{
			var result = new TestRunnerResult();

			Assembly
				.GetEntryAssembly()
				.GetImplementationsOf<ITestContainer>()
				.ForEach(
					testContainer =>
					{
						var methods = testContainer.GetMethodsWith<TestAttribute>();

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
										RuntimeOffset.Mark();

										instance.Call(testMethod);

										var duration = RuntimeOffset.TimespanSinceMark;

										_writeResult(instance, testMethod, duration);
									}
									catch (Exception exception)
									{
										result.HasFailures = true;

										_writeResult(instance, testMethod, exception);
									}
								});
						}
					});

			return result;
		}
	}

	public partial class TestRunner
	{
		private static void _popForegroundColor()
			=> Console.ForegroundColor = _foregroundColorBuffer;

		private static void _pushForegroundColor(ConsoleColor newColor)
		{
			_foregroundColorBuffer = Console.ForegroundColor;

			Console.ForegroundColor = newColor;
		}

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

			_pushForegroundColor(_colorCritical);

			$"{test.Name}".ConstantWidthLeftAligned(50).WriteToConsole();

			$"{exception.GetTypeName()}: {exception.Message.RemoveNewLines()}".ConstantWidthLeftAligned(90).WriteToConsole();

			_newLine();

			_popForegroundColor();
		}

		private static void _writeResult(ITestContainer _, MethodInfo test, TimeSpan duration)
		{
			_pushForegroundColor(_colorSuccess);

			$"{test.Name}".ConstantWidthLeftAligned(50).WriteToConsole();

			$"({duration.TimeString()})".ConstantWidthLeftAligned(30).WriteToConsole();

			_newLine();

			_popForegroundColor();
		}

		private static void _newLine()
			=> "\r\n".WriteToConsole();
	}

	public partial class TestRunner
	{
		private const ConsoleColor _colorCritical
			  = ConsoleColor.Red;

		private const ConsoleColor _colorSuccess
			= ConsoleColor.Green;

		private const ConsoleColor _colorWarning
			= ConsoleColor.Yellow;

		private const int _defaultConsoleWidth 
			= 140;

		private static ConsoleColor _foregroundColorBuffer;	
	}
}