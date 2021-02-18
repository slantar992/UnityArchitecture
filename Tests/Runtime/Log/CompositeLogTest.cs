

namespace Slantar.Architecture.Tests.Log
{
	public class CompositeLogTest : UnityLogTest
	{
		protected override ILog NewInstance => new CompositeLog(LogLevel.Debug,
			new UnityLog(),
			new SystemConsoleLog());
	}
}