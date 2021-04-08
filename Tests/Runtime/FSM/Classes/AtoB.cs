
namespace Slantar.Architecture.Tests
{
	public class AtoB : AbstractFsmTransition
	{
		public override bool Valid => true;

		public AtoB(IFsmState toState) : base(toState) { }
	}
}
