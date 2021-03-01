
using System.Collections.Generic;

namespace Slantar.Architecture
{
	public interface IFSMState
	{
		void Enter();
		void Update();
		void Exit();
	}
}