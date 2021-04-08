using System;
using System.Collections.Generic;
using System.Linq;

namespace Slantar.Architecture
{
	public class FiniteStateMachine : IFiniteStateMachine
	{
		public bool Started { get; private set; }

		private IFsmState current;
		private Type currentType;
		private IFsmState Current
		{
			get => current;
			set
			{
				current.Exit();
				current = value;
				currentType = value.GetType();
				current.Enter();
			}
		}

		private readonly Dictionary<Type, FsmNode> states = new Dictionary<Type, FsmNode>();

		public FiniteStateMachine()
		{
			current = new EmptyFsmState();
		}


		public FiniteStateMachine AddState(IFsmState state, bool setInitial = false)
		{
			var type = state.GetType();

			if (states.ContainsKey(type))
				throw new FsmStateAlreadyAddedException();

			if (setInitial && FindNode(out var initialNode))
			{
				initialNode.initial = false;
			}

			if (!Started && current.GetType() != typeof(FsmNotStartedState))
				current = new FsmNotStartedState();
			
			states.Add(type, new FsmNode()
			{
				state = state,
				initial = setInitial
			});
			
			return this;
		}

		public FiniteStateMachine AddTransition<TState>(IFsmTransition transition) where TState : IFsmState
		{
			var type = typeof(TState);

			if (!states.ContainsKey(type))
			{
				throw new FsmStateNotFoundException();
			}

			states[type].transitions.Add(transition);

			return this;
		}

		public void Start()
		{
			if (Started) 
				throw new FsmStartedException("The FSM was started, this method was executed previously");
			
			var currentType = current.GetType();
			if (currentType != typeof(EmptyFsmState))
			{
				Current = FindInitialState();
				Started = true;
			}
			else
			{
				current.Update();
			}
		}

		private IFsmState FindInitialState()
		{
			var found = FindNode(out var node);
			if (!found)
			{
				throw new InitialStateNotSetException("Initial state not set, use AddState with setCurrent flag set to true");
			}

			return node.state;
		}

		private bool FindNode(out FsmNode node)
		{
			node = states.Values.FirstOrDefault(state => state.initial);
			return node != null;
		}

		public void Update()
		{
			Current.Update();
			if (HasValidTransition(out IFsmState nextState))
			{
				Current = nextState;
			}
		}

		private bool HasValidTransition(out IFsmState nextState)
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