using System;

namespace Core
{	
    public class ResultTooLongException : Exception
	{
		public ResultTooLongException(string message) : base("The result is too long!" + message)
		{
		}
	}

	public class HasImplicitLoopException : Exception
	{
		public HasImplicitLoopException(string message) : base("The input words have Implicit loop!")
		{
		}
	}

	public class StartInvalidException : Exception
	{
		public StartInvalidException(string message) : base("The head is invalid: " + message)
		{
		}
	}

	public class EndInvalidException : Exception
	{
		public EndInvalidException(string message) : base("The end is invalid: " + message)
		{
		}
	}
}