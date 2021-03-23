
using NUnit.Framework;

namespace Slantar.Architecture.Tests
{
	[TestFixture]
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
		
		[Test]
		public void ForceTransitionToB()
		{
			var success = fsm.ForceState<StateB>();
			fsm.Update();
			Assert.False(flag.value);
		}
		
		[Test]
		public void IsForcedTransitionSuccessful()
		{
			Assert.True(fsm.ForceState<StateB>());
		}
		
		[Test]
		public void IsForcedTransitionFail() => Assert.False(fsm.ForceState<StateC>());

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