

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FsmStartedException : Exception
	{
		public FsmStartedException()
		{
		}

		public FsmStartedException(string message) : base(message)
		{
		}

		public FsmStartedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FsmStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}