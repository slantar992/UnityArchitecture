using System.Collections.Generic;

namespace Slantar.Architecture
{
    public class DatabaseCache
    {
        private readonly Dictionary<string, object> cache = new Dictionary<string, object>();
        private readonly ISerializer serializer;

        public DatabaseCache(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public object this[string key]
        {
            get => cache[key];
            set => cache[key] = value;
        }

        public string SerializedData
        {
            get => serializer.Serialize(cache);
            set => serializer.Deserialize<Dictionary<string, object>>(value);
        }
    }
}