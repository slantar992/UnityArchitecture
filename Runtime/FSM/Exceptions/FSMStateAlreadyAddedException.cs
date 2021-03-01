
using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FSMStateAlreadyAddedException : Exception
	{
		public FSMStateAlreadyAddedException()
		{
		}

		public FSMStateAlreadyAddedException(string message) : base(message)
		{
		}

		public FSMStateAlreadyAddedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FSMStateAlreadyAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}