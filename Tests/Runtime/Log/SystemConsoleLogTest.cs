

using NUnit.Framework;

namespace Slantar.Architecture.Tests.Log
{
	public class SystemConsoleLogTest : ILogTest
	{
		protected override ILog NewInstance => new SystemConsoleLog();

		public override bool CheckRecorded() => true;
	}
}