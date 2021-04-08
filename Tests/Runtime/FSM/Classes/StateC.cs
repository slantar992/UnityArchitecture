
namespace Slantar.Architecture.Tests
{
	public class StateC : IFsmState
	{
		private Flag boolFlag;

		public StateC(Flag boolFlag) => this.boolFlag = boolFlag;

		public void Enter()
		{
			boolFlag.value = false;
		}

		public void Update()
		{
		}

		public void Exit()
		{
		}
	}
}
