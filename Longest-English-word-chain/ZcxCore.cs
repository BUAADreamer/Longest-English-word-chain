using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;

public class ZcxCore
{
	private ArrayList words;
	private Hashtable graph;
	private Hashtable inDegree;
	private Hashtable word2len;

	public ZcxCore(ArrayList wordsList)
	{
		words = wordsList;
		buildGraph();
	}

	private void addEdge(string a, string b) {
		if (graph.ContainsKey(a))
		{
			Hashtable cur = (Hashtable)graph[a];
			cur.Add(b, 1);
		}
		else
        {
			Hashtable cur = new Hashtable();
			cur.Add(b, 1);
			graph.Add(a, cur);
        }
		int val = (int)(inDegree[b]);
		inDegree[b] = val + 1;
	}

	private void buildGraph()
	{
		graph = new Hashtable();
		inDegree = new Hashtable();
		word2len = new Hashtable();
		int len = words.Count;
		for (int i = 0; i < len; i++)
        {
			inDegree.Add((string)(words[i]), 0);
        }
		for (int i = 0; i < len; i++)
        {
			word2len.Add((string)(words[i]), 1);
		}
		for (int i = 0; i < len; i++)
        {
			graph.Add((string)(words[i]), new Hashtable());
        }
		for (int i = 0; i < len; i++) 
		{
			for (int j = i + 1; j < len; j++) 
			{
				int len1 =( (string)words[i]).Length;
				char lastCh = ((string)words[i])[len1 - 1];
				char firstCh = ((string)words[j])[0];
				if (lastCh == firstCh) 
				{
					addEdge((string)words[i], (string)words[j]);
				}
			}
		}
	}

	public int getMaxWordCountChain()
    {
		Queue queue = new Queue();
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
			Console.WriteLine(cur);
			Hashtable curNext = (Hashtable)(graph[cur]);
			foreach (DictionaryEntry next in curNext)
            {
				string key = (string)next.Key;
				int degree = (int)inDegree[key];
				inDegree[key] = degree - 1;
				word2len[key] = Math.Max((int)word2len[key], (int)(word2len[cur]) + 1);
				if (degree - 1 == 0)
                {
					queue.Enqueue(key);
                }
            }
        }
		int ans = 0;
		foreach (DictionaryEntry de in word2len)
        {
			int value = (int)de.Value;
			ans = Math.Max(ans, value);
        }
		return ans;
    }
}