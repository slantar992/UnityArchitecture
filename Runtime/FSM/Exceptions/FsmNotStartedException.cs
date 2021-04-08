

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class FsmNotStartedException : Exception
	{
		public FsmNotStartedException()
		{
		}

		public FsmNotStartedException(string message) : base(message)
		{
		}

		public FsmNotStartedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FsmNotStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}