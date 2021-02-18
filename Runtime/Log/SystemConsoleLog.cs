

using System;

namespace Slantar.Architecture
{
	public class SystemConsoleLog : AbstractLog
	{
		protected override void PrintNative(LogLevel level, string message) => Console.WriteLine(message);
	}
}