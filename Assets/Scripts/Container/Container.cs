

using System;
using System.Collections.Generic;
using Slantar.Container.Events;
using Slantar.Container.Exceptions;

namespace Slantar.Container
{
    public class Container
    {
        public event OnContainerChangeEvent OnContainerChange;

        private readonly Dictionary<Type, Dictionary<string, LazyFactory>> instances = new Dictionary<Type, Dictionary<string, LazyFactory>>();

        public void ProvideInstanced<T>(string ID = Constants.DEFAULT_ID) where T : new() => ProvideInstanced(new T(), ID);
        public void ProvideInstanced<T>(T instance, string ID = Constants.DEFAULT_ID) => Provide(() => instance, ID);
        public void Provide<T>(string ID = Constants.DEFAULT_ID) where T : new() => Provide(() => new T(), ID);

        public void Provide<T>(Func<T> factory, string ID = Constants.DEFAULT_ID)
        {
            Type type = typeof(T);
            bool exist = Exist(type, ID);

            Add(type, ID, () => factory());
            TriggerChangeEvent(type, ID, exist ? ChangeType.Replaced : ChangeType.Removed);
        }

        public T Get<T>(string ID = Constants.DEFAULT_ID)
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

        public bool Remove<T>(string ID = Constants.DEFAULT_ID)
        {
            Type type = typeof(T);
            bool exist = Exist(type, ID);
            if (exist)
            {
                instances[type].Remove(ID);
                TriggerChangeEvent(type, ID, ChangeType.Removed);
            }
            return exist;
        }

        private T GetFromDictionary<T>(string ID, Type type) => (T)instances[type][ID].Instance;
        private bool Exist(Type type, string ID) => instances.ContainsKey(type) && instances[type].ContainsKey(ID);

        private void TriggerChangeEvent(Type type, string ID, ChangeType changeType)
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
                instances[type] = new Dictionary<string, LazyFactory>();
            }

            instances[type][ID] = new LazyFactory(factory);
        }
    }
}
