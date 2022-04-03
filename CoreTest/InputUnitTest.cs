using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
namespace CoreTest
{
	[TestClass]
	public class InputUnitTest
	{
		[TestMethod]
		public void InputTest1()
		{
			string[] args = { "-w" ,"-t","a"};
			CommandParser commandParser = new CommandParser(args);
			ParseRes parseRes = commandParser.getParseRes();
			Assert.AreEqual(parseRes.mode,1);
			Assert.AreEqual(parseRes.end, 'a');
		}
	}
}
