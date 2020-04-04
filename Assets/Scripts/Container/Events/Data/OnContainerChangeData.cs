
using System;

namespace Slantar.Container.Events
{
    public struct OnContainerChangeData
    {
        public Type type;
        public string ID;
        public ChangeType changeType;
    }
}