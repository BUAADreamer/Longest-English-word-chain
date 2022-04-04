using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using Cmd;
using Core;
using System.Collections.Generic;

namespace CoreTest
{
	[TestClass]
	public class ExceptionUnitTest
	{
		[TestMethod]
		public void CommandInvalidExceptionTest()
		{
			string[] args = { "-n", "t", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandInvalidException e)
			{
				Console.WriteLine(e.Message);
			}

			args = new string[] { "-n", "-M", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandInvalidException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		[TestMethod]
		public void CommandComplexExceptionTest()
		{
			string[] args = { "-n","-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandComplexException e)
			{
				Console.WriteLine(e.Message);
			}

			args = new string[] { "-n", "-m", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandComplexException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		[TestMethod]
		public void FileInvalidExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain" };
			try
            {
				CmdTestInterface.testOneSample(args);
			}
			catch(FileInvalidException e)
            {
				Console.WriteLine(e.Message);
            }
			
			args = new string[] { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/1.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (FileInvalidException e)
			{
				Console.WriteLine(e.Message);
			}
		}

		[TestMethod]
		public void HasImplicitLoopExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile6.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (HasImplicitLoopException e)
			{
				Console.WriteLine(e.Message);
			}

			args = new string[] { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile6.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (HasImplicitLoopException e)
			{
				Console.WriteLine(e.Message);
			}
		}

		[TestMethod]
		public void ResultTooLongExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile7.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (ResultTooLongException e)
			{
				Console.WriteLine(e.Message);
			}

			args = new string[] { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile7.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (ResultTooLongException e)
			{
				Console.WriteLine(e.Message);
			}
		}

	}
}
