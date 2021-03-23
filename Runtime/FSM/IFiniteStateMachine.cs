
namespace Slantar.Architecture
{
	public interface IFiniteStateMachine
	{
		bool ForceState<TState>() where TState : IFSMState;
		void Update();
	}
}