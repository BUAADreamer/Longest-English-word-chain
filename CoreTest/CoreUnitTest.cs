using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections;
namespace CoreTest
{
	[TestClass]
	public class CoreUnitTest
	{
		[TestMethod]
		public void CoreTest1()
		{
			String[] args = { "-n", "-r", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile1.txt" };

			TestOneSample(args);
		}
		[TestMethod]
		public void CoreTest2()
		{
			String[] args = { "-w", "-h","a","-t","t","C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args);
		}



		public void TestOneSample(String[] args)
        {
			CommandParser parser = new CommandParser(args);
			ParseRes parseRes = parser.getParseRes();
			WordListMaker maker = new WordListMaker();
			string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
			ArrayList wordList = maker.makeWordList(article);
			CalcuCore core = new CalcuCore(wordList, parseRes);
			core.runByArgs();
		}
	}
}
