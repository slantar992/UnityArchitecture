
namespace Slantar.Architecture
{
	public interface IFsmTransition
	{
		IFsmState ToState { get; }
		bool Valid { get; }
	}
}