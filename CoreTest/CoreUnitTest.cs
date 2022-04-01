using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections;
namespace CoreTest
{
	/**
	 * TestFile1 TestFile2 TestFile3 为官方用例，作为回归测试用
	 */
	[TestClass]
	public class CoreUnitTest
	{
		[TestMethod]
		public void CoreTest1()
		{
			String[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile1.txt" };
			TestOneSample(args);
			String[] args1 = { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args1);
			String[] args2 = { "-m", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args2);
			String[] args3 = { "-c", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args3);
			String[] args4 = { "-h","e","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args4);
			String[] args5 = { "-t", "t", "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt" };
			TestOneSample(args5);
			String[] args6 = { "-r","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile3.txt" };
			TestOneSample(args6);
		}
		[TestMethod]
		public void CoreTest2()
		{
			
		}

		public void CoreTest3()
		{
			
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
