using System.Collections.Generic;

namespace Slantar.Architecture
{
    internal class FSMNode
    {
        public IFSMState state;
        public readonly List<IFSMTransition> transitions = new List<IFSMTransition>();
    }
}