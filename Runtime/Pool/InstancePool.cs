
using System.Collections.Generic;

namespace Slantar.Architecture
{
	public class InstancePool<T> : IPool<T> where T : new()
	{
		private readonly IList<T> instances = new List<T>();
		private int inactiveIndex = 0;

		public T Pick()
		{
			T instance;

			if (inactiveIndex < instances.Count)
			{
				instance = instances[inactiveIndex];
			}
			else
			{
				instance = new T();
				instances.Add(instance);
			}

			inactiveIndex++;
			return instance;
		}

		public void Release(T instance)
		{
			bool removed = instances.Remove(instance);

			if (!removed)
			{
				throw new InstanceNotFoundException();
			}

			instances.Add(instance);
			inactiveIndex--;
		}

		public void ReleaseAll() => inactiveIndex = 0;
	}
}
