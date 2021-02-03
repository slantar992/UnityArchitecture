
using System;

namespace Slantar.Architecture
{
	internal class LazyService
	{
		private object instance;
		private readonly Func<object> factory;

		public object Instance => GetInstance();

		public LazyService(Func<object> factory)
		{
			this.factory = factory;
			instance = null;
		}

		private object GetInstance()
		{
			if (instance == null)
			{
				instance = factory();
			}
			return instance;
		}
	}
}