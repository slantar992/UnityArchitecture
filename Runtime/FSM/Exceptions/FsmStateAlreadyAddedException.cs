
using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FsmStateAlreadyAddedException : Exception
	{
		public FsmStateAlreadyAddedException()
		{
		}

		public FsmStateAlreadyAddedException(string message) : base(message)
		{
		}

		public FsmStateAlreadyAddedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FsmStateAlreadyAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}