using System;

namespace SSQLParser
{
	public class InvalidSQLException : Exception
	{
        public InvalidSQLException()
        {
        }

        public InvalidSQLException(string message)
			: base(message)
		{
		}

		public InvalidSQLException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
