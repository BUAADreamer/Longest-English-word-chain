using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
namespace Core
{
	public class CalcuCore
	{
		private List<string> words;
		private Hashtable graph;
		private Hashtable inDegree;
		private Hashtable word2len;
		private char start;
        private char end;
        private bool enableLoop;
		private int graphMode;
		private int totalCharCount;
		private int MAXLEN = 20000;
		private int chainCount;

        public CalcuCore(List<string> words, char head, char tail, bool enableLoop, int mode)
        {
            this.words = words;
            start = head;
            end = tail;
            this.enableLoop = enableLoop;
			graphMode = mode;
			buildGraph(mode);
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
				inDegree.Add(words[i], 0);
			}
			// word2len 存储点权
			// 如果是统计个数，则点权都是 1
			// 如果是统计字符数，则点权是单词长度
			word2len = new Hashtable();
			if (mode == 0)
			{
				for (int i = 0; i < len; i++)
				{
					word2len.Add(words[i], 1);
				}
			}
			else
			{
				for (int i = 0; i < len; i++)
				{
					word2len.Add(words[i], words[i].Length);
				}
			}

			// 给邻接表的每个表头结点开一个空的邻接链表
			for (int i = 0; i < len; i++)
			{
				graph.Add(words[i], new Hashtable());
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
					int len1 = words[i].Length;
					char lastCh = words[i][len1 - 1];
					char firstCh = words[j][0];
					if (lastCh == firstCh)
					{
						addEdge(words[i], words[j]);
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
			Hashtable bufferInDegree = new Hashtable(inDegree);
			int res = 0;

			// 把入度为 0 的点加入到队列中 
			for (int i = 0; i < words.Count; i++)
			{
				if ((int)bufferInDegree[words[i]] == 0)
				{
					queue.Enqueue(words[i]);
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
					int degree = (int)bufferInDegree[key];
					bufferInDegree[key] = degree - 1;
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

		private void getWordChain(List<string> currentChain, string currentWord,
			char start, char end, HashSet<string> res, HashSet<string> usedWords)
		{
			currentChain.Add(currentWord);
			usedWords.Add(currentWord);
			
			if (currentChain.Count > 1 
				&& (currentWord[currentWord.Length - 1] == end || isInvalidChar(end)))
			{
				chainCount++;
				// 如果字符数没有超过限制，则保存字符串，否则只增加计数器，减少内存消耗
				if (totalCharCount < MAXLEN)
				{
					string currentChainString = "";
					for (int i = 0; i < currentChain.Count; i++)
					{
						currentChainString += currentChain[i];
						if (i != currentChain.Count - 1)
						{
							currentChainString += " ";
						}
					}
					res.Add(currentChainString);
					totalCharCount += currentChain.Count;
				}
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

		public int getAllWordChains(char start, char end, bool enableLoop, List<string> res)
		{
			chainCount = 0;
			// 如果不允许有隐含环且确实含有隐含环
			if (!enableLoop && !dataCheck())
			{
				// TODO: 抛出数据有隐含环的异常
				throw new HasImplicitLoopException("");
			}

			totalCharCount = 0;
			// 求解单词链
			HashSet<string> chainSet = new HashSet<string>();
			for (int i = 0; i < words.Count; i++)
			{
				string word = words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					List<string> chain = new List<string>();
					HashSet<string> usedWords = new HashSet<string>();
					getWordChain(chain, word, start, end, chainSet, usedWords);
				}
			}
			foreach (string str in chainSet)
			{
				res.Add(str);
			}
			return chainCount;
		}

		private void getOneMaxAlphabetCountChain(int charCount, List<string> curLongestChain, 
			List<string> curChain, string word, char start, char end, HashSet<string> usedWords)
		{
			curChain.Add(word);
			usedWords.Add(word);
			
			int newCharCount = charCount + word.Length;
			Hashtable next = (Hashtable)graph[word];
			foreach (DictionaryEntry de in next)
			{
				string nextWord = (string)de.Key;
				if (!usedWords.Contains(nextWord))
				{
					getOneMaxAlphabetCountChain(newCharCount, curLongestChain, curChain, nextWord, start, end, usedWords);
				}
			}

			// 满足尾字母约束，且长度更长，且单词数大于1的才是答案
			if (end == word[word.Length - 1] || isInvalidChar(end))
			{
				int oldCharCount = 0;
				for (int i = 0; i < curLongestChain.Count; i++)
				{
					oldCharCount += curLongestChain[i].Length;
				}
				if (newCharCount > oldCharCount && curChain.Count > 1)
				{
					curLongestChain.Clear();
					for (int i = 0; i < curChain.Count; i++)
					{
						curLongestChain.Add(curChain[i]);
					}
				}
			}

			curChain.RemoveAt(curChain.Count - 1);
			usedWords.Remove(word);
		}

		private void getOneMaxWordCountChain(List<string> curLongestChain, List<string> curChain, 
			string word, char start, char end, HashSet<string> usedWords)
		{
			curChain.Add(word);
			usedWords.Add(word);
			
			Hashtable next = (Hashtable)graph[word];
			foreach (DictionaryEntry de in next)
			{
				string nextWord = (string)de.Key;
				if (!usedWords.Contains(nextWord))
				{
					getOneMaxWordCountChain(curLongestChain, curChain, nextWord, start, end, usedWords);
				}
			}

			// 满足尾字母约束，且长度更长，且单词数大于1的才是答案
			if (end == word[word.Length - 1] || isInvalidChar(end))
			{
				if (curChain.Count > curLongestChain.Count && curChain.Count > 1)
				{
					curLongestChain.Clear();
					for (int i = 0; i < curChain.Count; i++)
					{
						curLongestChain.Add(curChain[i]);
					}
				}
			}

			curChain.RemoveAt(curChain.Count - 1);
			usedWords.Remove(word);
		}

		private int trivialGetMaxWordCountChain(char start, char end, List<string> res)
		{
			List<string> curLongestChain = new List<string>();
			for (int i = 0; i < words.Count; i++)
			{
				string word = words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					List<string> curChain = new List<string>();
					HashSet<string> usedWords = new HashSet<string>();
					getOneMaxWordCountChain(curLongestChain, curChain, word, start, end, usedWords);
				}
			}

			// 最终单词超过1个才能返回出去
			if (curLongestChain.Count > 1)
			{
				for (int i = 0; i < curLongestChain.Count; i++)
				{
					res.Add(curLongestChain[i]);
				}
				return res.Count;
			}
			else
			{
				return 0;
			}
		}

		private int fastGetMaxAlphabetCountChain(char start, char end, List<string> res)
		{
			return fastGetMaxWordCountChain(start, end, res);
		}

		private int trivialGetMaxAlphabetCountChain(char start, char end, List<string> res)
		{
			List<string> curLongestChain = new List<string>();
			int curCharCount = 0;
			for (int i = 0; i < words.Count; i++)
			{
				string word = words[i];
				if (word[0] == start || isInvalidChar(start))
				{
					List<string> curChain = new List<string>();
					HashSet<string> usedWords = new HashSet<string>();
					getOneMaxAlphabetCountChain(0, curLongestChain, curChain, word, start, end, usedWords);
					int newCount = 0;
					for (int j = 0; j < curLongestChain.Count; j++)
					{
						newCount += curLongestChain[j].Length;
					}
					if (newCount > curCharCount)
					{
						curCharCount = newCount;
					}
				}
			}

			if (curLongestChain.Count > 1)
			{
				for (int i = 0; i < curLongestChain.Count; i++)
				{
					res.Add(curLongestChain[i]);
				}
				return curCharCount;
			}
			else
			{
				return 0;
			}
		}
		
		private int fastGetMaxWordCountChain(char start, char end, List<string> res)
		{
			Queue queue = new Queue();
			Hashtable bufferInDegree = new Hashtable(inDegree);
			Hashtable dp = new Hashtable();
			Hashtable lastWord = new Hashtable();
			for (int i = 0; i < words.Count; i++)
			{
				dp.Add(words[i], 0);
			}

			// 把入度为 0 ，且首字母未指定或者指定为 start 的点加入到队列中 
			for (int i = 0; i < words.Count; i++)
			{
				if ((int)bufferInDegree[words[i]] == 0 
					&& (isInvalidChar(start) || words[i][0] == start))
				{
					queue.Enqueue(words[i]);
					dp[words[i]] = word2len[words[i]];
				} 
			}

			while (queue.Count != 0)
			{
				string cur = (string)queue.Dequeue();
				Hashtable curNext = (Hashtable)(graph[cur]);

				foreach (DictionaryEntry next in curNext)
				{
					string key = (string)next.Key;
					int degree = (int)bufferInDegree[key];
					bufferInDegree[key] = degree - 1;
					if ((int)dp[key] < (int)dp[cur] + (int)word2len[key])
					{
						dp[key] = (int)dp[cur] + (int)word2len[key];
						if (lastWord.ContainsKey(key))
						{
							lastWord[key] = cur;
 						}
						else 
						{
							lastWord.Add(key, cur);
						}
					}
					if (degree - 1 == 0)
					{
						queue.Enqueue(key);
					}
				}
			}

			int maxLen = 0;
			string lastChainWord = "";
			foreach (string str in words)
			{
				if ((int)dp[str] > maxLen 
					&& (str[str.Length - 1] == end || isInvalidChar(end)))
				{
					maxLen = (int)dp[str];
					lastChainWord = str;
				}
			}
			List<string> reversedRes = new List<string>();
			reversedRes.Add(lastChainWord);
			while (lastWord.ContainsKey(lastChainWord))
			{
				lastChainWord = (string)lastWord[lastChainWord];
				reversedRes.Add(lastChainWord);
			}
			for (int i = reversedRes.Count - 1; i >= 0; i--) 
			{
				res.Add(reversedRes[i]);
			}
			// TODO: 单个单词的单词链？
			return maxLen;
		}
		
		public int getMaxWordCountChain(char start, char end, bool enableLoop, List<string> res)
		{
			// 如果不允许有环，并且数据中确实有环
			if (!enableLoop && !dataCheck())
			{
				// TODO：数据有环的异常
				throw new HasImplicitLoopException("");
			}

			if (!enableLoop)
			{
				// return trivialGetMaxWordCountChain(start, end, res);
				return fastGetMaxWordCountChain(start, end, res);
			}
			else
			{
				return trivialGetMaxWordCountChain(start, end, res);
			}
		}

		public int getMaxAlphabetCountChain(char start, char end, bool enableLoop, List<string> res)
		{
			// 如果需要检查是否有隐含环
			if (!enableLoop && !dataCheck())
			{
				throw new HasImplicitLoopException("");
			}
			
			if (!enableLoop)
			{
				// return trivialGetMaxWordCountChain(start, end, res);
				return fastGetMaxAlphabetCountChain(start, end, res);
			}
			else
			{
				return trivialGetMaxAlphabetCountChain(start, end, res);
			}
		}

		private void getWordChainWithDifferentHead(List<string> curChain, 
			List<string> curLongestChain, string word, HashSet<char> charSet)
		{
			curChain.Add(word);
			charSet.Add(word[0]);
			
			Hashtable next = (Hashtable)graph[word];
			foreach (DictionaryEntry de in next)
			{
				string nextWord = (string)de.Key;
				if (!charSet.Contains(nextWord[0]))
				{
					getWordChainWithDifferentHead(curChain, curLongestChain, nextWord, charSet);
				}
			}

			// 满足单词数大于1的才是答案
			if (curChain.Count > curLongestChain.Count && curChain.Count > 1)
			{
				curLongestChain.Clear();
				for (int i = 0; i < curChain.Count; i++)
				{
					curLongestChain.Add(curChain[i]);
				}
			}

			curChain.RemoveAt(curChain.Count - 1);
			charSet.Remove(word[0]);
		}

		public int getMaxWordCountChainWithDifferentHead(List<string> res)
		{
			if (!dataCheck())
			{
				throw new HasImplicitLoopException("");
			}
			List<string> curLongestChain = new List<string>();
			for (int i = 0; i < words.Count; i++)
			{
				HashSet<char> charSet = new HashSet<char>();
				string word = words[i];
				List<string> chain = new List<string>();
				getWordChainWithDifferentHead(chain, curLongestChain, word, charSet);
			}
			if (curLongestChain.Count > 1)
			{
				for (int i = 0; i < curLongestChain.Count; i++)
				{
					res.Add(curLongestChain[i]);
				}
				return res.Count;
			}
			else
			{
				return 0;
			}
		}
	}
}