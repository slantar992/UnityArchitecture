
using System;
using Slantar.Container;

namespace Game.Core
{
    public static class Core
    {
        public static Container Container { get; } = new Container();

        public static void ProvideInstanced<T>(string ID = Constants.DEFAULT_ID) where T : new() => ProvideInstanced(new T(), ID);
        public static void ProvideInstanced<T>(T instance, string ID = Constants.DEFAULT_ID) => Container.ProvideInstanced(instance, ID);
        public static void Provide<T>(string ID = Constants.DEFAULT_ID) where T : new() => Provide(() => new T(), ID);
        public static void Provide<T>(Func<T> factory, string ID = Constants.DEFAULT_ID) => Container.Provide(factory, ID);
        public static T Get<T>(string ID = Constants.DEFAULT_ID) => Container.Get<T>(ID);
        public static bool Remove<T>(string ID = Constants.DEFAULT_ID) => Container.Remove<T>(ID);
    }
}