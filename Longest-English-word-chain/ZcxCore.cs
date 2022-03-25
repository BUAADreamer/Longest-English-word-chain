using System;
using System.Collections;
using System.Collections.Generic;

public class ZcxCore
{
	private ArrayList words;
	private Hashtable graph;

	public ZcxCore(ArrayList wordsList)
	{
		words = wordsList;
		buildGraph();
	}

	private void addEdge(string a, string b) {
		if (graph.ContainsKey(a))
		{
			
		}
	}

	private void buildGraph()
	{
		graph = new Hashtable();
		int len = words.length;
		for (int i = 0; i < len; i++) 
		{
			for (int j = i + 1; j < len; j++) 
			{
				int len1 = words[i].length;
				char lastCh = words[i][len1 - 1];
				char firstCh = words[j][0];
				if (lastCh == firstCh) 
				{
					addEdge(words[i], words[j]);
				}
			}
		}
	}
}