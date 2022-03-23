using System;
using System.Collections;
using System.Collections.Generic;
/*
class TestCore
{
    public TestCore()
    {
        testNum();
    }
    //普通测试
    public void testnormal()
    {
        ArrayList words = new ArrayList() { "woo", "oom", "moon", "noox" };
        Num num = new Num(words);
        for (int i = 0; i < 26; i++)
        {
            ArrayList cbeginwords = (ArrayList)num.getBeginc2words();
            Console.WriteLine((char)(i + 'a'));
            foreach (string word in ((ArrayList)cbeginwords[i]))
            {
                Console.WriteLine(word);
            }
        }
        Console.WriteLine(((ArrayList)num.getEndc2words()).ToString());
    }
    //-n命令测试
    public void testNum()
    {
        ArrayList words = new ArrayList() { "woo", "oom", "moon", "noox" };
        words = new ArrayList() {
                                        "Algebra",
                                        "Apple",
                                        "Zoo",
                                        "Elephant",
                                        "Under",
                                        "Fox",
                                        "Dog",
                                        "Moon",
                                        "Leaf",
                                        "Trick",
                                        "Pseudopseudohypoparathyroidism"
                                    };
        words = new ArrayList() { "aba", "aca", "ada", "ad" };
        Num num = new Num(words);
        num.getAllWordChains();
        ArrayList ans = num.getAns();
        Console.WriteLine(ans.Count);
        for (int i = 0; i < ans.Count; i++)
        {
            ArrayList linewords = (ArrayList)ans[i];
            for (int j = 0; j < linewords.Count; j++)
            {
                Console.Write((string)linewords[j] + " ");
            }
            Console.WriteLine();
        }
    }
    
}
*/

/**
 * 构造：字符串列表words
 * 获得单词链列表
 * beginc2words:ArrayList<ArrayList> 以某个字符开头的单词列表 比如：beginc2words['a'-0]=['abc','ac']
 * endc2words:ArrayList<ArrayList> 以某个字符结尾的单词列表
 * word2appear:某次深度搜索中，单词与是否出现过的对应关系hash表
 * wordChain:搜索到某一层时的单词链数组
 * ans:
 */
public class Num
{
    private ArrayList words;
    private ArrayList beginc2words = new ArrayList(); 
    private ArrayList endc2words = new ArrayList();
    private Hashtable word2appear = new Hashtable();
    private ArrayList wordChain = new ArrayList();
    private ArrayList ans = new ArrayList();
    private Hashtable wordChainSets = new Hashtable();
    public Num(ArrayList words)
    {
        this.words = words;
        
        //建立两个从首尾字母和相应字母的映射
        //初始化ArrayList of ArrayList
        for (int i = 0; i < 26; i++)
        {
            ArrayList tmp = new ArrayList();
            this.beginc2words.Add(tmp);
            ArrayList tmp1 = new ArrayList();
            this.endc2words.Add(tmp1);
        }
        foreach (string word in words)
        {
            string wordLow = word.ToLower();
            char beginc = wordLow[0];
            char endc = wordLow[wordLow.Length - 1];
            ((ArrayList)this.beginc2words[beginc - 'a']).Add(wordLow);
            ((ArrayList)this.endc2words[endc - 'a']).Add(wordLow);
        }
    }
    public ArrayList getBeginc2words()
    {
        return this.beginc2words;
    }
    public ArrayList getEndc2words()
    {
        return this.endc2words;
    }
    //对于每一个字符开始的都搜索一下
    public ArrayList getAllWordChains()
    {
        for (int i = 0; i < 26; i++)
        {
            this.word2appear = new Hashtable();
            this.wordChain = new ArrayList();
            dfs(i);
        }
        HashSet<string> allWordChains = new HashSet<string>();
        for (int i = 0; i < ans.Count; i++)
        {
            ArrayList lineWords = (ArrayList)ans[i];
            string chain = "";
            for (int j = 0; j < lineWords.Count; j++)
            {
                chain += (string)lineWords[j] + " ";
            }
            allWordChains.Add(chain);
        }
        ans.Clear();
        foreach(string chain in allWordChains)
        {
            ans.Add(chain);
        }
        return ans;
    }
    /*
     * ci:char index of begin char like 'a'-->0
     */
    public void dfs(int ci)
    {
        if (((ArrayList)beginc2words[ci]).Count == 0) return;
        ArrayList words = (ArrayList)beginc2words[ci];
        for (int i = 0; i < words.Count; i++)
        {
            string word = (string)words[i];
            if (word2appear.ContainsKey(word)) continue;
            char endc = word[word.Length - 1];
            this.word2appear.Add(word, 1);
            this.wordChain.Add(word);
            //len of wordchain >=2 and judge whether exists circle 
            if (this.wordChain.Count > 1
                && word[word.Length - 1] != ((string)wordChain[0])[0])
            {
                //if(wordChainSets.ContainsKey())
                //this.wordChainSets.Add(wordChain.Clone(),1);
                this.ans.Add(this.wordChain.Clone());
            }
            dfs(word[word.Length - 1] - 'a');
            this.wordChain.RemoveAt(this.wordChain.Count - 1);
            this.word2appear.Remove(word);
        }
    }
    //get ans of word chain list
    public ArrayList getAns()
    {
        return ans;
    }
}
