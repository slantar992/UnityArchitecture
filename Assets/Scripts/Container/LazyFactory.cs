
using System;

namespace Slantar.Container
{
    public struct LazyFactory
    {
        private object instance;
        private readonly Func<object> factory;

        public object Instance => GetInstance();

        public LazyFactory(Func<object> factory)
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