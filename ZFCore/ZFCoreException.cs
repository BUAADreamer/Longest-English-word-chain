using System;

namespace ZFCore
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
}