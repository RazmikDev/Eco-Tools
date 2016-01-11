using System;

namespace Eco.Collections.Generic.Fixed
{
	public class OutOfCapacityException : Exception
	{
		public OutOfCapacityException(String message, Exception innerException)
			: base(message, innerException)
		{

		}

		public OutOfCapacityException(String message)
			: base(message)
		{

		}

		public OutOfCapacityException()
		{

		}
	}
}