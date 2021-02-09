using System;

namespace Slantar.Architecture
{
    public interface IEventBus
    {
        void Trigger<EventDataType>() where EventDataType : new();
        void Trigger<EventDataType>(EventDataType data);
        void Subscribe<EventDataType>(Action<EventDataType> method);
        bool Unsubscribe<EventDataType>(Action<EventDataType> method);
        void Clear();
    }
}