using System.Diagnostics;

namespace Lab16.Common
{
	public static class RunningProgram
	{
		public static bool HasDebuggerAttached()
			=> Debugger.IsAttached;

		public static bool IsDebugConfiguration()	
#if DEBUG
			=> true;
#else
			=> false;
#endif
    }
}