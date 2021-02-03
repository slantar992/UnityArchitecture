
namespace Slantar.Architecture
{
    [System.Serializable]
    public class InstanceNotFoundException : System.Exception
    {
        public InstanceNotFoundException() { }
        public InstanceNotFoundException(string message) : base(message) { }
        public InstanceNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected InstanceNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}