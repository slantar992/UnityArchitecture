
using System;
using Slantar.Architecture;

namespace Slantar.Architecture
{
    public static class Arch
    {
        public static Container Container { get; } = new Container();

		public static void ProvideInstance<T>(string ID = Container.DEFAULT_ID) where T : new() => ProvideInstance(new T(), ID);
		public static void ProvideInstance<T>(T instance, string ID = Container.DEFAULT_ID) => Container.ProvideInstanced(instance, ID);
		public static void Provide<T>(string ID = Container.DEFAULT_ID) where T : new() => Provide(() => new T(), ID);
		public static void Provide<T>(Func<T> factory, string ID = Container.DEFAULT_ID) => Container.Provide(factory, ID);
		public static T Get<T>(string ID = Container.DEFAULT_ID) => Container.Get<T>(ID);
		public static bool Remove<T>(string ID = Container.DEFAULT_ID) => Container.Remove<T>(ID);
    }
}