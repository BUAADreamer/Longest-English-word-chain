using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Core;
using System.Collections;
using Library;
using System.Collections.Generic;

namespace CoreTest
{
	/**
	 * TestFile1 TestFile2 TestFile3 为官方用例，作为回归测试用
	 */
	[TestClass]
	public class CoreUnitTest
	{
		Hashtable validCharPair;
		ArrayList validCmdChars = new ArrayList() { 'n', 'w', 'm', 'c', 'h', 't', 'r' };
		public CoreUnitTest()
        {
			validCharPair = getValidCharPair();

		}

		[TestMethod]
		/**
		 * 官方用例回归测试
		 */
		public void CoreTest1()
		{
			String[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			TestOneSample(args);
			String[] args1 = { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args1);
			String[] args2 = { "-m", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args2);
			String[] args3 = { "-c", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args3);
			String[] args4 = { "-h","e","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args4);
			String[] args5 = { "-t", "t", "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args5);
			String[] args6 = { "-r","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile3.txt" };
			TestOneSample(args6);
			//Program.Main(args1);
		}
		[TestMethod]
		public void CoreTest2()
		{
			int testNum = 5;
			String baseFile = "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile{0}.txt";
			String testFile = String.Format(baseFile,testNum);
            for (int j = 0; j < 26; j++)
            {
				for(int k = 0; k < 26; k++)
                {
					String head = ('a' + j).ToString();
					String tail = ('a' + k).ToString();
					foreach (char c1 in validCmdChars)
					{
						ArrayList argList = new ArrayList() { "-" + c1 };
						if (c1 == 't') argList.Add(tail);
						if (c1 == 'h') argList.Add(head);
						argList.Add("");
						for (int i = 1; i <= testNum; i++)
						{
							testFile = String.Format(baseFile, i);
							argList[argList.Count - 1] = testFile;
							TestOneSample(getArgs(argList));
						}
						foreach (char c2 in validCmdChars)
						{
							argList = new ArrayList() { "-" + c1 };
							if (c1 == 't') argList.Add(tail);
							if (c1 == 'h') argList.Add(head);
							argList.Add("-" + c2);
							if (c2 == 't') argList.Add(tail);
							if (c2 == 'h') argList.Add(head);
							argList.Add("");
							for (int i = 1; i <= testNum; i++)
							{
								testFile = String.Format(baseFile, i);
								argList[argList.Count - 1] = testFile;
								TestOneSample(getArgs(argList));
							}
							continue;
							foreach (char c3 in validCmdChars)
							{
								argList = new ArrayList() { "-" + c1 };
								if (c1 == 't') argList.Add(tail);
								if (c1 == 'h') argList.Add(head);
								argList.Add("-" + c2);
								if (c2 == 't') argList.Add(tail);
								if (c2 == 'h') argList.Add(head);
								argList.Add("-" + c3);
								if (c3 == 't') argList.Add(tail);
								if (c3 == 'h') argList.Add(head);
								argList.Add("");
								for (int i = 1; i <= testNum; i++)
								{
									testFile = String.Format(baseFile, i);
									argList[argList.Count - 1] = testFile;
									TestOneSample(getArgs(argList));
								}
								/*
								foreach (char c4 in validCmdChars)
								{
									argList = new ArrayList() { "-" + c1 };
									if (c1 == 't') argList.Add(tail);
									if (c1 == 'h') argList.Add(head);
									argList.Add("-" + c2);
									if (c2 == 't') argList.Add(tail);
									if (c2 == 'h') argList.Add(head);
									argList.Add("-" + c3);
									if (c3 == 't') argList.Add(tail);
									if (c3 == 'h') argList.Add(head);
									argList.Add("-" + c4);
									if (c4 == 't') argList.Add(tail);
									if (c4 == 'h') argList.Add(head);
									argList.Add("");
									for (int i = 1; i <= testNum; i++)
									{
										testFile = String.Format(baseFile, i);
										argList[argList.Count - 1] = testFile;
										TestOneSample(getArgs(argList));
									}
								}
								*/
							}
						}
					}
				}
            }
		}
		[TestMethod]
		public void CoreTest3()
		{
			String[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			TestOneSample(args);
		}

		public Hashtable getValidCharPair()
		{
			String[] args = { };
			CommandParser commandParser = new CommandParser(args);
			return commandParser.getValidCharPair();
		}

		public String[] getArgs(ArrayList argList)
        {
			String[] args = new String[argList.Count];
			for(int i = 0; i < argList.Count; i++)
            {
				args[i] = (String)argList[i];
            }
			return args;
        }

		public void TestOneSample(String[] args)
        {
			try
			{
				CommandParser parser = new CommandParser(args);
				ParseRes parseRes = parser.getParseRes();
				WordListMaker maker = new WordListMaker();
				string article = "";
				if (article == "")
				{
					article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
				}
				List<string> wordList = maker.makeWordList(article);
				List<string> result = new List<string>();
				PairTestInterface.gen_chain_word(wordList, result, parseRes.start, parseRes.end, parseRes.enableLoop);
				Output output = new Output();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
