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

		private readonly Dictionary<Type, FSMNode> states = new Dictionary<Type, FSMNode>();


		public FiniteStateMachine(IFSMState initialState)
		{
			AddState(initialState);
			SetCurrentState(initialState);
		}

		public FiniteStateMachine() { }


		public FiniteStateMachine AddState(IFSMState state)
		{
			var type = state.GetType();

			if (states.ContainsKey(type))
			{
				throw new FSMStateAlreadyAddedException();
			}
			states.Add(type, new FSMNode()
			{
				state = state
			});

			return this;
		}

		public FiniteStateMachine AddTransition<TState>(IFSMTransition transition) where TState : IFSMState
		{
			var type = typeof(TState);

			if (!states.ContainsKey(type))
			{
				throw new FSMStateNotFoundException();
			}

			states[type].transitions.Add(transition);

			return this;
		}

		public bool ForceState<TState>() where TState : IFSMState
		{
			var type = typeof(TState);
			if (states.TryGetValue(type, out var instance))
			{
				Current = instance.state;
				return true;
			}

			return false;

		}

		public void Update()
		{
			UpdateCurrent();
			if (HasValidTransition(out IFSMState nextState))
			{
				Current = nextState;
			}
		}

		private void UpdateCurrent()
		{
			try
			{
				Current.Update();
			}
			catch (NullReferenceException e)
			{
				throw new FSMCurrentStateNullException();
			}
		}

		private void SetCurrentState(IFSMState initialState) => Current = initialState;

		private bool HasValidTransition(out IFSMState nextState)
		{
			foreach (var transition in states[currentType].transitions)
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