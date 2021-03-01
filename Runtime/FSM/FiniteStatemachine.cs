

using System;
using System.Collections.Generic;
namespace Slantar.Architecture
{
	public class FiniteStateMachine : IFiniteStateMachine
	{
		private IFSMState current;
		private Type currentType;
		private IFSMState Current
		{
			get => current;
			set
			{
				current?.Exit();
				current = value;
				currentType = value.GetType();
				current.Enter();
			}
		}

		private readonly Dictionary<Type, List<IFSMTransition>> transitions = new Dictionary<Type, List<IFSMTransition>>();

		public FiniteStateMachine(IFSMState initialState)
		{
			AddState(initialState);
			SetCurrentState(initialState);
		}


		public FiniteStateMachine AddState(IFSMState state)
		{
			var type = state.GetType();

			if (transitions.ContainsKey(type))
			{
				throw new FSMStateAlreadyAddedException();
			}
			transitions.Add(type, new List<IFSMTransition>());

			return this;
		}

		public IFiniteStateMachine AddTransition<TState>(IFSMTransition transition) where TState : IFSMState
		{
			var type = typeof(TState);

			if (!transitions.ContainsKey(type))
			{
				throw new FSMStateNotFoundException();
			}

			transitions[type].Add(transition);

			return this;
		}

		public void Update()
		{
			Current.Update();
			if (HasValidTransition(out IFSMState nextState))
			{
				Current = nextState;
			}
		}

		private void SetCurrentState(IFSMState initialState) => Current = initialState;

		private bool HasValidTransition(out IFSMState nextState)
		{
			foreach (var transition in transitions[currentType])
			{
				if (transition.Valid)
				{
					nextState = transition.ToState;
					return true;
				}
			}

			nextState = null;
			return false;
		}
	}
}