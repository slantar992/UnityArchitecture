
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
			fsm.Start();
			Assert.True(flag.value);
		}

		[Test]
		public void TransitionAtoB()
		{
			fsm.Start();
			fsm.Update();
			fsm.Update();
			Assert.False(flag.value);
		}

		[Test]
		public void TestNotStarted()
		{
			Assert.False(fsm.Started);
		}
		
		[Test]
		public void TestStarted()
		{
			fsm.Start();
			Assert.True(fsm.Started);
		}

		[Test]
		public void TestNotStartedException()
		{
			Assert.Throws(typeof(FsmNotStartedException), fsm.Update);
		}
		
		[Test]
		public void TestEmptyFsmException()
		{
			var example = new FiniteStateMachine();
			Assert.Throws(typeof(EmptyFsmException), example.Update);
		}
		
		[Test]
		public void TestFsmStartedException()
		{
			fsm.Start();
			Assert.Throws(typeof(FsmStartedException), fsm.Start);
		}
		
		[Test]
		public void TestFsmStateAlreadyAddedException()
		{
			var state = new StateA(flag);
			Assert.Throws(typeof(FsmStateAlreadyAddedException), () => ((FiniteStateMachine)fsm).AddState(state));
		}
		
		[Test]
		public void TestFsmStateNotFoundException()
		{
			var state = new StateA(flag);
			var transition = new AtoB(state);
			Assert.Throws(typeof(FsmStateNotFoundException), () => ((FiniteStateMachine)fsm).AddTransition<StateC>(transition));
		}
		
		[Test]
		public void TestInitialStateNotSetException()
		{
			var test = new FiniteStateMachine()
				.AddState(new StateA(flag));
			Assert.Throws(typeof(InitialStateNotSetException), test.Start);
		}

		private IFiniteStateMachine AssembleFSM()
		{
			var stateA = new StateA(flag);
			var stateB = new StateB(flag);
			var AtoB = new AtoB(stateB);
			var finiteStateMachine =
				new FiniteStateMachine()
					.AddState(stateA, true)
					.AddState(stateB)
					.AddTransition<StateA>(AtoB);
			return finiteStateMachine;
		}
	}
}