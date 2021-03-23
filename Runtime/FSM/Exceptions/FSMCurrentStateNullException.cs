

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FSMCurrentStateNullException : Exception
	{
		public FSMCurrentStateNullException()
		{
		}

		public FSMCurrentStateNullException(string message) : base(message)
		{
		}

		public FSMCurrentStateNullException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FSMCurrentStateNullException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}