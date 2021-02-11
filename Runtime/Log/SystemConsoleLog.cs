

using System;

namespace Slantar.Architecture
{
	public class SystemConsoleLog : AbstractLog
	{
		public override void Save() => _ = 0;

		protected override void PrintNative(LogLevel level, string message) => Console.WriteLine(message);
	}
}