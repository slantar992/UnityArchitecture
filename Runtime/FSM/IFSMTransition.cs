
namespace Slantar.Architecture
{
	public interface IFSMTransition
	{
		IFSMState ToState { get; }
		bool Valid { get; }
	}
}