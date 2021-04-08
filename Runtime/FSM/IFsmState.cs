
using System.Collections.Generic;

namespace Slantar.Architecture
{
	public interface IFsmState
	{
		void Enter();
		void Update();
		void Exit();
	}
}