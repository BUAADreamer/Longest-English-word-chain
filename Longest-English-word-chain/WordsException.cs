using System;
public class WordsException:Exception
{
	public WordsException(string message):base(message)
	{

	}
}

public class CommandComplexException : Exception
{
	public CommandComplexException(string message) : base(message)
	{
		message = "CommandComplexException:" + message + "\n";
	}
}

public class CommandInvalidException : Exception
{
	public CommandInvalidException(string message) : base(message)
	{
		message = "CommandInvalidException:" + message + "\n";
	}
}