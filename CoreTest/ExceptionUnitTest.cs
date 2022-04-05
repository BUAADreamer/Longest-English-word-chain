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
			int ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandInvalidException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);

			args = new string[] { "-n", "-!", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandInvalidException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);

			args = new string[] { "-r", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandInvalidException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);
		}
		[TestMethod]
		public void CommandComplexExceptionTest()
		{
			string[] args = { "-n","-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			int ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandComplexException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);

			args = new string[] { "-n", "-m", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (CommandComplexException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);
		}
		[TestMethod]
		public void FileInvalidExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain" };
			int ans = 0;
			try
            {
				CmdTestInterface.testOneSample(args);
			}
			catch(FileInvalidException e)
            {
				ans = 1;
				Console.WriteLine(e.Message);
            }
			Assert.AreEqual(1, ans);

			args = new string[] { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/1.txt" };
			ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (FileInvalidException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(1, ans);
		}

		[TestMethod]
		public void HasImplicitLoopExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile6.txt" };
			int ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (HasImplicitLoopException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(ans, 1);
			ans = 0;
			args = new string[] { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile6.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (HasImplicitLoopException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(ans, 1);
		}

		[TestMethod]
		public void ResultTooLongExceptionTest()
		{
			string[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile7.txt" };
			int ans = 0;
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (ResultTooLongException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(ans, 1);
			ans = 0;
			args = new string[] { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile7.txt" };
			try
			{
				CmdTestInterface.testOneSample(args);
			}
			catch (ResultTooLongException e)
			{
				ans = 1;
				Console.WriteLine(e.Message);
			}
			Assert.AreEqual(ans, 1);
		}

	}
}
