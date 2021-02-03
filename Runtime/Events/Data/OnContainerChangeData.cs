
using System;

namespace Slantar.Architecture
{
    public struct OnContainerChangeData
    {
        public Type type;
        public string ID;
        public ContainerChangeType changeType;
    }
}