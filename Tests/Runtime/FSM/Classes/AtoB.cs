
namespace Slantar.Architecture.Tests
{
	public class AtoB : IFSMTransition
	{
		public IFSMState ToState { get; private set; }

		public bool Valid => true;

		public AtoB(IFSMState toState)
		{
			ToState = toState;
		}
	}
}
