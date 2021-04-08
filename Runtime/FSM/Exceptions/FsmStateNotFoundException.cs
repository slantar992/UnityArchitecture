

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FsmStateNotFoundException : Exception
	{
		public FsmStateNotFoundException()
		{
		}

		public FsmStateNotFoundException(string message) : base(message)
		{
		}

		public FsmStateNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FsmStateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}