

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FSMStateNotFoundException : Exception
	{
		public FSMStateNotFoundException()
		{
		}

		public FSMStateNotFoundException(string message) : base(message)
		{
		}

		public FSMStateNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FSMStateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}