using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture.Runtime
{
	public class InstanceNotFoundException : Exception
	{
		public InstanceNotFoundException()
		{
		}

		public InstanceNotFoundException(string message) : base(message)
		{
		}

		public InstanceNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InstanceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
