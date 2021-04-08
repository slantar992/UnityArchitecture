

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class InitialStateNotSetException : Exception
	{
		public InitialStateNotSetException()
		{
		}

		public InitialStateNotSetException(string message) : base(message)
		{
		}

		public InitialStateNotSetException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InitialStateNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}