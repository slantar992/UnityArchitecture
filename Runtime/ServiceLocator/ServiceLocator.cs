

using System;
using System.Collections.Generic;

namespace Slantar.Architecture
{
	public delegate void OnContainerChangeEvent(OnContainerChangeData data);

	public class ServiceLocator
	{
		public const string DEFAULT_ID = "__base__";

		public event OnContainerChangeEvent OnContainerChange;

		private readonly Dictionary<Type, Dictionary<string, LazyService>> instances = new Dictionary<Type, Dictionary<string, LazyService>>();

		public void ProvideInstanced<T>(string ID = DEFAULT_ID) where T : new() => ProvideInstanced(new T(), ID);
		public void ProvideInstanced<T>(T instance, string ID = DEFAULT_ID) => Provide(() => instance, ID);
		public void Provide<T>(string ID = DEFAULT_ID) where T : new() => Provide(() => new T(), ID);

		public void Provide<T>(Func<T> factory, string ID = DEFAULT_ID)
		{
			Type type = typeof(T);
			bool exist = Exist(type, ID);
			
			Add(type, ID, () => factory());
			TriggerChangeEvent(type, ID, exist ? ContainerChangeType.Replaced : ContainerChangeType.Removed);
		}

		public T Get<T>(string ID = DEFAULT_ID)
		{
			Type type = typeof(T);
			T result;

			if (Exist(type, ID))
			{
				result = GetFromDictionary<T>(ID, type);
			}
			else
			{
				throw new InstanceNotFoundException($"({type}, {ID})");
			}

			return result;
		}

		public bool Remove<T>(string ID = DEFAULT_ID)
		{
			Type type = typeof(T);
			bool exist = Exist(type, ID);

			if (exist)
			{
				instances[type].Remove(ID);
				TriggerChangeEvent(type, ID, ContainerChangeType.Removed);
			}

			return exist;
		}

		public void Clear() => instances.Clear();

		private T GetFromDictionary<T>(string ID, Type type) => (T)instances[type][ID].Instance;
		private bool Exist(Type type, string ID) => instances.ContainsKey(type) && instances[type].ContainsKey(ID);

		private void TriggerChangeEvent(Type type, string ID, ContainerChangeType changeType)
		{
			OnContainerChangeData data;
			data.type = type;
			data.ID = ID;
			data.changeType = changeType;
			OnContainerChange?.Invoke(data);
		}


		private void Add(Type type, string ID, Func<object> factory)
		{
			if (!instances.ContainsKey(type))
			{
				instances[type] = new Dictionary<string, LazyService>();
			}

			instances[type][ID] = new LazyService(factory);
		}
	}
}
