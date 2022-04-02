using System;
namespace Core
{
	public class CommandComplexException : Exception
	{
		public CommandComplexException(string message) : base("CommandComplexException:" + message)
		{
		}
	}

	public class CommandInvalidException : Exception
	{
		public CommandInvalidException(string message) : base("CommandInvalidException:" + message)
		{
		}
	}

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
}