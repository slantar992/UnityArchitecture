
using NUnit.Framework;

namespace Slantar.Architecture.Tests
{
	public class FiniteStateMachineTest
	{
		private Flag flag;
		private IFiniteStateMachine fsm;

		[SetUp]
		public void SetUp()
		{
			flag = new Flag();
			fsm = AssembleFSM();
		}

		[Test]
		public void InitalStateInitialized()
		{
			Assert.True(flag.value);
		}

		[Test]
		public void TransitionAtoB()
		{
			fsm.Update();
			fsm.Update();
			Assert.False(flag.value);
		}

		private IFiniteStateMachine AssembleFSM()
		{
			var stateA = new StateA(flag);
			var stateB = new StateB(flag);
			var AtoB = new AtoB(stateB);
			var finiteStateMachine =
				new FiniteStateMachine(stateA)
				.AddState(stateB)
				.AddTransition<StateA>(AtoB);
			return finiteStateMachine;
		}
	}
}