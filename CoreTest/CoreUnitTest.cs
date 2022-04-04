using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Core;
using System.Collections;
using Library;
using System.Collections.Generic;
using Cmd;

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
			res = new List<string>();
			Console.WriteLine(res.Count);
			Assert.AreEqual(res.Count, 10);
			PairTestInterface.gen_chain_word(words, new List<string>() { }, 'g', 'e', true);
			res = new List<string>();
			PairTestInterface.gen_chain_word_unique(words, new List<string>() { });
			res = new List<string>();
			PairTestInterface.gen_chain_char(words, new List<string>(), 'i', 'e', true);
			res = new List<string>();
			PairTestInterface.gen_chain_char(words, new List<string>(), 'h', 't', false);
			res = new List<string>();
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
			CmdTestInterface.Solve(args);
		}
	}
}
