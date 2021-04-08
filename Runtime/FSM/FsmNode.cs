using System.Collections.Generic;

namespace Slantar.Architecture
{
    internal class FsmNode
    {
        public bool initial;
        public IFsmState state;
        public readonly List<IFsmTransition> transitions = new List<IFsmTransition>();
    }
}