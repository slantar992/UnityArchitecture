
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Slantar.Architecture.Tests.Log
{
	public class UnityLogTest : ILogTest
	{
		protected override ILog NewInstance => new UnityLog();

		public override bool CheckRecorded() => true;

		[Test]
		public override void TestOnErrorEvent()
		{
			LogAssert.Expect(UnityEngine.LogType.Error, "ERROR: Hello!");
			base.TestOnErrorEvent();
		}
	}
}