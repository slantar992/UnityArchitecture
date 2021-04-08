
namespace Slantar.Architecture.Tests
{
	public class StateB : IFsmState
	{
		private Flag boolFlag;

		public StateB(Flag boolFlag) => this.boolFlag = boolFlag;

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
