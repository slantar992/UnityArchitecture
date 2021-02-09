

using System;
using System.Collections.Generic;

namespace Slantar.Architecture
{
	public class EventBus : IEventBus
	{
		private readonly Dictionary<Type, List<IEventSubscriber>> subscribers = new Dictionary<Type, List<IEventSubscriber>>();

		public void Subscribe<EventDataType>(Action<EventDataType> method)
		{
			Type type = typeof(EventDataType);

			if(!subscribers.TryGetValue(type, out List<IEventSubscriber> methods))
			{
				methods = new List<IEventSubscriber>();
				subscribers.Add(type, methods);
			}

			methods.Add(new EventSubscriber<EventDataType>(method));
		}

		public bool Unsubscribe<EventDataType>(Action<EventDataType> method)
		{
			Type type = typeof(EventDataType);
			bool result = false;

			if(subscribers.TryGetValue(type, out List<IEventSubscriber> subscribersList))
			{
				var subMethod = new EventSubscriber<EventDataType>(method);
				result = subscribersList.Remove(subMethod);
			}

			return result;
		}

		public void Trigger<EventDataType>() where EventDataType : new() => Trigger(new EventDataType());

		public void Trigger<EventDataType>(EventDataType data)
		{
			Type type = typeof(EventDataType);

			if(subscribers.TryGetValue(type, out List<IEventSubscriber> methods))
			{
				foreach (var item in methods)
				{
					item.Trigger(data);
				}
			}
		}

		public void Clear() => subscribers.Clear();

	}
}