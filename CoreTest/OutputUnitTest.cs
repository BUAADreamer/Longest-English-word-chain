using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections;
using System.Collections.Generic;

namespace CoreTest
{
	[TestClass]
	public class OutputUnitTest
	{
		[TestMethod]
		public void OutputTest1()
		{
			List<string> wordChains = new List<string>() { "ab", "cd", "ef" };
			int mode = 0;
			string s = "3\nab\ncd\nef\n";
			Output output = new Output();
			Assert.AreEqual(s, output.getOutputStr(wordChains, mode));
			s= "ab\ncd\nef\n";
			mode = 1;
			Assert.AreEqual(s, output.getOutputStr(wordChains, mode));
		}
	}
}
