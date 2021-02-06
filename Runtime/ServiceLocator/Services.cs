
using System;

namespace Slantar.Architecture
{
	public static class Services
	{
		public static ServiceLocator Container { get; } = new ServiceLocator();

		public static void ProvideInstance<T>(string ID = ServiceLocator.DEFAULT_ID) where T : new() => ProvideInstance(new T(), ID);
		public static void ProvideInstance<T>(T instance, string ID = ServiceLocator.DEFAULT_ID) => Container.ProvideInstanced(instance, ID);
		public static void Provide<T>(string ID = ServiceLocator.DEFAULT_ID) where T : new() => Provide(() => new T(), ID);
		public static void Provide<T>(Func<T> factory, string ID = ServiceLocator.DEFAULT_ID) => Container.Provide(factory, ID);
		public static T Get<T>(string ID = ServiceLocator.DEFAULT_ID) => Container.Get<T>(ID);
		public static bool Remove<T>(string ID = ServiceLocator.DEFAULT_ID) => Container.Remove<T>(ID);
	}
}