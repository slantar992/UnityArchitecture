
namespace Slantar.Architecture
{
	public interface IFiniteStateMachine
	{
		public bool Started { get; }
		void Start();
		void Update();
	}
}