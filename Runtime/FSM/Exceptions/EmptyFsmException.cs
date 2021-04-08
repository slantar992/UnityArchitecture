

using System;
using System.Runtime.Serialization;

namespace Slantar.Architecture
{
	public class EmptyFsmException : Exception
	{
		public EmptyFsmException()
		{
		}

		public EmptyFsmException(string message) : base(message)
		{
		}

		public EmptyFsmException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected EmptyFsmException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}