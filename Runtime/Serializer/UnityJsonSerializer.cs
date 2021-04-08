using UnityEngine;

namespace Slantar.Architecture
{
    public class UnityJsonSerializer : ISerializer
    {
        public string Serialize<T>(T data) => JsonUtility.ToJson(data);
        public T Deserialize<T>(string serializedData) => JsonUtility.FromJson<T>(serializedData);
    }
}