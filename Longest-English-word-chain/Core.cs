using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
namespace Core
{
	public class CalcuCore
	{
		private ArrayList words;
		private Hashtable graph;
		private Hashtable inDegree;
		private Hashtable word2len;
		private ParseRes parseRes;

		// 构造方法：将所有单词存到 words 里面，并且参数化建图，words 中不能有重复单词
		// mode 表示建图时点权的计算方法
		// 如果 mode == 0，则意味着每个点点权为 1
		// 如果 mode == 1，则意味着每个点点权为该点单词长度
		public CalcuCore(ArrayList wordsList, ParseRes parseRes)
		{
			words = wordsList;
			this.parseRes = parseRes;
		}

		//根据解析
		public void runByArgs()
		{
 			ArrayList res = new ArrayList();
			HashSet<char> parameters = parseRes.cmdChars;
			buildGraph(parseRes.mode); //TODO 不加这一行貌似会导致空引用错误
			if (parameters.Contains('n'))
			{
				getAllWordChains(parseRes.start, parseRes.end, parseRes.enableLoop, res);
			}
			else if (parameters.Contains('w'))
			{
				getMaxWordCountChain(
					parseRes.start, parseRes.end, parseRes.enableLoop, res);
			}
			else if (parameters.Contains('m'))
			{
				getMaxWordCountChainWithDifferentHead(res);
			}
			else if (parameters.Contains('c'))
			{
				getMaxAlphabetCountChain(
					parseRes.start, parseRes.end, parseRes.enableLoop, res);
			}
			else
			{
				Console.WriteLine("Invalid parameter!");
			}
			Output output = new Output();
			int outputMode = 1;
			if (parameters.Contains('n'))
			{
				outputMode = 0;
			}
			output.printWordChains(res, outputMode);
		}

		// 建图加边：如果 a 的最后一个字母和 b 的第一个字母相同，则连一条有向边，并维护入度
		// 从 a 指向 b 的有向边
		private void addEdge(string a, string b)
		{
			// 获取 a 对应的邻接链表，然后把 b 插进去
			Hashtable cur = (Hashtable)graph[a];

			// 这里的 1 没有意义，如果以后引入了边权的概念，则要把这个地方改成边权
			cur.Add(b, 1);

			// 维护入度
			int val = (int)(inDegree[b]);
			inDegree[b] = val + 1;
		}

		// 参数化建图
		// 如果 mode == 0，则意味着每个点点权为 1
		// 如果 mode == 1，则意味着每个点点权为该点单词长度
		private void buildGraph(int mode)
		{
			// graph 用于存图
			graph = new Hashtable();

			// inDegree 存储入度
			inDegree = new Hashtable();

			// 初始化所有点入度为 0
			int len = words.Count;
			for (int i = 0; i < len; i++)
			{
				inDegree.Add((string)(words[i]), 0);
			}
			// word2len 存储点权
			// 如果是统计个数，则点权都是 1
			// 如果是统计字符数，则点权是单词长度
			word2len = new Hashtable();
			if (mode == 0)
			{
				for (int i = 0; i < len; i++)
				{
					word2len.Add((string)(words[i]), 1);
				}
			}
			else
			{
				for (int i = 0; i < len; i++)
				{
					word2len.Add((string)(words[i]), ((string)(words[i])).Length);
				}
			}

			// 给邻接表的每个表头结点开一个空的邻接链表
			for (int i = 0; i < len; i++)
			{
				graph.Add((string)(words[i]), new Hashtable());
			}

			// O(n^2) 枚举每两个点，判断是否可以连边，注意不能自己连到自己
			for (int i = 0; i < len; i++)
			{
				for (int j = 0; j < len; j++)
				{
					if (i == j)
					{
						continue;
					}
					int len1 = ((string)words[i]).Length;
					char lastCh = ((string)words[i])[len1 - 1];
					char firstCh = ((string)words[j])[0];
					if (lastCh == firstCh)
					{
						addEdge((string)words[i], (string)words[j]);
					}
				}
			}
		}

		// 用于判断是否指定 start 或者 end
		// 如果指定了，那么 start 或者 end 应该是一个小写字母
		private bool isInvalidChar(char ch)
		{
			return !(ch >= 'a' && ch <= 'z');
		}

		// 使用拓扑排序检查数据是否有隐含环
		private bool dataCheck()
		{
			Queue queue = new Queue();
			int res = 0;

			// 把入度为 0 的点加入到队列中 
			for (int i = 0; i < words.Count; i++)
			{
				if ((int)inDegree[(string)(words[i])] == 0)
				{
					queue.Enqueue((string)(words[i]));
				}
			}

			while (queue.Count != 0)
			{
				string cur = (string)queue.Dequeue();
				Hashtable curNext = (Hashtable)(graph[cur]);
				res++;
				foreach (DictionaryEntry next in curNext)
				{
					string key = (string)next.Key;
					int degree = (int)inDegree[key];
					inDegree[key] = degree - 1;
					if (degree - 1 == 0)
					{
						queue.Enqueue(key);
					}
				}
			}

			// 如果能够被拓扑排序的点数和单词数一样，那么就是合法数据，否则不合法
			if (res == words.Count)
			{
				return true;
			}
			return false;
		}

		private void getWordChain(ArrayList currentChain, string currentWord,
			char start, char end, HashSet<string> res, HashSet<string> usedWords)
		{
			currentChain.Add(currentWord);
			usedWords.Add(currentWord);
			if (currentChain.Count > 1
				&& (currentWord[currentWord.Length - 1] == end || isInvalidChar(end)))
			{
				string currentChainString = "";
				for (int i = 0; i < currentChain.Count; i++)
				{
					currentChainString += (string)currentChain[i];
					if (i != currentChain.Count - 1)
					{
						currentChainString += " ";
					}
				}
				res.Add(currentChainString);
			}

			// 选择下一个单词
			Hashtable next = (Hashtable)graph[currentWord];
			foreach (DictionaryEntry de in next)
			{
				string nextWord = (string)de.Key;
				if (!usedWords.Contains(nextWord))
				{
					getWordChain(currentChain, nextWord, start, end, res, usedWords);
				}
			}

			// 回溯删除当前单词
			currentChain.RemoveAt(currentChain.Count - 1);
			usedWords.Remove(currentWord);
		}

		public int getAllWordChains(char start, char end, bool enableLoop, ArrayList res)
		{
			// 如果不允许有隐含环且确实含有隐含环
			if (!enableLoop && !dataCheck())
			{
				// TODO: 抛出数据有隐含环的异常
				Console.WriteLine("The words have loop!");
				return 0;
			}

			// 求解单词链
			HashSet<string> chainSet = new HashSet<string>();
			for (int i = 0; i < words.Count; i++)
			{
				string word = (string)words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					ArrayList chain = new ArrayList();
					HashSet<string> usedWords = new HashSet<string>();
					getWordChain(chain, word, start, end, chainSet, usedWords);
				}
			}
			foreach (string str in chainSet)
			{
				res.Add(str);
			}
			return res.Count;
		}

		public int getMaxWordCountChain(char start, char end, bool enableLoop, ArrayList res)
		{
			// 如果不允许有环，并且数据中确实有环
			if (!enableLoop && !dataCheck())
			{
				// TODO：数据有环的异常
				Console.WriteLine("The words have loop!");
				return 0;
			}

			HashSet<string> chainSet = new HashSet<string>();
			for (int i = 0; i < words.Count; i++)
			{
				string word = (string)words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					ArrayList chain = new ArrayList();
					HashSet<string> usedWords = new HashSet<string>();
					getWordChain(chain, word, start, end, chainSet, usedWords);
				}
			}
			int maxLen = 0;
			string longestChain = "";
			foreach (string chain in chainSet)
			{
				int len = 0;
				for (int i = 0; i < chain.Length; i++)
				{
					if (isInvalidChar(chain[i]))
					{
						len++;
					}
				}
				if (maxLen < len)
				{
					maxLen = len;
					longestChain = chain;
				}
			}
			// 把单个单词链的空格改成换行
			string[] substrings = longestChain.Split(' ');
			foreach (string str in substrings)
			{
				res.Add(str);
			}
			return maxLen;
		}

		public int getMaxAlphabetCountChain(char start, char end, bool enableLoop, ArrayList res)
		{
			// 如果需要检查是否有隐含环
			if (!enableLoop && !dataCheck())
			{
				Console.WriteLine("The words have loop!");
				return 0;
			}
			// 求解满足条件的单词链
			HashSet<string> chainSet = new HashSet<string>();
			for (int i = 0; i < words.Count; i++)
			{
				string word = (string)words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					ArrayList chain = new ArrayList();
					HashSet<string> usedWords = new HashSet<string>();
					getWordChain(chain, word, start, end, chainSet, usedWords);
				}
			}
			int maxLen = 0;
			string longestChain = "";
			foreach (string chain in chainSet)
			{
				int len = 0;
				for (int i = 0; i < chain.Length; i++)
				{
					if (!isInvalidChar(chain[i]))
					{
						len++;
					}
				}
				if (maxLen < len)
				{
					maxLen = len;
					longestChain = chain;
				}
			}
			// 把单个单词链的空格改成换行
			string[] substrings = longestChain.Split(' ');
			foreach (string str in substrings)
			{
				res.Add(str);
			}
			return maxLen;
		}

		private void getWordChainWithDifferentHead(ArrayList currentChain, string currentWord,
			HashSet<string> res, HashSet<char> charSet)
		{
			currentChain.Add(currentWord);
			charSet.Add(currentWord[0]);
			if (currentChain.Count > 1)
			{
				string currentChainString = "";
				for (int i = 0; i < currentChain.Count; i++)
				{
					currentChainString += (string)currentChain[i];
					if (i != currentChain.Count - 1)
					{
						currentChainString += " ";
					}
				}
				res.Add(currentChainString);
			}

			// 选择下一个单词
			Hashtable next = (Hashtable)graph[currentWord];
			foreach (DictionaryEntry de in next)
			{
				string nextWord = (string)de.Key;
				// 不能有相同头的字符
				if (charSet.Contains(nextWord[0]))
				{
					continue;
				}
				getWordChainWithDifferentHead(currentChain, nextWord, res, charSet);
			}

			// 回溯删除当前单词
			currentChain.RemoveAt(currentChain.Count - 1);
			charSet.Remove(currentWord[0]);
		}

		public int getMaxWordCountChainWithDifferentHead(ArrayList res)
		{
			if (!dataCheck())
			{
				// TODO:抛出单词有隐含环异常
				return 0;
			}
			HashSet<string> chainSet = new HashSet<string>();
			for (int i = 0; i < words.Count; i++)
			{
				HashSet<char> charSet = new HashSet<char>();
				string word = (string)words[i];
				ArrayList chain = new ArrayList();
				getWordChainWithDifferentHead(chain, word, chainSet, charSet);
			}
			int maxLen = 0;
			string longestChain = "";
			foreach (string chain in chainSet)
			{
				int len = 0;
				for (int i = 0; i < chain.Length; i++)
				{
					// 统计个数
					if (isInvalidChar(chain[i]))
					{
						len++;
					}
				}
				if (maxLen < len)
				{
					maxLen = len;
					longestChain = chain;
				}
			}
			string[] substrings = longestChain.Split(' ');
			foreach (string str in substrings)
			{
				res.Add(str);
			}
			return maxLen;
		}
	}
}