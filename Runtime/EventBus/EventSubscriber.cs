
using System;
using System.Collections.Generic;

namespace Slantar.Architecture
{
	internal struct EventSubscriber<EventDataType> : IEventSubscriber
	{
		public Action<EventDataType> Method {get; private set;}

		public EventSubscriber(Action<EventDataType> method)
		{
			Method = method;
		}

		public override bool Equals(object obj)
		{
			return obj is EventSubscriber<EventDataType> data &&
				EqualityComparer<Action<EventDataType>>.Default.Equals(Method, data.Method);
		}

		public override int GetHashCode()
		{
			return -1405647184 + Method.GetHashCode();
		}

		public void Trigger(object data) => Method((EventDataType)data);
	}
}