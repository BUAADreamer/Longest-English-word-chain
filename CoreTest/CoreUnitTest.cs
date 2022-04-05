using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Core;
using System.Collections;
using Library;
using System.Collections.Generic;
using Cmd;
using HYCore;

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
		int correctNum = 0;
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
			Console.WriteLine("point 1 pass");
			String[] args1 = { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args1);
			Console.WriteLine("point 2 pass");
			String[] args2 = { "-m", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args2);
			Console.WriteLine("point 3 pass");
			String[] args3 = { "-c", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args3);
			Console.WriteLine("point 4 pass");
			String[] args4 = { "-h","e","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args4);
			Console.WriteLine("point 5 pass");
			String[] args5 = { "-t", "t", "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt" };
			TestOneSample(args5);
			Console.WriteLine("point 6 pass");
			String[] args6 = { "-r","-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile3.txt" };
			TestOneSample(args6);
			Console.WriteLine("point 7 pass");
			String[] args7 = { "-w", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile8.txt" };
			TestOneSample(args7);
			Console.WriteLine("point 8 pass");
			CmdTestInterface.Solve(args);
			String[] args8 = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile6.txt" };
			CmdTestInterface.Solve(args8);
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
						//continue;
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
							/*
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

							}
							*/
						}
					}
				}
            }
			Console.WriteLine(correctNum);
		}
		[TestMethod]
		public void CoreTest3()
		{
			String[] args = { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile1.txt" };
			CmdTestInterface cmd = new CmdTestInterface();
			TestOneSample(args);
			PairTestInterface pair = new PairTestInterface();
			TestOneSample(args);
			List<string> words = new List<string>() { "gbps", "generate", "google", "growing", "handle", "handling", "hardware", "has", "have",
				"having", "heavily", "hence", "high", "highly", "homogeneous", "host", "hosts", "how", "however", "hubs",
				"hungry", "hurt", "identified", "ii", "illustrates", "impact", "impacting", "impairment", "impairments",
				"implementable", "implemented", "improve", "in", "incast", "increase", "increases", "incremental",
				"indistinguishable", "individual", "infrastructure", "internal", "internet", "into", "introduction",
				"invest", "involve", "irrelevant", "is", "issues", "it", "kb", "keep", "key"};
			PairTestInterface.gen_chains_all(words, new List<string>());
			PairTestInterface.gen_chain_word(words, new List<string>() { }, 'g', 'e', true);
			PairTestInterface.gen_chain_word_unique(words,new List<string>() { });
			PairTestInterface.gen_chain_char(words, new List<string>(), 'g', 'e', true);
			PairTestInterface.gen_chain_char(words, new List<string>(), 'g', 'e', false);
		}
		[TestMethod]
		public void CoreTest4()
		{
			List<string> words = new List<string>() { "gbps", "generate", "google", "growing", "handle", "handling", "hardware", "has", "have",
				"having", "heavily", "hence", "high", "highly", "homogeneous", "host", "hosts", "how", "however", "hubs",
				"hungry", "hurt", "identified", "ii", "illustrates", "impact", "impacting", "impairment", "impairments",
				"implementable", "implemented", "improve", "in", "incast", "increase", "increases", "incremental",
				"indistinguishable", "individual", "infrastructure", "internal", "internet", "into", "introduction",
				"invest", "involve", "irrelevant", "is", "issues", "it", "kb", "keep", "key",
			"utilization", "vary", "vast", "very", "vision", "was", "we", "web", "well", "which", "while", "whose", "wide", "with", "without", "workflow", "workloads", "years"};
            try 
			{ 
				PairTestInterface.gen_chains_all(words, new List<string>()); 
			} 
			catch(Exception e) 
			{ 
				Console.WriteLine(e); 
			}
			try
			{
				PairTestInterface.gen_chains_all(words, new List<string>());
			}
			catch(Exception e)
            {
				Console.WriteLine(e);
            }
			try
			{
				PairTestInterface.gen_chain_word(words, new List<string>() { }, 'g', 'e', true);
			}
			catch(Exception e)
            {
				Console.WriteLine(e);
            }
            try
            {
				PairTestInterface.gen_chain_word_unique(words, new List<string>() { });
			}
			catch(Exception e)
            {
				Console.WriteLine(e);
            }
			try
            {
                PairTestInterface.gen_chain_word_unique(words, new List<string>() { });
            }
            catch (Exception e) { Console.WriteLine(e); }
			try
            {
                PairTestInterface.gen_chain_char(words, new List<string>(), 'i', 'e', true);
            }
            catch (Exception e) { Console.WriteLine(e); }
			try
            {
                PairTestInterface.gen_chain_char(words, new List<string>(), 'h', 't', false);
            }
            catch (Exception e) { Console.WriteLine(e); }
		}
		[TestMethod]
		public void CoreTest5()
		{
			List<string> words = new List<string>() { "gbps", "generate", "google", "growing", "handle", "handling", "hardware", "has"};
			List<string> res = new List<string>();
			PairTestInterface.gen_chains_all(words, res);
			Assert.AreEqual(res.Count, 10);

			res = new List<string>();
			PairTestInterface.gen_chain_word(words, res, 'g', 'e', true);
			Assert.AreEqual(res.Count, 2);

			res = new List<string>();
			PairTestInterface.gen_chain_word_unique(words, res);
			Assert.AreEqual(res.Count, 2);

			res = new List<string>();
			PairTestInterface.gen_chain_char(words, res, 'i', 'e', true);
			Assert.AreEqual(res.Count, 1);

			res = new List<string>();
			PairTestInterface.gen_chain_char(words, res, 'h', 't', false);
			Assert.AreEqual(res.Count, 1);
		}

		public Hashtable getValidCharPair()
		{
			CommandParser commandParser;
			commandParser = new CommandParser();
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
			List<string> res;
			List<string> res1;
			int a = 0;
			try 
			{ 
				res = CmdTestInterface.testOneSample(args);
			}
			catch(Exception e)
            {
				Console.WriteLine(e.Message);
				a = 1;
                try
                {
					res1 = TestOneSampleByOther(args);
				}
				catch (Exception e1)
                {
					a = 2;
					Console.WriteLine(e1.Message);
				}
				Assert.AreEqual(2, a);
				return;
            }
			try
			{
				res1 = TestOneSampleByOther(args);
				Assert.AreEqual(res.Count, res1.Count);
			}
			catch (Exception e)
			{
				a = 1;
				printArgs(args);
				Assert.AreEqual(2, a);
			}
		}

		public List<string> TestOneSampleByOther(string[] args)
        {
			CommandParser parser = new CommandParser(args);
			ParseRes parseRes = parser.getParseRes();
			WordListMaker maker = new WordListMaker();
			string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
			List<string> wordList = maker.makeWordList(article);
			List<string> result = new List<string>();
			int outputMode = 1;
			if (parseRes.cmdChars.Contains('n'))
			{
				Chain.gen_chains_all(wordList, 0,result);
				if(result.Count>0)
					result.RemoveAt(0);
			}
			else if (parseRes.cmdChars.Contains('w'))
			{
				Chain.gen_chain_word(wordList, 0, result, parseRes.start, parseRes.end, parseRes.enableLoop);
			}
			else if (parseRes.cmdChars.Contains('m'))
			{
				Chain.gen_chain_word_unique(wordList, 0, result);
			}
			else
			{
				Chain.gen_chain_char(wordList, 0, result, parseRes.start, parseRes.end, parseRes.enableLoop);
			}
			Output output = new Output();
			output.printWordChains(result, outputMode);
			return result;
		}

		public void printArgs(string[] args)
        {
			foreach(string s in args)
            {
				Console.WriteLine(s);
            }
        }
	}
}
