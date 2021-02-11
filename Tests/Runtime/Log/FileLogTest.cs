


namespace Slantar.Architecture.Tests.Log
{
	public class FileLogTest : ILogTest
	{
		protected override ILog NewInstance => throw new System.NotImplementedException();

		public override bool CheckRecorded()
		{
			//TODO: Check file
			return true;
		}
	}
}