using System;
namespace Library
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
}